namespace TicTacToe {
    static class Input {
        public enum Action {
            Left, Right, Up, Down,
            PlaceX, PlaceO, Clear, Exit
        }
        public static T Read<T>(string prompt, Converter<string, T> converter, string? errorMessage = null, Predicate<T>? validate = null) {
            Console.Clear();
            Console.Write($"{prompt}: ");

            string displayErrorMessage = $"{errorMessage ?? prompt}: ";
            while (true) {
                string input = Console.ReadLine() ?? "";
                T converted;
                try {
                    converted = converter(input);
                } catch (Exception e) when (e is FormatException || e is ArgumentNullException || e is OverflowException)  {
                    GameController.renderer.DrawError(displayErrorMessage);
                    continue;
                }

                if (validate != null && !validate(converted))
                    GameController.renderer.DrawError(displayErrorMessage);
                    
                return converted;
            }
        }

        public static Action ReadKey() {
            ConsoleKey inputKey;
            do {
                inputKey = Console.ReadKey(true).Key;
            } while (!keybindings.ContainsKey(inputKey));
            return keybindings[inputKey];
        }

        private static readonly Dictionary<ConsoleKey, Action> keybindings = new() {
            { ConsoleKey.LeftArrow , Action.Left }, { ConsoleKey.A , Action.Left },
            { ConsoleKey.RightArrow , Action.Right}, { ConsoleKey.D , Action.Right},
            { ConsoleKey.UpArrow , Action.Up }, { ConsoleKey.W , Action.Up },
            { ConsoleKey.DownArrow , Action.Down }, { ConsoleKey.S , Action.Down},
            { ConsoleKey.X, Action.PlaceX },
            { ConsoleKey.O, Action.PlaceO },
            { ConsoleKey.Spacebar, Action.Clear },
            { ConsoleKey.Escape, Action.Exit }
        };
    }
}
