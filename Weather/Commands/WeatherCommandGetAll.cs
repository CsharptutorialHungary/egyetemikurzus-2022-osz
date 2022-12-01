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
            var modelJsonResponse = await WeatherReportParser.getCurrentWeather();
            foreach (ModelWeatherReport i in modelJsonResponse.list)
            {
                Console.WriteLine(i.ToString());
            }
            return true;
        }
    }
}
