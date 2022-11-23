using ZWPARW;
using ZWPARW.Object;
internal class Program
{

    static  void Main(string[] args)
    {
        try
        {
            Leltar leltar = new Leltar();

            CommandLoader loader = new CommandLoader();

            leltar = loader.Commands["Beolvasas"].Execute(leltar);

            Sikeres.t = new Task(async () => loader.Commands["BiztonsagiMentes"].Execute(leltar));

            Sikeres.t.Start();

            while (true)
            {
                Console.WriteLine("Type Command:  ");

                string command = Console.ReadLine();
                string[] commands = command.Split(" ");

                if (!string.IsNullOrEmpty(commands[0]) && loader.Commands.ContainsKey(commands[0]))
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