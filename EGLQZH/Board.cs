using Utilities;

namespace TicTacToe {
    sealed class Board {
        public const int size = 3;
        public Cell[,] Cells { get; private set; }
        public Cell? SelectedCell {
            get => _selectedCell;
            private set {
                Cell? prevCell = _selectedCell;
                _selectedCell = value;
                if (prevCell != null)
                    GameController.renderer.DrawCell(prevCell);

                if (value != null)
                    GameController.renderer.DrawCell(value);
            }
        }

        public bool IsInWinState { get; private set; }

        public Board() {
            Cells = new Cell[size, size];
            InitializeCells();

            SelectedCell = null;
        }

        public Cell this[int row, int col] {
            get { return Cells[row, col]; }
        }

        public void PlaceItem(CellState team) {
            if (SelectedCell == null)
                SelectedCell = Cells[0, 0];

            var (currRow, currCol) = SelectedCell.Position;

            while (true) {
                Input.Action action = Input.ReadKey();

                if (directions.ContainsKey(action)) {
                    currRow = MathOperation.Mod(currRow + directions[action].Row, size);
                    currCol = MathOperation.Mod(currCol + directions[action].Col, size);

                    SelectedCell = Cells[currRow, currCol];
                } else if (action == Input.Action.PlaceMark) {
                    if (SelectedCell.State != CellState.Empty) {
                        GameController.renderer.DrawError("The selected cell is occupied!");
                        continue;
                    }
                    SelectedCell.State = team;
                    CheckWinState();
                    return;
                }
            }
        }

        public void Reset() {
            SelectedCell = null;
            IsInWinState = false;
            foreach (var cell in Cells) {
                cell.State = CellState.Empty;
            }
        }

        private void CheckWinState() {
            if (SelectedCell == null) return;

            int row = 0, col = 0, diagonal = 0, reverseDiagonal = 0;
            CellState team = SelectedCell.State;
            for (int i = 0; i < size; i++) {
                if (Cells[i, SelectedCell.Position.Col].State == team) row++;
                if (Cells[SelectedCell.Position.Row, i].State == team) col++;
                if (Cells[i, i].State == team) diagonal++;
                if (Cells[i, (size - i - 1)].State == team) reverseDiagonal++;
            }

            IsInWinState = row == size || col == size || diagonal == size || reverseDiagonal == size;
        }

        private void InitializeCells() {
            CreateCells();
            AddNeighbours();
        }

        private void CreateCells() {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    Cells[i, j] = new Cell(i, j);
                }
            }
        }

        private void AddNeighbours() {
            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    for (int rowOffset = -1; rowOffset <= 1; rowOffset++) {
                        for (int colOffset = -1; colOffset <= 1; colOffset++) {
                            int neighbourRow = row + rowOffset;
                            int neighbourCol = col + colOffset;
                            if (!IsValidPosition(neighbourRow, neighbourCol))
                                continue;

                            Cells[row, col].AddNeighbour(Cells[neighbourRow, neighbourCol]);
                        }
                    }
                }
            }
        }

        private static bool IsValidPosition(int row, int col) {
            return row >= 0 && col >= 0 && row < size && col < size;
        }

        readonly Dictionary<Input.Action, (int Row, int Col)> directions = new()
        {
            { Input.Action.MoveLeft, (0, -1) },
            { Input.Action.MoveRight, (0, 1) },
            { Input.Action.MoveUp, (-1, 0) },
            { Input.Action.MoveDown, (1, 0) }
        };
        private Cell? _selectedCell = null;
    }
}
