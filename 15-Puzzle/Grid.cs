using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpPlayersGuide.GameOfFifteen {
    public enum Direction { Left, Right, Up, Down }

    public class Grid {
        private const int emptyCellInt = -1;
        private readonly int order;
        private readonly int[,] _internalGrid;
        private Vector2 EmptyCell {
            get {
                for (int r = 0; r < order; r++) {
                    for (int c = 0; c < order; c++) {
                        if (_internalGrid[r, c] == emptyCellInt) return new(c, r);
                    }
                }

                throw new Exception("Empty cell doesn't exist");
            }
            set {
                _internalGrid[value.Y, value.X] = emptyCellInt;
            }
        }

        private int this[Vector2 v] { 
            get => _internalGrid[v.Y, v.X];
            set => _internalGrid[v.Y, v.X] = value;
        } 

        public bool GridIsInAscendingOrder {
            get {
                int previous = 0;

                for (int r = 0; r < order; r++) {
                    for (int c = 0; c < order; c++) {
                        int temp = _internalGrid[r, c];

                        if (previous == temp - 1) previous = temp;
                        else if ((r, c) == (order - 1, order - 1)) return true;
                        else return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order">The amount of rows and columns of a grid</param>
        public Grid(int order) {
            _internalGrid = new int[order, order];
            this.order = order;

            EmptyCell = new(Random.Shared.Next(order), Random.Shared.Next(order));

            //populate internalGrid
            List<int> availableNums = new(Enumerable.Range(1, order * order - 1));

            for (int r = 0; r < order; r++) {
                for (int c = 0; c < order; c++) {
                    if (new Vector2(c, r) != EmptyCell) {
                        int randomIndex = Random.Shared.Next(availableNums.Count);

                        _internalGrid[r, c] = availableNums[randomIndex];
                        availableNums.RemoveAt(randomIndex);
                    }
                }
            }
        }

        public void ShiftNumbers(Direction direction) {
            Vector2 movingCell = EmptyCell - direction;
            if (movingCell.X >= 0 && movingCell.X < order 
                && movingCell.Y >= 0 && movingCell.Y < order) {
                this[EmptyCell] = this[movingCell];
                EmptyCell = movingCell;
            }
        }

        public override string ToString() {
            StringBuilder builder = new();

            for (int r = 0; r < order; r++) {
                for (int c = 0; c < order; c++) {
                    if (_internalGrid[r, c] != emptyCellInt) {
                        bool twoDigits = _internalGrid[r, c] >= 10;
                        if (!twoDigits) builder.Append(' ');

                        builder.Append($"{_internalGrid[r, c]}");
                    } else builder.Append(" X");

                   
                    if (c == order - 1) builder.Append('\n');
                    else builder.Append(", ");
                }
            }

            return builder.ToString();
        }
    }
}
