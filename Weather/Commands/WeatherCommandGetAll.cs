using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Controllers;
using Weather.Models;

namespace Weather.Commands
{
    internal class WeatherCommandGetAll : IWeatherCommand
    {
        public string Name => "get all";

        public async Task<bool> Execute()
        {
            var response = await WeatherReportParser.GetCurrentWeather();
            if (response == null || response.list == null || response.list.Count == 0) return false;
            foreach (ModelWeatherReport i in response.list)
            {
                Console.WriteLine(i.ToString());
            }
            return true;
        }
    }
}
