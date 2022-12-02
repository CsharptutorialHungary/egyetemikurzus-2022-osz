using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Controllers;
using Weather.Models;

namespace Weather.Commands
{
    internal class WeatherCommandGetNow : IWeatherCommand
    {
        public string Name => "get now";

        public async Task<bool> Execute()
        {
            var response = await WeatherReportParser.GetCurrentWeather();
            if (response == null || response.list == null) return false;
            DateTime time;
            var now = response.list.Find(x => DateTime.TryParse(x.dt_txt, out time) && DateTime.Parse(x.dt_txt) > DateTime.Now);
            if (now == null) return false;
            var builder = new WeatherReportStringBuilder();
            Console.WriteLine($"At the time: {builder.formatWeatherReport(now)}");
            return true;
        }
    }
}
