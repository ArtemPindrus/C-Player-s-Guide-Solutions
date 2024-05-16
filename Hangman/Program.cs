using ConsoleLibrary;
using Hangman;

namespace HangmanGame {
    internal class Program {
        static void Main() {
            HangmanGame game = CreateValidGame();
            Console.Clear();

            game.StartRound();

            while (ConsoleHelper.AskForConfirmation()) {
                Console.Clear();
                game.StartRound();
            }

            Console.Clear();
            Console.WriteLine($"Results:\n{game.GetScores()}");
        }

        private static HangmanGame CreateValidGame() {
            while (true) {
                try {
                    ValidStringConstruct isPathToTxt = new(
                        x => File.Exists(x) && Path.GetExtension(x) == ".txt",
                        "Value doesn't point to existing .txt file!"
                    );
                    string path = ConsoleHelper.GetValidString("Enter the path to the .txt file with words: ", isPathToTxt);

                    return new(path, 10, 3);
                } catch (FileEmptyException e) {
                    ConsoleHelper.WriteLineColor(e.Message, ConsoleColor.Red);
                }
            }
        }
    }
}