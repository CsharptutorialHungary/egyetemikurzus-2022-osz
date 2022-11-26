using ZWPARW.Object;

namespace ZWPARW.Command.FelhasznaloParancs
{
    internal class UserHelp : IUser
    {
        public string Name => "UserHelp";

        public Users Execute(Users users)
        {
            UsersLoader loader = new UsersLoader();
            Console.WriteLine("HELP");
            Console.WriteLine("Mindegyik parancsnak is lelehet kérdezni külün is a helpjét a parancs és utána help");
            Console.WriteLine();
            foreach (var item in loader.UserCommands)
            {
                Console.WriteLine("User " + item.Value.Name);
                Console.Write("\t");
                item.Value.Help();
                Console.WriteLine();
            }
            return users;
        }

        public void Help()
        {
            Console.WriteLine("Segédleteket jeleniti meg");

        }
    }
}
