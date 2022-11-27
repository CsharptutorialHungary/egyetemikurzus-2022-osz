using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Commands
{
    internal class WeatherCommandRefresh : IWeatherCommand
    {
        public string Name => "refresh";

        public void Execute()
        {
            throw new NotImplementedException();
            //TODO call weather API's refresh logic
        }
    }
}
