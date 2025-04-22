namespace CarrierAPI.Application.Features.Queries.WebScraping.GetWebScraping
{
    public class GetWebScrapingQueryResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Data { get; set; }
        public GetWebScrapingQueryResponse(bool succeeded, List<string> data)
        {
            Succeeded = succeeded;
            Message = succeeded ? "Veri çekme başarıyla gerçekleşti" : "Veri çekme işlemi başarısız oldu";
            Data = data;
        }
    }
}