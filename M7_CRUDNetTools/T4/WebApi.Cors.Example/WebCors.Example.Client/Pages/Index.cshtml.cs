using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApi.Cors.Example;

namespace WebCors.Example.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<WeatherForecast> weatherForecasts { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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
        }
    }
}
