using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [Serializable]
    internal sealed record ModelWeatherReport
    {
        public long dt { get; set; }
        public int visibility { get; set; }
        public float pop { get; set; }
        public string? dt_txt { get; set; }
        public ModelMain? main { get; set;}
        public List<ModelWeather>? weather { get; set; }
        public ModelClouds? clouds { get; set; }
        public ModelWind? wind { get; set; }
        public ModelSys? sys { get; set; }
    }
}
