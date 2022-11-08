using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZWPARW.Object;

namespace ZWPARW
{
    internal interface ICommand
    {
        public string Name { get;}
        public string Description { get;}

        Leltar Execute(Leltar leltar);

        void Help(string message);


    }
}
