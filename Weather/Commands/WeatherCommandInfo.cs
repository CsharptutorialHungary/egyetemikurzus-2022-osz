using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Controllers;

namespace Weather.Commands
{
    internal class WeatherCommandInfo : IWeatherCommand
    {
        public string Name => "info";

        public async Task<bool> Execute()
        {
            var response = await WeatherReportParser.GetCurrentWeather();
            if (response == null || response.list == null || response.list.Count == 0) return false;
            DateTime time;
            foreach (var weather in response.list)
            {
                if (String.IsNullOrEmpty(weather.dt_txt) || !DateTime.TryParse(weather.dt_txt, out time))
                {
                    Console.WriteLine("Couldn't find oldest and youngest weather report.");
                    return false;
                }
            }
            var youngest = response.list.MaxBy(x => DateTime.Parse(x.dt_txt)); // line 19: checked already if x.dt_txt is null or empty or can not be parsed
            var oldest = response.list.MinBy(x => DateTime.Parse(x.dt_txt)); // line 19: checked already if x.dt_txt is null or empty or can not be parsed
            Console.WriteLine($"\tOldest data: {oldest.dt_txt}");
            Console.WriteLine($"\tYoungest data: {youngest.dt_txt}");
            return true;
        }
    }
}
