using OQQA67.Interfaces;

namespace OQQA67.Commands
{
    internal sealed class BalanceCommand : IMenuCommands
    {
        public string Name => "!balance";

        public void Execute(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your balance: {player.balance}");
        }
    }
}
