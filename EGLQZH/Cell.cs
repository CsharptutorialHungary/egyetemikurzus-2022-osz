using Utilities;

namespace TicTacToe {
    enum CellState {
        Empty, X, O
    }

    sealed record class Cell {
        public CellState State {
            get => _state;
            set {
                if (_state != value) {
                    _state = value;
                    GameController.renderer.DrawCell(this);
                }
            }
        }
        public Vector Position { get; init; }

        public Cell(int row, int col) {
            Position = new Vector(row, col);
        }

        public void AddNeighbour(Cell neighbour) {
            if (!this.IsNextTo(neighbour))
                return;

            if (!neighbours.Add(neighbour))
                throw new Exception("The neighbour is already present in the set!");
        }

        private bool IsNextTo(Cell other) {
            return Position.DistanceFrom(other.Position) == 1;
        }

        private CellState _state = CellState.Empty;
        private readonly HashSet<Cell> neighbours = new();
    }
}
