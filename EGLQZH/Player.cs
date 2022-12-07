using System.Text.Json.Serialization;

namespace TicTacToe {
    class Player {
        public int Score { get; set; }
        public string Name { get; private set; }

        private CellState _team;
        [JsonIgnore]
        public CellState Team {
            get => _team;
            set {
                if (value == CellState.Empty)
                    throw new InvalidOperationException("Cannot set player team to empty!");

                _team = value;
            }
        }

        public Player(string name, CellState team, int score = 0) {
            Name = name;
            Score = score;

            _team = team;
        }

        public void TakeTurn() {
            Board board = GameController.board;
            board.PlaceItem(Team);
        }
    }
}
