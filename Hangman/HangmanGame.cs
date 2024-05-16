using ConsoleLibrary;
using System.Text;

namespace HangmanGame {
    class HangmanGame {
        private readonly List<string> _words;
        private readonly int _maxWrongGuesses;
        private int _wins;
        private int _loses;

        public HangmanGame(string pathToFileWithWords, int maxWrongGuesses, int minWordSize) {
            string fileText = File.ReadAllText(pathToFileWithWords);
            string fileTextNoPunct = string.Concat(fileText.Where(c => !char.IsPunctuation(c)));

            _words = new(fileTextNoPunct.Split(' ', StringSplitOptions.TrimEntries).Where(s => s.Length >= minWordSize));
            _maxWrongGuesses = maxWrongGuesses;
        }

        public void StartRound() {
            Console.WriteLine($"The game has started! \nMax wrong guesses: {_maxWrongGuesses}\n");

            int wrongGuesses = 0;
            string randomWord = PickUpRandomWord().ToLower();

            List<char> charactersToFind = new(randomWord.ToLower().Distinct());
            List<char> foundCharacters = [];
            List<char> incorrect = [];

            while (wrongGuesses < _maxWrongGuesses && foundCharacters.Count != randomWord.Length) {
                Console.Write($"Word: {GetWordCompletion(randomWord, foundCharacters)}");
                Console.Write($" | Remaining: {charactersToFind.Count} | Incorrect: {string.Join(' ', incorrect)} ({wrongGuesses}) | Guess: ");

                while (true) {
                    char choice = Console.ReadKey(true).KeyChar;

                    if (!char.IsLetter(choice) || incorrect.Contains(choice) || foundCharacters.Contains(choice)) continue;

                    if (!charactersToFind.Contains(choice)) {
                        incorrect.Add(choice);
                        wrongGuesses++;
                        Console.WriteLine(choice);

                        break;
                    } else { 
                        foundCharacters.Add(choice);
                        charactersToFind.Remove(choice);
                        Console.WriteLine(choice);

                        break;
                    }
                }
            }

            if (foundCharacters.Count == randomWord.Length) Win();
            else Lose(randomWord);
        }

        private void Lose(string word) {
            ConsoleHelper.WriteLineColor($"YOU HAVE LOST! The word was: {word}", ConsoleColor.Red);
            _loses++;
        }

        private void Win() {
            ConsoleHelper.WriteLineColor("You have won, congrats!", ConsoleColor.Green);
            _wins++;
        }

        private static string GetWordCompletion(string word, List<char> foundCharacters) {
            StringBuilder sb = new();

            foreach (var c in word) { 
                if (foundCharacters.Contains(c)) sb.Append(c);
                else sb.Append('_');
            }

            return sb.ToString();
        }

        private string PickUpRandomWord() { 
            Random random = new();

            int randomIndex = random.Next(_words.Count);
            return _words[randomIndex];
        }

        public string GetScores() => $"Wins: {_wins}\nLoses: {_loses}";
    }
}