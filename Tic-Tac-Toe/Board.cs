using System.Text;
using Vector;

namespace TicTacToeGame {
    public enum GameObject { Empty, X, O }

    public class Board {
        private const GameObject FirstMoveSign = GameObject.X;

        private readonly GameObject[,] _grid;
        private readonly Vector2[] _gridPositions;
        private readonly int _boardSize;
        private readonly int _winningLength;
        private readonly int _paddingForCellNumber;
        private GameObject? _previousSign = null;

        private GameObject this[Vector2 v] {
            get => _grid[v.Y, v.X];
            set => _grid[v.Y, v.X] = value;
            
        }

        /// <summary>
        /// Is the board filled with signs
        /// </summary>
        public bool IsFilled {
            get {
                foreach (var go in _grid) {
                    if (go == GameObject.Empty) return false;
                }

                return true;
            }
        }

        public int GreatestCellNumber => _gridPositions.Length;


        public GameObject CurrentSign => _previousSign switch {
            null => FirstMoveSign,
            GameObject.X => GameObject.O,
            GameObject.O => GameObject.X,
            _ => throw new Exception("I'm an idiot."),
        };

        public Board(int boardSize, int winningLength) {
            if (winningLength > boardSize) throw new ArgumentException($"{nameof(winningLength)} cannot be greater then {nameof(boardSize)}");
            if (winningLength <= 0) throw new ArgumentException($"{nameof(winningLength)} cannot be 0 or less");
            if (boardSize > 10) throw new ArgumentException($"{nameof(boardSize)} cannot be greater then 10");

            _grid = new GameObject[boardSize, boardSize];
            _boardSize = boardSize;
            _winningLength = winningLength;

            _gridPositions = new Vector2[_boardSize*_boardSize];
            int ind = 0;

            while (ind < _gridPositions.Length) {
                for (int r = 0; r < _boardSize; r++) {
                    for (int c = 0; c < _boardSize; c++) {
                        _gridPositions[ind] = new(c, r);
                        ind++;
                    }
                }
            }

            _paddingForCellNumber = _gridPositions.Length.ToString().Length;
        }

        public string ToString(bool numberCells = true) { 
            StringBuilder sb = new();

            int iteration = 0;
            for (int r = 0; r < _boardSize; r++) {
                for (int c = 0; c < _boardSize; c++) {
                    string appendant = _grid[r,c] == GameObject.Empty ? 
                        numberCells ? (r * _boardSize + c + 1).ToString() : " "
                        : _grid[r,c].ToString();

                    if (_paddingForCellNumber == 1) sb.Append($" {appendant, 1} ");
                    else if (_paddingForCellNumber == 2) sb.Append($" {appendant, 2} ");
                    else if (_paddingForCellNumber == 3) sb.Append($" {appendant, 3} ");

                    sb.Append(c == _boardSize - 1 ? "\n" : "|");
                    iteration++;
                }

                if (r != _boardSize - 1) sb.Append(new string('-', (2 + _paddingForCellNumber) * _boardSize + _boardSize - 1)+"\n");
            }

            return sb.ToString();
        }

        public bool SetSign(Vector2 placement) {
            if (this[placement] != GameObject.Empty) return false;

            this[placement] = CurrentSign;
            _previousSign = CurrentSign;

            return true;
        }

        /// <summary>
        /// Set's sign on position defined by cell number. ToString(true) gives representetion of string numbering.
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public bool SetSign(int cellNumber) {
            Vector2 position = _gridPositions[cellNumber - 1];

            return SetSign(position);
        }

        public bool CheckForRow(out GameObject? winner) {
            winner = null;
            foreach (var position in _gridPositions) {
                foreach (var direction in Vector2.AllDirections) {
                    if (CheckForRowInADirection(position, direction, out winner)) return true;
                }
            }

            return false;

            //internal fncs
            bool CheckForRowInADirection(Vector2 start, Vector2 direction, out GameObject? winner) {
                Vector2 currentPos = start;
                GameObject objectAtStart = this[currentPos];
                if (objectAtStart == GameObject.Empty) {
                    winner = null;
                    return false;
                }

                int counts = 1;
                Vector2 next = currentPos + direction;
                while (next.X < _boardSize && next.Y < _boardSize 
                    && next.Y >= 0 && next.X >= 0
                    && counts < _winningLength) {
                    if (this[next] == objectAtStart) {
                        counts++;
                        next += direction;
                    } else break;
                }

                if (counts == _winningLength) {
                    winner = objectAtStart;
                    return true;
                } else {
                    winner = null;
                    return false;
                }
            }
        }
    }
}
