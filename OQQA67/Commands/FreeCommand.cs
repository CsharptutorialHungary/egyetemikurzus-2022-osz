using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQQA67.Commands
{
    internal sealed class FreeCommand : IBlackJackCommands
    {
        public string Name => "!free";

        public void Execute(Player player)
        {
            if(player.balance == 0)
            {
                player.balance = 1000;
                Console.WriteLine("You got 1000 free credits!");
            }
            else
            {
                Console.WriteLine("You already have credits, use them!");
            }
        }
    }
}
