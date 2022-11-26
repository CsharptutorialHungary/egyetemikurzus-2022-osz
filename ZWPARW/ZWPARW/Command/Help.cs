using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class Help : ICommand
    {
        public string Name => "Help";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres = "Leltar.xml")
        {
            CommandLoader loader = new CommandLoader();
            Console.WriteLine("HELP");
            Console.WriteLine("Mindegyik parancsnak is lelehet kérdezni külün is a helpjét a parancs és utána help");
            Console.WriteLine();
            foreach (var item in loader.Commands)
            {
                Console.WriteLine("Leletar " + item.Value.Name);
                Console.Write("\t");
                item.Value.Help("");
                Console.WriteLine();
            }
            return leltar;

        }

        void ICommand.Help(string message)
        {
            Console.WriteLine("Segédleteket jeleniti meg");
        }
    }
}
