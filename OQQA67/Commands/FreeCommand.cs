using OQQA67.Interfaces;

namespace OQQA67.Commands
{
    internal sealed class FreeCommand : IMenuCommands
    {
        public string Name => "!free";

        public void Execute(Player player)
        {
            if (player.balance < 100)
            {
                player.balance = 1000;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You got 1000 free credits!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You already have credits, use them!");
            }
        }
    }
}
