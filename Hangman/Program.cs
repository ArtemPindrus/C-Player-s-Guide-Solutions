using ConsoleLibrary;

namespace HangmanGame {
    internal class Program {
        static void Main() {
            HangmanGame game = new(@"C:\Users\Артем\Downloads\Words.txt", 10, 3);
            game.StartRound();

            while (ConsoleHelper.AskForConfirmation()) {
                Console.Clear();
                game.StartRound();
            }

            Console.Clear();
            Console.WriteLine($"Results:\n{game.GetScores()}");
        }
    }
}