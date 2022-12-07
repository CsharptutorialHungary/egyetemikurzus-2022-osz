using ConnectFive;
using Spectre.Console;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
GameBoard board = new();
if (GameBoardJsonSerializer.CanDeserialize()) {
    Console.WriteLine("Be szeretnéd tölteni az utolsó állapotot? [igen/nem]");
    string input = Console.ReadLine() ?? "";
    if (input.ToLower() == "igen") {
        board = await GameBoardJsonSerializer.Deserialize() ?? board;
    }
}
Renderer.DrawTable(board);
List<Player> players = new(){ new Player("red","P1"), new Player("green","P2")};//, new Player("purple")};
bool gameEnded = false;
Player currPlayer = players[0];
while (!gameEnded) {
    for (int i = 0; i < players.Count; i++)
    {
        if (!gameEnded)
        {
            currPlayer = players[i];
            AnsiConsole.Write(new Markup($"[{currPlayer.color}]{currPlayer.name} [/]"));
            int col = Input.ColInput(1, board.Width);
            board.CellUpdated(col, currPlayer);
            gameEnded = board.CheckForWin(currPlayer, col);
        }
    }
    await GameBoardJsonSerializer.Serialize(board);
}
AnsiConsole.Write(new Markup($"[{currPlayer.color}] {currPlayer.name} [/]nyert"));

