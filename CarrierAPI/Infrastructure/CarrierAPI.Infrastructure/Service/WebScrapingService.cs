using CarrierAPI.Application.Abstractions.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace CarrierAPI.Infrastructure.Service
{
    public class WebScrapingService : IWebScrapingService
    {
        public (List<string>, bool Success) webScraping(string url)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            // ChromeDriver'ı başlat
            IWebDriver driver = new ChromeDriver(options);

            // Hedef siteye git
            driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Sayfanın tamamen yüklenmesini bekle
            wait.Until(d =>
     d.FindElements(By.TagName("h4"))
      .Any(e => !string.IsNullOrWhiteSpace(e.Text))
 );

            var results = new List<string>();


            //başlıkları almak için:
            var headings = driver.FindElements(By.CssSelector("h1"));
            foreach (var h in headings)
                if (!string.IsNullOrWhiteSpace(h.Text))
                    results.Add("Başlık: " + h.Text);

            // 3) Menü öğeleri (örnek CSS seçici)
            var menuItems = driver.FindElements(By.CssSelector("ul.menu > li.tab"));
            foreach (var m in menuItems)
                if (!string.IsNullOrWhiteSpace(m.Text))
                    results.Add("Menü: " + m.Text);

            // 4) Paragraflar
            var paragraphs = driver.FindElements(By.CssSelector("p"));
            foreach (var p in paragraphs)
                if (!string.IsNullOrWhiteSpace(p.Text))
                    results.Add("paragraf: " + p.Text);

            // Tarayıcıyı kapat
            driver.Quit();
            if (paragraphs != null || headings != null)
                return (results, true);
            else
                return (results, false);
        }
    }
}
