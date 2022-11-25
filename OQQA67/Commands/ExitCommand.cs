using OQQA67.Interfaces;

namespace OQQA67.Commands
{
    internal sealed class ExitCommand : IMenuCommands
    {
        public string Name => "!exit";

        public void Execute(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thanks for playing!");
            Console.ForegroundColor = ConsoleColor.Red;
            Environment.Exit(0);
        }
    }
}
