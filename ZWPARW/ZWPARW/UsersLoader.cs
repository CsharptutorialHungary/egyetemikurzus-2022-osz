using System.Reflection;

namespace ZWPARW
{

    internal class UsersLoader
    {
        public Dictionary<string, IUser> UserCommands { get; }

        public UsersLoader()
        {


            UserCommands = new Dictionary<string, IUser>();
            Assembly? asm = Assembly.GetAssembly(typeof(UsersLoader));
            if (asm == null)
            {
                throw new InvalidOperationException("Samting went wrong");
            }

            var types = asm.GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.IsAssignableTo(typeof(IUser)));

            try
            {
                foreach (var type in types)
                {
                    if (Activator.CreateInstance(type) is IUser comand)
                    {
                        UserCommands.Add(comand.Name, comand);
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

