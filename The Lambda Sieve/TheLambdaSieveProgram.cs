using ConsoleLibrary;

namespace TheLambdaSieve {
    internal class TheLambdaSieveProgram {
        static void Main() {
            LambdaSieve sieve = UserChooseSieve();

            while (true) {
                int number = ConsoleHelper.GetInt("Enter a number to check in a sieve: ");
                bool validness = sieve.IsGood(number);

                ConsoleColor color = validness ? ConsoleColor.Green : ConsoleColor.Red;
                ConsoleHelper.WriteLineColor(validness.ToString(), color);
            }
        }

        private static LambdaSieve UserChooseSieve() {
            Console.WriteLine(@"Available number filters:
1. Even numbers
2. Positive numbers
3. Multiples of 10
");

            int choice = ConsoleHelper.GetInt("Enter your choice: ", 1, 3);
            Console.Clear();

            return choice switch {
                1 => new(x => x % 2 == 0),
                2 => new(x => x >= 0),
                3 => new(x => x % 10 == 0),
                _ => throw new ArgumentException()
            };
        }
    }
}