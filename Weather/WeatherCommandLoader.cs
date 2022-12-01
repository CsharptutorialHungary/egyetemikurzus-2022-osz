using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Weather.Commands;

namespace Weather
{
    internal class WeatherCommandLoader
    {
        public Dictionary<string, IWeatherCommand> Commands { get; }

        public WeatherCommandLoader()
        {
            Commands = new Dictionary<string, IWeatherCommand>();
            Assembly? asm = Assembly.GetAssembly(typeof(WeatherCommandLoader));
            if (asm == null)
            {
                throw new InvalidOperationException("WeatherCommandLoader::WeatherCommand() -> Coulnd't get assembly object.");
            }
            var types = asm.GetTypes()
                .Where(type => type.IsClass
                        && !type.IsAbstract
                        && type.IsAssignableTo(typeof(IWeatherCommand)));
            try
            {
                foreach (var type in types)
                {
                    if (Activator.CreateInstance(type) is IWeatherCommand command)
                    {
                        Commands.Add(command.Name, command);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
