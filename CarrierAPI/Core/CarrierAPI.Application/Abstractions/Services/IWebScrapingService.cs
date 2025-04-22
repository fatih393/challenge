using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierAPI.Application.Abstractions.Services
{
    public interface IWebScrapingService
    {
        public (List<string> , bool Success) webScraping(string url);
    }
}
