using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Controllers;

namespace Weather.Commands
{
    internal class WeatherCommandGetToday : IWeatherCommand
    {
        public string Name => "get today";

        public async Task<bool> Execute()
        {
            var response = await WeatherReportParser.GetCurrentWeather();
            if (response == null || response.list == null || response.list.Count == 0) return false;
            DateTime time;
            var today = response.list.FindAll(x => DateTime.TryParse(x.dt_txt, out time) && DateTime.Parse(x.dt_txt).Day == DateTime.Now.Day);
            var builder = new WeatherReportStringBuilder();
            if (today.Count == 0) return false;
            Console.WriteLine("Todays forecast:");
            foreach (var i in today) {
                Console.WriteLine(builder.formatWeatherReport(i));
            }
            return true;
        }
    }
}
