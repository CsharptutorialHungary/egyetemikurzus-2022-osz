using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [Serializable]
    internal sealed record ModelRain
    {
        [JsonProperty(PropertyName = "3h")]
        public float amount { get; set; }
    }
}
