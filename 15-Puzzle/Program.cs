using ConsoleLibrary;
using GameOfFifteen.Extensions;

namespace GameOfFifteen {
    internal class Program {
        static void Main() {
            GameOfFifteen game = new(3);
            game.StartGame();
        }
    }

    public class GameOfFifteen { 
        private readonly Grid grid;

        public GameOfFifteen(int order) {
            grid = new(order);
        }

        public void StartGame() {
            while (!grid.GridIsInAscendingOrder) {
                Console.WriteLine(grid);
                char key = ConsoleHelper.GetValidKey("Press W, A, S, D to shift numbers! ", true, false, 'w', 'a', 's', 'd');
                grid.ShiftNumbers(key.ToDirection());
                Console.Clear();
            }

            ConsoleHelper.WriteLineColor("Congrats, you've won!", ConsoleColor.Green);
        }
    }
}