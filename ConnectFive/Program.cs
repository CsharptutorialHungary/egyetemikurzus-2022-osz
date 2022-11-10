using ConnectFive;
using Spectre.Console;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
GameBoard board = new GameBoard();
Renderer.DrawTable(board);
Player[] players = new Player[2] { new Player("red"), new Player("green")};//, new Player("purple")};

while (true) {
    for (int i = 0; i < players.Length; i++)
    {
        int col = Input.ColInput(1, board.width);
        board.CellUpdated(col, players[i]);
    }
}
