using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZWPARW.Object;

namespace ZWPARW.Command
{
    internal class BiztonagiMentesLekerdeze : ICommand
    {
        public string Name => "BiztonagiMentesLekerdeze";

        public string Description => throw new NotImplementedException();

        public Leltar Execute(Leltar leltar, string eleres)
        {

            string directory = Path.Combine(AppContext.BaseDirectory, "BackUp");

            var elemek = Directory.GetFiles(directory);

            foreach (var elem in elemek)
            {

                Console.WriteLine(elem.Split("\\").Last());
            }

            return leltar;
        }

        public void Help(string message)
        {
            throw new NotImplementedException();
        }
    }
}
