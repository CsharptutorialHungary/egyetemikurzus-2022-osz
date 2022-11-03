using ZWPARW;

var loader = new CommandLoader();
var dir = AppContext.BaseDirectory;
string[] sorok = File.ReadAllLines(dir + "Leltar.csv");
try
{
    while (true)
    {
        Console.WriteLine("Type Command:  ");
        string command = Console.ReadLine();
        string[] commands = command.Split(" ");
        if (!string.IsNullOrEmpty(commands[0]) && loader.Commands.ContainsKey(commands[0]))
        {
            Console.WriteLine(commands[1]);
            loader.Commands[commands[0]].Execute(sorok);
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
