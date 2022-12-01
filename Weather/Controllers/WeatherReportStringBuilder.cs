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
            if (sb.Length != 0) sb.Clear();
            sb.AppendLine($"Time: {DateTime.Parse(weatherReport.dt_txt)}");
            sb.AppendLine($"\t{weatherReport.main}");
            sb.AppendLine("\tModelWeather {");
            foreach (var i in weatherReport.weather)
            {
                sb.AppendLine($"\t\t{i}");
            }
            sb.AppendLine("\t}");
            sb.AppendLine($"\t{weatherReport.clouds}");
            sb.AppendLine($"\t{weatherReport.rain}");
            sb.AppendLine($"\t{weatherReport.wind}");
            sb.Append($"\tVisibility: {weatherReport.visibility}");
            return sb.ToString();
        }
    }
}
