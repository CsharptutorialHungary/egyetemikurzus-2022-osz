using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Commands
{
    internal class WeatherCommandGet : IWeatherCommand
    {
        public string Name => "get";

        public void Execute()
        {
            throw new NotImplementedException();
            //TODO call deserialization from data file and put it on screen
        }
    }
}
