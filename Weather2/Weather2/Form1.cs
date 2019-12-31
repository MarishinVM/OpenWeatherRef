using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Weather2.Forecast;

namespace Weather2
{
    public partial class Form1 : Form
    {
        const string Appid = "339ec1932650a0effff53b12ca9f8fb4";
        string currentCityName = "Moscow";

        private readonly Forecaster forecaster;
        
        public Form1()
        {
            InitializeComponent();
            forecaster = new Forecaster(Appid);
            getWeather(currentCityName);
            getForecast(currentCityName);
        }

        void getWeather(string city)
        {
            var weather = forecaster.GetWeather(city);
            label_city.Text    = $"{weather.CityName}";
            label_Region.Text  = $"{weather.Country}";
            label_CurTemp.Text = $"{weather.Temperature}\u00B0C";
            picture_1.Image    = GetIcon(weather.WeatherIconId);
        }

        void getForecast(string city)
        {
            const int days = 5;

            var forecast = forecaster.GetForecast(city, days);

            label_day.Text   = forecast.date[0].DayOfWeek;
            label_date.Text  = forecast.date[0].Date;
            label_con.Text   = forecast.date[0].WeatherConditions;
            label_des.Text   = forecast.date[0].WeatherDescription;
            label_speed.Text = forecast.date[0].WindSpeed;
            label_temp.Text  = forecast.date[0].Temperature;

            label_day2.Text  = forecast.date[1].DayOfWeek;
            label_date2.Text = forecast.date[1].Date;
            label_con2.Text  = forecast.date[1].WeatherConditions;
            label_des2.Text  = forecast.date[1].WeatherDescription;
            label_speed.Text = forecast.date[1].WindSpeed;
            label_temp.Text  = forecast.date[1].Temperature;

            label_day3.Text  = forecast.date[2].DayOfWeek;
            label_date3.Text = forecast.date[2].Date;
            label_con3.Text  = forecast.date[2].WeatherConditions;
            label_des3.Text  = forecast.date[2].WeatherDescription;
            label_speed.Text = forecast.date[2].WindSpeed;
            label_temp.Text  = forecast.date[2].Temperature;

            label_day4.Text  = forecast.date[3].DayOfWeek;
            label_date4.Text = forecast.date[3].Date;
            label_con4.Text  = forecast.date[3].WeatherConditions;
            label_des4.Text  = forecast.date[3].WeatherDescription;
            label_speed.Text = forecast.date[3].WindSpeed;
            label_temp.Text  = forecast.date[3].Temperature;

            label_day5.Text  = forecast.date[4].DayOfWeek;
            label_date5.Text = forecast.date[4].Date;
            label_con5.Text  = forecast.date[4].WeatherConditions;
            label_des5.Text  = forecast.date[4].WeatherDescription;
            label_speed.Text = forecast.date[4].WindSpeed;
            label_temp.Text  = forecast.date[4].Temperature;
        }


        DateTime getDate(double milliseconds)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(milliseconds).ToLocalTime();
            return day;
        }

        private static Image GetIcon(string iconId)
        {
            var url = $"http://openweathermap.org/img/wn/{iconId}.png"; //изображение
            
            var request = WebRequest.Create(url);
            using (var responce = request.GetResponse())
            using (var weatherIcon = responce.GetResponseStream())
            {
                var weatherImg = Image.FromStream(weatherIcon);
                return weatherImg;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
     
        private void button_search_Click(object sender, EventArgs e)
        {
            if (text_city.Text == "") return;
            getWeather(text_city.Text);
            getForecast(text_city.Text);
        }

        public void button_save_Click(object sender, EventArgs e)
        {
            if (text_city.Text == "") return;
            using(StreamWriter str = new StreamWriter("weather.txt"))
            {
                str.WriteLine("Город: " + label_city.Text);

                str.WriteLine("Регион: " + label_Region.Text);

                str.WriteLine("Погода на текущий момент времени: " + label_CurTemp.Text);

                str.WriteLine("Прогноз погоды на " + label_date.Text + ":");

                str.WriteLine("Температура: " + label_temp.Text);

                str.WriteLine("Состояние погоды: " + label_con.Text);

                str.WriteLine("Описание: " + label_des.Text);

                str.WriteLine("Прогноз погоды на " + label_date2.Text + ":");

                str.WriteLine("Температура: " + label_temp2.Text);

                str.WriteLine("Состояние погоды: " + label_con2.Text);

                str.WriteLine("Описание: " + label_des2.Text);

                str.WriteLine("Прогноз погоды на " + label_date3.Text + ":");

                str.WriteLine("Температура: " + label_temp3.Text);

                str.WriteLine("Состояние погоды: " + label_con3.Text);

                str.WriteLine("Описание: " + label_des3.Text);

                str.WriteLine("Прогноз погоды на " + label_date4.Text + ":");

                str.WriteLine("Температура: " + label_temp4.Text);

                str.WriteLine("Состояние погоды: " + label_con4.Text);

                str.WriteLine("Описание: " + label_des4.Text);

                str.WriteLine("Прогноз погоды на " + label_date5.Text + ":");

                str.WriteLine("Температура: " + label_temp5.Text);

                str.WriteLine("Состояние погоды: " + label_con5.Text);

                str.WriteLine("Описание: " + label_des5.Text);

            }
        }

        private void text_city_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
