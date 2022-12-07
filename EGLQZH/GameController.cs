namespace TicTacToe {
    static class GameController {
        public static Board board = new();
        public static IRenderer renderer = new ConsoleRenderer();

        public static async Task Run() {
            renderer.DrawGreeting("Welcome to TicTacToe Console!");

            // Wait so that the user can read the message
            await Task.Delay(1000);
            //var clients = await NetworkController.Discover();
            //Input.Select(
            //    prompt: "Available clients (Press ESC to end discovery)",
            //    clients
            //);

            //Thread.Sleep(1000);
            registeredPlayers = await ScoreboardSerializer.Deserialize();
            
            Player p1 = InitializePlayer("Enter the first player's (X) name", CellState.X);
            Player p2 = InitializePlayer("Enter the second player's (O) name", CellState.O);

            // Very powerful solution
            while (true) {
                renderer.DrawBoard();

                while (true) {
                    p1.TakeTurn();
                    if (board.IsInWinState) {
                        p1.Score++;
                        renderer.DrawWin(p1);
                        break;
                    }
                    p2.TakeTurn();
                    if (board.IsInWinState) {
                        p2.Score++;
                        renderer.DrawWin(p2);
                        break;
                    }
                }

                var action = Input.ReadKey(Input.Action.PlayAgain, Input.Action.Exit);
                if (action == Input.Action.PlayAgain) {
                    board.Reset();
                    continue;
                }
                if (action == Input.Action.Exit) {
                    await ScoreboardSerializer.Serialize(registeredPlayers.ToArray());
                    break;
                }
            }
        }

        private static Player InitializePlayer(string namePrompt, CellState team) {
            string name = Input.Read(
                prompt: namePrompt,
                errorMessage: "Please enter a valid name!",
                converter: x => x,
                validate: name => name != null && name != "");

            var registeredPlayer = registeredPlayers.FirstOrDefault(x => x?.Name == name, null);
            if (registeredPlayer != null) {
                registeredPlayer.Team = team;
                return registeredPlayer;
            }

            var newPlayer = new Player(name, team);
            registeredPlayers.Add(newPlayer);
            return newPlayer;
        }
        private static List<Player> registeredPlayers = new();
    }
}
