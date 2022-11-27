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
        public Dictionary<string, IAsyncWeatherCommand> Commands { get; }

        public WeatherCommandLoader()
        {
            Commands = new Dictionary<string, IAsyncWeatherCommand>();

            Assembly? asm = Assembly.GetAssembly(typeof(WeatherCommandLoader));
            if (asm == null)
                throw new InvalidOperationException("something went wrong");

            var types = asm.GetTypes()
                .Where(type => type.IsClass
                        && !type.IsAbstract
                        && type.IsAssignableTo(typeof(IAsyncWeatherCommand)));

            var types2 = from type in asm.GetTypes()
                         where type.IsClass
                           && !type.IsAbstract
                           && type.IsAssignableTo(typeof(IAsyncWeatherCommand))
                         select type;

            try
            {
                foreach (var type in types)
                {
                    if (Activator.CreateInstance(type) is IAsyncWeatherCommand command)
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
