using System.Runtime.CompilerServices;
using Utilities;

namespace TicTacToe {
    class Player {
        public int Score { get; private set; }
        public string Name { get; private set; }
        public CellState Team { get; private set; }

        public Player(string name, CellState team) {
            Name = name;
            Score = 0;

            if (team == CellState.Empty)
                throw new InvalidOperationException("A player's team cannot be 'CellState.Empty'");
            Team = team;
        }

        public void TakeTurn() {
            Board board = GameController.board;
            board.PlaceItem(Team);
        }
    }
}
