using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models
{
    [Serializable]
    internal sealed record ModelClouds
    {
        public int all { get; set; }
    }
}
