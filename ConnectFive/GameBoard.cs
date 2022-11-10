using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFive
{
    sealed internal class GameBoard
    {
        sealed class Cell
        {
            //public enum cellState { green, red, empty };
            //public cellState state { get; set; }
            public string state { get; set; }
            Cell[] neighbours { get; }
            public Vector2 pos { get; protected set; }
            public Cell(int row, int col)
            {
                state = "white";
                pos = new Vector2(row, col);
            }
            public void updateState(string color)
            {
                this.state = color;
            }
        }
        public int width { get; protected set; }
        public int height { get; protected set; }
        Cell[,] board { get; set; }
        public GameBoard(int width = 7, int height = 10)
        {
            this.width = Math.Abs(width);
            this.height = Math.Abs(height+1);
            board = new Cell[this.height, this.width];
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    board[i, j] = new Cell(i, j);
                }
            }
        }
        public void CellUpdated(int col, Player player)
        {
            lastAvailable(col).updateState(player.color);
            Renderer.DrawCell((int)lastAvailable(col).pos.X, col, $"[{player.color}]O[/]");
        }

        private Cell lastAvailable(int col)
        {
            Cell[] colum = Enumerable.Range(0, height)
                .Select(x => board[x, col])
                .ToArray();
            return colum.Last(x => x.state == "white");
        }
    }
}
