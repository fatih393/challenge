using CarrierAPI.Persistence;
using CarrierAPI.Application;
using CarrierAPI.Infrastructure;
using CarrierAPI.Infrastructure.Hangfire;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;
using CarrierAPI.API.Configurations.GetUserLogin;
using CarrierAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Serilog.Context;
using CarrierAPI.API.Configurations.ColumnWriters;
using Microsoft.AspNetCore.HttpLogging;
using Hangfire;
using CarrierAPI.Infrastructure.Service;
using CarrierAPI.Application.Abstractions.Services;
using StackExchange.Redis;
using Elastic.Clients.Elasticsearch;
using CarrierAPI.Domain.Entities;
using CarrierAPI.Persistence.Services;
using CarrierAPI.Application.DTOs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddInfrastructureService(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddSingleton(provider =>
{
    
    var settings = new ElasticsearchClientSettings(new Uri("http://localhost:9200"));
    settings.DefaultIndex("products");

    
    return new ElasticsearchClient(settings);
});

builder.Services.AddScoped<IElasticService<ProductDto>>(provider =>
{
   
    var client = provider.GetRequiredService<ElasticsearchClient>();

    
    return new ElasticService<ProductDto>(client, "products");  // "products" index ad�
});


builder.Services.AddSwaggerGen();

var redisConnection = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);

builder.Services.AddHangfireWithPostgreSql(builder.Configuration);
builder.Services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>(); /// olmamas� laz�m ama kolay�ma geldi
builder.Services.AddHttpContextAccessor();
Logger log = new LoggerConfiguration()
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"), "logs", needAutoCreateTable: true,
    columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        {"message", new RenderedMessageColumnWriter() },
        {"message_template", new MessageTemplateColumnWriter() },
        {"level", new LevelColumnWriter() },
        {"time_stamp", new TimestampColumnWriter() },
        {"exception", new ExceptionColumnWriter() },
        {"log_event", new LogEventSerializedColumnWriter() },
        {"user_name", new UserNameColumnWriter() }
        })
    .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"])
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();
builder.Host.UseSerilog(log);



builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseHangfireDashboard();
/*RecurringJob.AddOrUpdate<IExampleJobService>(
    "job",                                
    job => job.RunExampleJob(),            
    Cron.Minutely                          
);*/ //Her dakika jobun �al��mas�
app.UseAuthorization();


app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("user_name", username);
    await next();
});

app.MapControllers();

app.Run();
