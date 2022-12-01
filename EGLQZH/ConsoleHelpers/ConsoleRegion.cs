using Utilities;

namespace TicTacToe.ConsoleHelpers {
    enum Justify {
        TopLeft, TopMiddle, TopRight,
        CenterLeft, CenterMiddle, CenterRight,
        BottomLeft, BottomMiddle, BottomRight
    }

    sealed class ConsoleRegion {
        public Vector Position { get; init; }
        public Vector Size { get; init; }
        public Justify Alignment { get; init; }
        public bool HasBorder { get; set; }

        public ConsoleRegion(int row, int col, int width, int height, Justify alignment = Justify.TopLeft, bool border = false) {
            if (row < 0 || height < 0 || col < 0 || width < 0 || row + height > Console.WindowHeight || col + width > Console.WindowWidth)
                throw new ArgumentOutOfRangeException("The region parameters are out of the valid range of the console window");

            Position = new Vector(row, col);
            Size = new Vector(height, width);
            Alignment = alignment;

            buffer = new();
            HasBorder = border;
        }

        public void Write(string text, ConsoleColor? color = null) {
            // If the buffer is empty then create a row
            if (buffer.Count == 0)
                buffer.Add(new());

            // Add the text to the last row
            buffer.Last().Add(new(text, color));
        }

        public void WriteLine(string text, ConsoleColor? color = null) {
            Write(text, color);
            // Start new row in the buffer
            buffer.Add(new());
        }

        public void Clear() {
            string spaces = new string(' ', Size.Col);
            for (int i = 0; i < Size.Row; i++) {
                Console.SetCursorPosition(Position.Col, Position.Row + i);
                Console.Write(spaces);
            }
        }

        public void ClearBuffer() => buffer.Clear();

        public void Flush() {
            ConsoleColor prevColor = Console.ForegroundColor;
            var prevPosition = Console.GetCursorPosition();

            Clear();

            // Add row padding
            int rowPadding = Math.Max((int)((Size.Row - buffer.Count) * multiplier[Alignment].Row), 0);
            string rowPad = new string(' ', Size.Col);
            for (int i = 0; i < rowPadding; i++) {
                Console.SetCursorPosition(Position.Col, Position.Row + i + HasBorder.ToInt());
                Console.Write(rowPad);
            }

            // Cut the overflowing rows according to the alignment
            // Eg.: If the alignment is MiddleLeft cut half of the top rows and half of the bottom rows
            int heightOverflow = Math.Max(buffer.Count - Size.Row, 0);
            int topOffset = (int)(heightOverflow * multiplier[Alignment].Row);
            int bottomOffset = heightOverflow - topOffset;
            for (int i = topOffset; i < buffer.Count - bottomOffset; i++) {
                var row = buffer[i];
                if (row.Count == 0)
                    continue;
                
                Console.SetCursorPosition(Position.Col, Position.Row + rowPadding - topOffset + i);
                // Add column padding
                int rowLength = row.Aggregate(0, (aggregate, next) => aggregate += next.text.Length);
                int colPadding = Math.Max((int)((Size.Col - rowLength) * multiplier[Alignment].Col), 0);
                string colPad = new string(' ', colPadding);
                Console.Write(colPad);

                int widthOverflow = Math.Max(rowLength - Size.Col, 0);
                int leftOffset = (int)(widthOverflow * multiplier[Alignment].Col);
                // Write buffer
                foreach (var (text, color) in row) {
                    Console.ForegroundColor = color ?? Console.ForegroundColor;
                    Console.Write(text.Substring(leftOffset, Math.Min(Size.Col, text.Length)));
                }
            }

            Console.ForegroundColor = prevColor;
            Console.SetCursorPosition(prevPosition.Left, prevPosition.Top);
        }

        private void DrawBorder() {

        }

        private List<List<BufferItem>> buffer;
        private static readonly Dictionary<Justify, (double Row, double Col)> multiplier = new() {
            { Justify.TopLeft, (0, 0) },
            { Justify.TopMiddle, (0, .5) },
            { Justify.TopRight, (0, 1) },
            { Justify.CenterLeft, (.5, 0) },
            { Justify.CenterMiddle, (.5, .5) },
            { Justify.CenterRight, (.5, 1) },
            { Justify.BottomLeft, (1, 0) },
            { Justify.BottomMiddle, (1, .5) },
            { Justify.BottomRight, (1, 1) },
        };

        struct BufferItem {
            public string text;
            public ConsoleColor? color;

            public BufferItem(string text, ConsoleColor? color) {
                this.text = text;
                this.color = color;
            }

            public void Deconstruct(out string text, out ConsoleColor? color) {
                text = this.text;
                color = this.color;
            }
        }
    }
}
