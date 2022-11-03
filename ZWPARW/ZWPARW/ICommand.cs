using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZWPARW
{
    internal interface ICommand
    {
        public string Name { get;}
        public string Description { get;}

        string[] Execute(string[] strings);

        void Help(string message);


    }
}
