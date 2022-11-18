using System.Buffers;
using System.Xml.Serialization;
using ZWPARW;
using ZWPARW.Object;
internal class Program
{

    private static void Main(string[] args)
    {
        try
        {  
            Leltar leltar = new Leltar();
           
            CommandLoader loader = new CommandLoader();

            leltar = loader.Commands["Beolvasas"].Execute(leltar);


            while (true)
            {
                Console.WriteLine("Type Command:  ");

                string command = Console.ReadLine();
                string[] commands = command.Split(" ");

                if (!string.IsNullOrEmpty(commands[0]) && loader.Commands.ContainsKey(commands[0]))
                {
                    if (SikeresBeolvasas.sikeresBeolvasas == true)
                    {
                        if (commands.Length >= 2 && !string.IsNullOrEmpty(commands[1]) && commands[1].ToLower().Equals("help"))
                        {
                            loader.Commands[commands[0]].Help("Itt kivanak irva az adatok amik szerepelnek a leltárban");

                        }
                        else
                        {
                            leltar = loader.Commands[commands[0]].Execute(leltar);

                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    Console.WriteLine("Samting went wrong");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba: {ex.Message}");
        }
    }
}