using System;
using System.Collections.Generic;

namespace Weather2.Forecast
{
    public class Forecast
    {
        public readonly List<ForecastDateWeather> date; 
        
        public Forecast(JsonModels.WeatherForecast forecast)
        {
            date = new List<ForecastDateWeather>();
            foreach (var list in forecast.list)
                date.Add(new ForecastDateWeather(list));
        }
    }

    public class ForecastDateWeather
    {
        public readonly string DayOfWeek;
        public readonly string Date;
        public readonly string WeatherConditions;
        public readonly string WeatherDescription;
        public readonly string Temperature;
        public readonly string WindSpeed;
        
        public ForecastDateWeather(JsonModels.list list)
        {
            DayOfWeek = getDate(list.dt).DayOfWeek.ToString();
            Date = getDate(list.dt).ToString();
            WeatherConditions = list.weather[0].main;
            WeatherDescription = list.weather[0].description;
            Temperature = $"{list.main.temp}";
            WindSpeed = $"{list.main.speed}";

        }
        
        private static DateTime getDate(double milliseconds)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(milliseconds).ToLocalTime();
            return day;
        }
    }
    
    
    
}