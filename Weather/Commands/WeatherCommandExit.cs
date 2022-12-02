using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Commands
{
    internal class WeatherCommandExit : IWeatherCommand
    {
        public string Name => "exit";

        public Task<bool> Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
