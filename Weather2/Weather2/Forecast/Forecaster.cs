using System.Net;
using Newtonsoft.Json;

namespace Weather2.Forecast
{
    public class Forecaster
    {
        private readonly string AppId;

        public Forecaster(string appId)
        {
            AppId = appId;
        }
        
        public Weather GetWeather(string city)
        {
            using (var webClient = new WebClient())
            {
                var url = $"http://api.openweathermap.org/data/2.5/weather?APPID={AppId}&units=metric&q={city}&cnt=6";
                var jsonData = webClient.DownloadString(url);
                var parsedData = JsonConvert.DeserializeObject<JsonModels.WeatherInfo.root>(jsonData);
                return new Weather(parsedData);
            }    
        }

        public Forecast GetForecast(string city, int days)
        {
            using (var webClient = new WebClient())
            {
                var url = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&cnt={days}&APPID={AppId}";
                var jsonData = webClient.DownloadString(url);
                var parsedData = JsonConvert.DeserializeObject<JsonModels.WeatherForecast>(jsonData);
                
                return new Forecast(parsedData);
            }
        }
    }
}