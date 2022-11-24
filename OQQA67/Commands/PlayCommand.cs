using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQQA67.Commands
{
    internal sealed class PlayCommand : IBlackJackCommands
    {
        public string Name => "!play";

        public void Execute(Player player)
        {
            if (player.balance == 0)
            {
                Console.WriteLine("You don't have any credits! Use '!free'");
                return;
            }
            Console.Write("Place your bet!");
            string? line = Console.ReadLine();
            int bet;
            if (!int.TryParse(line, out bet))
            {
                Console.WriteLine("You must enter an integer!");
                return;
            }
            if(bet > player.balance)
            {
                Console.WriteLine("You don't have enough credits!");
                return;
            }



        }
    }
}
