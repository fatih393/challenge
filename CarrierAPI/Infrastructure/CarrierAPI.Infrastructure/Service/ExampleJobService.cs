using CarrierAPI.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Infrastructure.Service
{
    public class ExampleJobService : IExampleJobService
    {
        IMailService _mailService;

        public ExampleJobService(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async void RunExampleJob()
        {
            await _mailService.SendMailAsync(new[]
            {
                "fatihhizli393@gmail.com"
               // "furkan_524@hotmail.com",
              //  "yunusyildirim2002@gmail.com",
              //  "174furkan@gmail.com"
            }, "Bu bir deneme mailidir", "<strong>Toplu Test maili</strong>");
            Console.WriteLine($"Job çalıştı: {DateTime.Now}");
        }
    }
}
