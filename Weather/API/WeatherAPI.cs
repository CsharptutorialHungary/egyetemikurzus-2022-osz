using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Controller
{
    internal static class WeatherAPI
    {
        public static async Task<string> GetWeatherDataAsync()
        {
            HttpClient client = new HttpClient();
            string res = null;
            HttpResponseMessage response = await client.GetAsync("https://api.openweathermap.org/data/2.5/forecast?lat=46.253&lon=20.14824&units=metric&appid=9c5ec3c52fdd66e52bba3b00dc4fcc37");
            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("An error occured during reaching weather web API.");
            }
            return res;
        }
    }
}
