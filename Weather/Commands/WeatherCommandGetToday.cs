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
            var weatherReoprts = (await WeatherReportParser.getCurrentWeather()).list;
            var today = weatherReoprts.FindAll(x => DateTime.Parse(x.dt_txt).Day == DateTime.Now.Day);
            var wrsb = new WeatherReportStringBuilder();
            Console.WriteLine("Todays forecast:");
            foreach (var i in today) {
                Console.WriteLine(wrsb.formatWeatherReport(i));
            }
            return true;
        }
    }
}
