using System.Reflection;

namespace OQQA67
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Amazing BlackJack game");

            Player player=null;
            var loader = new CommandLoader();

            bool user = false;
            while (!user)
            {
                Console.WriteLine();
                Console.Write("Username: ");
                string? name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name) && name.Length >= 4)
                {
                    player = new Player() {name = name};
                    user = true;
                }
                else Console.WriteLine("Username must contain at least 4 letters!");
            }
            try
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Action: ");
                    string? command = Console.ReadLine();
                    if (!string.IsNullOrEmpty(command)
                        && loader.Commands.ContainsKey(command))
                    {
                        loader.Commands[command].Execute(player);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command!");
                    }
                    await Task.Delay(500);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
            }

            
        }
    }
}