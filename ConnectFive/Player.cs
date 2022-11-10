using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFive
{
    sealed internal class Player
    {
        //public enum Color { green, red }
        //public Color color { get; protected set; }
        //public Player(Color color)
        //{
        //    this.color = color;
        //}
        public string color { get; protected set; }
        public Player(string color)
        {
            this.color = color;
        }
    }
}
