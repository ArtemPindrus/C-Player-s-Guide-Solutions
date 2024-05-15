using ConsoleLibrary;

namespace TicTacToeGame {
    internal class Program {
        static void Main() {
            int size = ConsoleHelper.GetInt("What's the board size?: ", 3, 10);
            int winLength = ConsoleHelper.GetInt("What's the winning length?: ", 3, size);
            Console.Clear();

            TicTacToeGame game = new(size, winLength);
            game.StartRound();

            while (ConsoleHelper.AskForConfirmation()) {
                Console.Clear();
                game.StartRound();
            }

            Console.Clear();
            Console.WriteLine($"Results:\nX wins: {game.XWins}\nO wins: {game.OWins}");
        }
    }
}