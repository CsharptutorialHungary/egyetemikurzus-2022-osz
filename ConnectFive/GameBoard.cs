using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConnectFive
{
    public sealed class GameBoard
    {
        public sealed class Cell
        {
            //public enum cellState { green, red, empty };
            public string State { get; set; }
            public Vector2 Pos { get; set; }
            public Cell(int row, int col)
            {
                State = "white";
                Pos = new Vector2(row, col);
            }
            public void UpdateState(string color)
            {
                this.State = color;
            }

        }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Cell[,] Board { get; set; }

        public GameBoard(int width = 8, int height = 10)
        {
            this.Width = Math.Abs(width);
            this.Height = Math.Abs(height);
            Board = new Cell[this.Height, this.Width];
            for (int i = 1; i <= this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    Board[i - 1, j] = new Cell(i, j);
                }
            }
        }
        public void CellUpdated(int col, Player player)
        {
            LastAvailable(col).UpdateState(player.color);
            Renderer.DrawCell((int)LastAvailable(col).Pos.X, col, $"[{player.color}]O[/]");
        }

        private Cell LastAvailable(int col)
        {
            Cell[] colum = Enumerable.Range(0, Height)
                        .Select(x => Board[x, col])
                        .ToArray();
            return colum.Last(x => x.State == "white");
        }
        public bool CheckForWin(Player player, int col)
        {
            var row = LastAvailable(col).Pos.X;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    //horizontal
                    if (Board[i, j].State == player.color &&
                        j <= col - 4)
                    {
                        if (Board[i, j + 1].State == player.color &&
                            Board[i, j + 2].State == player.color &&
                            Board[i, j + 3].State == player.color &&
                            Board[i, j + 4].State == player.color)
                        {
                            return true;
                        }
                    }

                    //vertical
                    if (Board[i, j].State == player.color &&
                        i <= row - 4)
                    {
                        if (Board[i + 1, j].State == player.color &&
                            Board[i + 2, j].State == player.color &&
                            Board[i + 3, j].State == player.color &&
                            Board[i + 4, j].State == player.color)
                        {
                            return true;
                        }
                    }

                    //top-left to bottom-right
                    if (Board[i, j].State == player.color &&
                        i <= row - 4 && j <= col - 4)
                    {
                        if (Board[i + 1, j + 1].State == player.color &&
                            Board[i + 2, j + 2].State == player.color &&
                            Board[i + 3, j + 3].State == player.color &&
                            Board[i + 4, j + 4].State == player.color)
                        {
                            return true;
                        }
                    }

                    //top-right to bottom-left
                    if (Board[i, j].State == player.color &&
                        i <= row - 4 && j >= col + 4)
                    {
                        if (Board[i + 1, j - 1].State == player.color &&
                            Board[i + 2, j - 2].State == player.color &&
                            Board[i + 3, j - 3].State == player.color &&
                            Board[i + 4, j - 4].State == player.color)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

    }
}
