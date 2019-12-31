namespace Weather2.Forecast
{
    public class Weather
    {
        public readonly string CityName;
        public readonly string Country;
        public readonly double Temperature;
        public readonly string WeatherIconId;

        public Weather(JsonModels.WeatherInfo.root root)
        {
            CityName                       = root.name;
            Country                        = root.sys.country;
            Temperature                    = root.main.temp;
            WeatherIconId                  = root.weather[0].icon;
        }
    }
}