namespace TicTacToe {
    static class GameController {
        public static Board board = new();
        public static IRenderer renderer = new ConsoleRenderer();

        public static async Task Run() {
            renderer.DrawGreeting("Welcome to TicTacToe Console!");

            Console.WriteLine("Waiting for discover messages...");
            var clients = await NetworkController.Discover();
            foreach (var item in clients) {
                Console.WriteLine(item);
            }
            //// Wait so that the user can read the message
            //Thread.Sleep(1000);

            //Player p1 = InitializePlayer("Enter the first player's (X) name", CellState.X);
            //Player p2 = InitializePlayer("Enter the second player's (O) name", CellState.O);

            //renderer.DrawBoard();

            //while (true) {
            //    p1.TakeTurn();
            //    if (board.IsInWinState) {
            //        renderer.DrawWin(p1);
            //        break;
            //    }
            //    p2.TakeTurn();
            //    if (board.IsInWinState) {
            //        renderer.DrawWin(p2);
            //        break;
            //    }
            //}

            Console.ReadKey();
        }

        private static Player InitializePlayer(string namePrompt, CellState team) {
            string name = Input.Read(
                prompt: namePrompt,
                errorMessage: "Please enter a valid name!",
                converter: x => x,
                validate: name => name != null && name != "");

            return new Player(name, team);
        }
    }
}
