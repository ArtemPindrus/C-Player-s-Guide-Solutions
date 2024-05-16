using ConsoleLibrary;

namespace RockPaperScissors {
    public enum GameObject {
        Rock, Paper, Scissors
    }

    public class RockPaperScissorsGame {
        private readonly Player _player1;
        private readonly Player _player2;


        public RockPaperScissorsGame(Player player1, Player player2) {
            _player1 = player1;
            _player2 = player2;
        }

        public void PlayRound() {
            GameObject choice1 = GetChoice(_player1);
            GameObject choice2 = GetChoice(_player2);

            Console.WriteLine(@$"The choices are:
{_player1.Name}: {choice1}
{_player2.Name}: {choice2}
");

            Player? winner = EvaluateWinner(choice1, choice2);
            if (winner == null) ConsoleHelper.WriteLineColor("Draw!", ConsoleColor.Yellow);
            else {
                ConsoleHelper.WriteLineColor($"The winner is {winner.Name}!", ConsoleColor.Green);
                winner.Win();
            }
        }

        private static GameObject GetChoice(Player player) {
            Console.WriteLine(@"Available choices:
1. Rock
2. Paper
3. Scissors
");

            int choice = ConsoleHelper.GetInt($"{player.Name} make your choice: ", 1, 3);
            Console.Clear();

            return (GameObject) choice - 1;
        }

        private Player? EvaluateWinner(GameObject choice1, GameObject choice2) {
            return (choice1, choice2) switch {
                (GameObject.Rock, GameObject.Scissors) => _player1,
                (GameObject.Scissors, GameObject.Paper) => _player1,
                (GameObject.Paper, GameObject.Rock) => _player1,
                (GameObject first, GameObject second) when first == second => null,
                _ => _player2
            };
        }

        public string GetScores() => $"{_player1}\n{_player2}";
    }
}