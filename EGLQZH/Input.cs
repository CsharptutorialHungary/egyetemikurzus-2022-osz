namespace TicTacToe {
    static class Input {
        public enum Action {
            MoveLeft, MoveRight, MoveUp, MoveDown,
            PlaceMark,
            PlayAgain, Exit
        }

        private static T ReadBase<T>(Converter<string, T> converter, Predicate<T>? validate = null) {
            string input = Console.ReadLine() ?? "";
            T converted;
            try {
                converted = converter(input);
            } catch (Exception e) when (e is FormatException || e is ArgumentNullException || e is OverflowException) {
                throw new FormatException();
            }

            if (validate != null && !validate(converted))
                throw new InvalidDataException();

            return converted;
        }
        public static T Read<T>(string prompt, Converter<string, T> converter, string? errorMessage = null, Predicate<T>? validate = null) {
            renderer.DrawPrompt(prompt);

            while (true) {
                try {
                    T read = ReadBase(converter, validate);
                    return read;
                } catch (Exception e) when (e is FormatException || e is InvalidDataException) {
                    renderer.DrawPrompt(prompt);
                    if (errorMessage != null)
                        renderer.DrawError(errorMessage);
                }   
            }
        }
        public static int Select<T>(string prompt, IEnumerable<T> options) {
            renderer.DrawOptionsPrompt(prompt, options);
            while (true) {
                try {
                    int selection = ReadBase(
                        converter: int.Parse,
                        n => n >= 0 && n < options.Count());
                    return selection;
                } catch (Exception e) when (e is FormatException || e is InvalidDataException) {
                    renderer.DrawError("Please enter a number from the available options!");
                }
            }
        }


        public static Action ReadKey(params Action[] validActions) {
            ConsoleKey inputKey;

            while (true) {
                inputKey = Console.ReadKey(true).Key;
                if (!keybindings.ContainsKey(inputKey)) continue;

                var action = keybindings[inputKey];
                if (validActions.Length > 0 && !validActions.Contains(action)) continue;

                break;
            }

            return keybindings[inputKey];
        }

        public static void WaitKey(ConsoleKey key) {
            while (true) {
                ConsoleKey readKey = Console.ReadKey(true).Key;
                if (readKey == key)
                    return;
            }
        }

        private static readonly IRenderer renderer = GameController.renderer;
        private static readonly Dictionary<ConsoleKey, Action> keybindings = new() {
            { ConsoleKey.LeftArrow , Action.MoveLeft }, { ConsoleKey.A , Action.MoveLeft },
            { ConsoleKey.RightArrow , Action.MoveRight}, { ConsoleKey.D , Action.MoveRight},
            { ConsoleKey.UpArrow , Action.MoveUp }, { ConsoleKey.W , Action.MoveUp },
            { ConsoleKey.DownArrow , Action.MoveDown }, { ConsoleKey.S , Action.MoveDown},
            { ConsoleKey.Enter, Action.PlaceMark },
            { ConsoleKey.R, Action.PlayAgain },
            { ConsoleKey.E, Action.Exit },
        };
    }
}
