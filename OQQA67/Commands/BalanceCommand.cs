using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQQA67.Commands
{
    internal sealed class BalanceCommand : IBlackJackCommands
    {
        public string Name => "!balance";

        public void Execute(Player player)
        {
            Console.WriteLine($"Your balance: {player.balance}");
        }
    }
}
