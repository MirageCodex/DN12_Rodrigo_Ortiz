// See https://aka.ms/new-console-template for more information
using Api.Entities;
using System.Text;
using WebApi.WindowsClient;

//await GetIp();
System.Threading.Thread.Sleep(5000);
var forecast = GetWeatherForecastAsync(new Zone
{
    City = "Acapulco",
    Date = new DateTime(2021, 10, 20)
}).Result;

Console.WriteLine("Ciudad: "+ forecast.Zone.City);
Console.WriteLine("Fecha: " + forecast.Zone.Date);

foreach(var item in forecast.WeatherForecast)
{
    Console.WriteLine();
    Console.WriteLine("Summary: "+item.Summary);
    Console.WriteLine("TemperatureC: "+item.TemperatureC);
    Console.WriteLine("TemperatureF: " + item.TemperatureF);
}
Console.ReadKey();


static async Task<ZoneWeatherForecast> GetWeatherForecastAsync(Zone zone)
{
    string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(zone);

    HttpClient client = new HttpClient();



    HttpResponseMessage response = await client.PostAsync("https://localhost:7230/weatherforecast/byzone",new StringContent(jsonContent,Encoding.UTF8,"application/json"));
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();

    ZoneWeatherForecast forecast = Newtonsoft.Json.JsonConvert.DeserializeObject<ZoneWeatherForecast>(responseBody);

    /*Console.WriteLine("My current Ip Address is: " + ip.Ip);

    var info = await GetIpInfo(ip.Ip);

    Console.WriteLine("Country: " + info.Country);
    Console.WriteLine("City: " + info.City);
    Console.WriteLine("Timezone: " + info.Timezone);*/

    return forecast;
}

static async Task<IpAddress> GetIp()
{
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync("https://api4.ipify.org?format=json");
    response.EnsureSuccessStatusCode();

    string responseBody= await response.Content.ReadAsStringAsync();

    IpAddress ip = Newtonsoft.Json.JsonConvert.DeserializeObject<IpAddress>(responseBody);
     
    Console.WriteLine("My current Ip Address is: "+ip.Ip);

    var info = await GetIpInfo(ip.Ip);

    Console.WriteLine("Country: " + info.Country);
    Console.WriteLine("City: "+info.City);
    Console.WriteLine("Timezone: " + info.Timezone);

    return ip;
}
static async Task<IpInfo> GetIpInfo(string ipAddress )
{
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync($"https://ipinfo.io/{ipAddress}/geo");
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();

    IpInfo info = Newtonsoft.Json.JsonConvert.DeserializeObject<IpInfo>(responseBody);

    

    return info;
}
