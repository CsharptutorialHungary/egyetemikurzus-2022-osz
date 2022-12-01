using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [Serializable]
    internal sealed record ModelJsonResponse
    {
        public string? cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<ModelWeatherReport>? list { get; set; }
    }
}
