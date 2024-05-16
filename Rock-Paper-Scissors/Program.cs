using ConsoleLibrary;

namespace RockPaperScissors {
    public class Program {
        static void Main() {
            (string n1, string n2) = GetNames();

            RockPaperScissorsGame game = new(new(n1), new(n2));
            game.PlayRound();
            Console.WriteLine();

            while (ConsoleHelper.AskForConfirmation()) {
                Console.Clear();
                game.PlayRound();
                Console.WriteLine();
            }

            Console.Clear();
            Console.WriteLine("Final scores:\n"+game.GetScores());
        }

        private static (string, string) GetNames() {
            string? name1 = ConsoleHelper.GetValidString("Enter your name player 1: ");

            ValidStringConstruct notName1Cond = new(
                x => !x.Equals(name1, StringComparison.CurrentCultureIgnoreCase),
                "Name is already occupied by player 1!"
            );
            string? name2 = ConsoleHelper.GetValidString("Enter your name player 2: ", notName1Cond);

            Console.Clear();

            return (name1, name2);
        }
    }
}