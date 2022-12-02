using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Controller;
using Weather.Controllers;
using Weather.Models;

namespace Weather.Commands
{
    internal class WeatherCommandRefresh : IWeatherCommand
    {
        public string Name => "refresh";

        public async Task<bool> Execute()
        {
            string apiResponse = String.Empty;
            try
            {
                apiResponse = await WeatherAPI.GetWeatherDataAsync();
            }
            catch (Exception e)
            {/*aswswarfgddujjjklkÉL122
              65 <--- ez itt a macska műve*/
                Console.WriteLine(e.Message);
                return false;
            }
            if(!(await WeatherIO.WriteOut(apiResponse)))
            {
                return false;
            }
            return true;
        }
    }
}
