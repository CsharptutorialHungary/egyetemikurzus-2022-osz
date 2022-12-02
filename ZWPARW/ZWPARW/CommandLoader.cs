using System.Reflection;

namespace ZWPARW
{
    internal class CommandLoader
    {
        public Dictionary<string, ICommand> Commands { get; }

        public CommandLoader()
        {

            Commands = new Dictionary<string, ICommand>();
            Assembly? asm = Assembly.GetAssembly(typeof(CommandLoader));

            if (asm == null)
            {
                throw new InvalidOperationException("Samting went wrong");
            }

            var types = asm.GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsAssignableTo(typeof(ICommand)));

            try
            {
                foreach (var type in types)
                {
                    if (Activator.CreateInstance(type) is ICommand comand)
                    {
                        Commands.Add(comand.Name, comand);
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
