using TicTacToe.ConsoleHelpers;
using Utilities;

namespace TicTacToe {
    static class GameController {
        public static Board board;
        public static IRenderer renderer = new ConsoleRenderer();

        //private static string? name;

        public static void SelectCell() {
            int currRow = 0;
            int currCol = 0;

            Dictionary<Input.Action, (int Row, int Col)> directions = new()
            {
                { Input.Action.Left, (0, -1) },
                { Input.Action.Right, (0, 1) },
                { Input.Action.Up, (-1, 0) },
                { Input.Action.Down, (1, 0) }
            };

            board[currRow, currCol].Selected = true;

            while (true) {
                Input.Action key = Input.ReadKey();

                if (directions.ContainsKey(key)) {
                    board[currRow, currCol].Selected = false;

                    currRow = MathOperation.Mod(currRow + directions[key].Row, board.Size);
                    currCol = MathOperation.Mod(currCol + directions[key].Col, board.Size);

                    board[currRow, currCol].Selected = true;
                } else {
                    switch (key) {
                        case Input.Action.PlaceX:
                            board[currRow, currCol].State = CellState.X;
                            break;
                        case Input.Action.PlaceO:
                            board[currRow, currCol].State = CellState.O;
                            break;
                        case Input.Action.Clear:
                            board[currRow, currCol].State = CellState.Empty;
                            break;
                        case Input.Action.Exit:
                            return;
                        default:
                            break;
                    }
                }
            }
        }

        public static async void Run() {
            renderer.DrawGreeting("Welcome to TicTacToe Console!");
            // Wait so that the user can read the message
            Thread.Sleep(1000);
            string name = Input.Read(
                prompt: "Enter your name",
                errorMessage: "Please enter a valid name",
                converter: x => x,
                validate: name => name != null && name != "");

            int boardSize = Input.Read(
                prompt: "Enter a board size (3 - 5)",
                errorMessage: "Please enter a valid number (3 - 5)",
                converter: int.Parse,
                validate: size => size < 10 && size > 2);

            board = new Board(boardSize);
            renderer.SetBoard(board);
            renderer.DrawBoard();

            SelectCell();

            //ConsoleRegion r1 = new ConsoleRegion(0, 60, 3, 30, Justify.CenterRight, true);
            //for (int i = 0; i < 40; i++) {
            //    r1.WriteLine($"KEKW{i}");
            //}
            //r1.Flush();

            //Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.ReadKey();
        }
    }
}
