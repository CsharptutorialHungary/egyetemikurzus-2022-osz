using OQQA67.Interfaces;
using System.Reflection;

namespace OQQA67
{
    internal sealed class CommandLoader
    {
        public Dictionary<string, IMenuCommands> Commands { get; }
        public CommandLoader()
        {
            Commands = new Dictionary<string, IMenuCommands>();

            Assembly? assembly = Assembly.GetAssembly(typeof(CommandLoader));

            if (assembly == null) throw new InvalidOperationException("Couldn't load the commands");

            var types = assembly.GetTypes()
                .Where(type => type.IsClass
                        && !type.IsAbstract
                        && type.IsAssignableTo(typeof(IMenuCommands)));

            try
            {
                foreach (var type in types)
                {
                    if (Activator.CreateInstance(type) is IMenuCommands command)
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
