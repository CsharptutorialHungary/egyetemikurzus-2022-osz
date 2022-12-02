using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Controllers
{
    internal class WeatherReportStringBuilder
    {
        private StringBuilder sb;

        public WeatherReportStringBuilder()
        {
            sb = new StringBuilder();
        }

        public string formatWeatherReport(ModelWeatherReport weatherReport) {
            if (weatherReport == null || weatherReport.weather == null || weatherReport.dt_txt == null) return string.Empty;
            if (sb.Length != 0) sb.Clear();
            sb.AppendLine($"Time: {DateTime.Parse(weatherReport.dt_txt)}");
            sb.AppendLine($"\t{weatherReport.main}");
            sb.AppendLine("\tWeather {");
            foreach (var i in weatherReport.weather)
            {
                sb.AppendLine($"\t\t{i}");
            }
            sb.AppendLine("\t}");
            sb.AppendLine($"\t{weatherReport.clouds}");
            //sb.AppendLine($"\t{weatherReport.rain}");
            sb.AppendLine($"\t{weatherReport.wind}");
            sb.Append($"\tVisibility: {weatherReport.visibility}");
            return sb.ToString();
        }

        public string shortFromatWeatherReport(ModelWeatherReport weatherReport)
        {
            if (weatherReport == null || weatherReport.weather == null || weatherReport.dt_txt == null) return string.Empty;
            if (sb.Length != 0) sb.Clear();
            DateTime res;
            sb.AppendLine($"Time: {((DateTime.TryParse(weatherReport.dt_txt, out res)) ? DateTime.Parse(weatherReport.dt_txt).TimeOfDay : "Error during parsing time.")}");
            sb.AppendLine($"\tTempreture: {weatherReport.main.temp}°C");
            sb.AppendLine($"\tOverall: {weatherReport.weather[0].description}");
            sb.AppendLine($"\tOverall's Chance: {weatherReport.clouds.all}");
            sb.AppendLine($"\tHumidity: {weatherReport.main.humidity}");
            sb.Append($"\tWind Speed: {weatherReport.wind.speed} km/h");
            return sb.ToString();
        }
    }
}
