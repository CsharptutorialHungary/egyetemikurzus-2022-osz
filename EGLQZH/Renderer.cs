using Utilities;
using TicTacToe.ConsoleHelpers;

namespace TicTacToe {
    interface IRenderer {
        void SetBoard(Board board);
        void DrawCell(Cell cell);
        void DrawBoard();
        void DrawError(string message);
        void DrawGreeting(string message);
    }

    class ConsoleRenderer : IRenderer {
        public ConsoleRenderer() {
            // Init console window
            //Console.WindowWidth = 120;
            //Console.WindowHeight = 30;
            Console.CursorVisible = false;
        }

        public void SetBoard(Board board) {
            Board = board;
            offset = new Vector(
                0,
                (Console.WindowWidth - (Board.Size * cellDimensions.Col + Board.Size + 1)) / 2
            );
        }

        public void DrawCell(Cell cell) {
            Vector start = cell.Position * (cellDimensions + 1) + offset;
            Console.SetCursorPosition(start.Col, start.Row);

            SetBorderColors(cell);
            Console.Write(horizontalBorder);

            var shape = shapes[cell.State];
            for (int i = 0; i < cellDimensions.Row; i++) {
                Console.SetCursorPosition(start.Col, start.Row + i + 1);
                Console.Write("|"); // Vertical border

                Console.ForegroundColor = shape.Color; // Set shape color
                Console.Write(shape.Rows[i]);

                SetBorderColors(cell);
                Console.Write("|");
            }
            Console.SetCursorPosition(start.Col, start.Row + cellDimensions.Row + 1);
            Console.Write(horizontalBorder);
        }

        public void DrawBoard() {
            Console.Clear();
            foreach (Cell cell in Board.Cells) {
                DrawCell(cell);
            }
        }

        /// Message should contain a \n if line break is needed
        public void DrawError(string message) {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ForegroundColor = prevColor;
        }

        public void DrawGreeting(string message) {
            ConsoleColor prevColor = Console.ForegroundColor;
            var prevPosition = Console.GetCursorPosition();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            foreach (char character in message) {
                Console.Write(character);
                Thread.Sleep(20);
            }

            // Restore previous values
            Console.SetCursorPosition(prevPosition.Left, prevPosition.Top);
            Console.ForegroundColor = prevColor;
        }

        private static void SetBorderColors(Cell cell) {
            // When setting the bg and fg color it only applies to the consequent characters
            Console.ForegroundColor = cell.Selected ? ConsoleColor.Green : ConsoleColor.White;
        }

        static ConsoleRenderer() {
            // Add paddings to the shapes with respect to the cell's dimensions
            // Assuming same length for all rows
            int padColsLen = (cellDimensions.Col - shapes[CellState.Empty].Rows[0].Length) / 2;
            string padCols = new string(' ', padColsLen);

            foreach (var (_, shape) in shapes) {
                for (int i = 0; i < shape.Rows.Length; i++) {
                    shape.Rows[i] = padCols + shape.Rows[i] + padCols;
                }
            }
        }

        Board Board { get; set; }
        Vector offset;
        private static readonly Vector cellDimensions = new(4, 8);
        // Relates states to shapes
        private readonly static Dictionary<CellState, Shape> shapes = new() {
            { CellState.X, new Shape(
                new string[] { "\\  /", " \\/ ", " /\\ ", "/  \\" },
                ConsoleColor.Red) },
            { CellState.O, new Shape(
                new string[] { " -- ", "|  |", "|  |", " -- " },
                ConsoleColor.Green) },
            { CellState.Empty, new Shape(
                new string[] { "    ", "    ", "    ", "    " },
                ConsoleColor.Gray)
            }
        };

        private static readonly string horizontalBorder = "+" + new string('-', cellDimensions.Col) + "+";

        struct Shape {
            // Each row of the shape that is written to the console
            public string[] Rows;
            public ConsoleColor Color;

            public Shape(string[] rows, ConsoleColor color) {
                Rows = rows;
                Color = color;
            }
        }
    }
}
