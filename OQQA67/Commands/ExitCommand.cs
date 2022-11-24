using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQQA67.Commands
{
    internal sealed class ExitCommand : IBlackJackCommands
    {
        public string Name => "!exit";

        public void Execute(Player player)
        {
            Console.WriteLine("Thanks for playing!");
            Environment.Exit(0);
        }
    }
}
