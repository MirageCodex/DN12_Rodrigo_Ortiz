using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using WebApi.Cors.Example;

namespace WebCors.Example.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStringLocalizer<IndexModel> _localizer;
        private readonly IHtmlLocalizer<IndexModel> _htmlLocalizer;

        public List<WeatherForecast> weatherForecasts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IStringLocalizer<IndexModel> localizer, IHtmlLocalizer<IndexModel> htmlLocalizer)
        {
            _logger = logger;
            _localizer = localizer;
            _htmlLocalizer = htmlLocalizer;
        }

        public async Task OnGetAsync()
        {
            System.Threading.Thread.Sleep(5000);

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44321/WeatherForecast");
            if(response.IsSuccessStatusCode) 
            { 
                var content =  await response.Content.ReadAsStringAsync();
                weatherForecasts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WeatherForecast>>(content);
            }
            ViewData["ResultMessage"] = _localizer.GetString("SuccessMessage");
        }
    }
}
