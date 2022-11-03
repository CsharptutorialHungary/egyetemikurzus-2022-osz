using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZWPARW.Command
{
    internal class Lekerdezes : ICommand
    {
        public string Name => "Lekerdezes";

        public string Description => throw new NotImplementedException();

        public string[] Execute(string[] strings)
        {
            Console.WriteLine(strings[0]);

            return strings;
        }

        public void Help(string message)
        {
            throw new NotImplementedException();
        }
    }
}
