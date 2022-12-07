using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFive
{
    public record class Player
    {
        public string color { get; private set; }
        public string name { get; private set; }
        public Player(string color,string name)
        {
            this.color = color;
            this.name = name;
        }
    }
}
