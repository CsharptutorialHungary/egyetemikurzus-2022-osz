using Utilities;

namespace TicTacToe {
    enum CellState {
        Empty, X, O
    }

    sealed class Cell {
        public bool Selected {
            get => _selected;
            set {
                if (_selected != value) {
                    _selected = value;
                    GameController.renderer.DrawCell(this);
                }
            }
        }
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

        private bool _selected = false;
        private CellState _state = CellState.Empty;
    }
}
