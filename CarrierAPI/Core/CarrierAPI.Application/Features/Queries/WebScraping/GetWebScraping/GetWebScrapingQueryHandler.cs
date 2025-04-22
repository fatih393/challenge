using CarrierAPI.Application.Abstractions.Services;
using CarrierAPI.Application.Features.Commands.AppUser.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarrierAPI.Application.Features.Queries.WebScraping.GetWebScraping
{
    public class GetWebScrapingQueryHandler : IRequestHandler<GetWebScrapingQueryRequest, GetWebScrapingQueryResponse>
    {
        readonly IWebScrapingService _webservice;

        public GetWebScrapingQueryHandler(IWebScrapingService webservice)
        {
            _webservice = webservice;
        }

        public Task<GetWebScrapingQueryResponse> Handle(GetWebScrapingQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var (data, success) = _webservice.webScraping(request.Url);
            return Task.FromResult(new GetWebScrapingQueryResponse(success, data));

            }
            catch
            {
                return Task.FromResult(new GetWebScrapingQueryResponse(false, null));
            }
            
        }
    }
}
