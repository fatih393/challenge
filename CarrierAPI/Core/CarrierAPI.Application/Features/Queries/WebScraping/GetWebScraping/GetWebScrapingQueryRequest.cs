using MediatR;

namespace CarrierAPI.Application.Features.Queries.WebScraping.GetWebScraping
{
    public class GetWebScrapingQueryRequest: IRequest<GetWebScrapingQueryResponse>
    {
        public string Url { get; set; }
    }
}