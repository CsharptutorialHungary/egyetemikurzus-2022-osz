namespace TicTacToe {
    static class Input {
        public enum Action {
            Left, Right, Up, Down,
            Place, Exit
        }
        public static T Read<T>(string prompt, Converter<string, T> converter, string? errorMessage = null, Predicate<T>? validate = null) {
            GameController.renderer.DrawPrompt(prompt);

            while (true) {
                string input = Console.ReadLine() ?? "";
                T converted;
                try {
                    converted = converter(input);
                } catch (Exception e) when (e is FormatException || e is ArgumentNullException || e is OverflowException)  {
                    if (errorMessage != null) {
                        GameController.renderer.DrawPrompt(prompt);
                        GameController.renderer.DrawError(errorMessage);
                    }
                    continue;
                }

                if (validate != null && !validate(converted)) {
                    if (errorMessage != null) {
                        GameController.renderer.DrawPrompt(prompt);
                        GameController.renderer.DrawError(errorMessage);
                    }
                    continue;
                }
                    
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
            { ConsoleKey.Enter, Action.Place },
            { ConsoleKey.Escape, Action.Exit }
        };
    }
}
