using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ2CNC_Tetris
{
    public struct Position // struct osztály, Csupán 8 byte adat miatt.
    {
        public int Row { get;}
        public int Column { get;}

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
