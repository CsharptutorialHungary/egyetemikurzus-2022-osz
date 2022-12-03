namespace TicTacToe {
    sealed class Board {
        public int Size { get; init; }
        public Cell[,] Cells { get; private set; }

        public Board(int size) {
            Size = size;
            Cells = new Cell[size, size];

            // Populate array with cells
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    Cells[i, j] = new Cell(i, j);
                }
            }
        }

        public Cell this[int row, int col] {
            get { return Cells[row, col]; }
        }
    }
}
