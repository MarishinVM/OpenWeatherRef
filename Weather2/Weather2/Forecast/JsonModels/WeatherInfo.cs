using System.Collections.Generic;

namespace Weather2.Forecast.JsonModels
{
    public class WeatherInfo
    {
        public class weather
        {
            public int    id          { get; set; }
            public string main        { get; set; }
            public string description { get; set; }
            public string icon        { get; set; } // изображение
        }

        public class main
        {
            public double temp     { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
        }

        public class wind
        {
            public double speed { get; set; }
        }

        public class sys
        {
            public string country { get; set; }
        }

        public class root
        {
            public string name { get; set; }
            public sys    sys  { get; set; }
            public double dt   { get; set; }
            public wind   wind { get; set; }
            public main   main { get; set; }
            public List <weather> weather { get; set; }
        }

    }
}