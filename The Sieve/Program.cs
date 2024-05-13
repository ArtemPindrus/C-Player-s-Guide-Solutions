namespace The_Sieve {
    internal class Program {
        static void Main() {
            Console.WriteLine(@"Available number filters:
1. Even numbers
2. Positive numbers
3. Multiples of 10
");

            int choice = GetIntFromUser("Enter your choice: ", 1, 3);
            Console.Clear();

            Predicate<int> filter = choice switch {
                1 => IsEven,
                2 => IsPositive,
                3 => MultipleOf10,
                _ => throw new ArgumentOutOfRangeException(),
            };

            Sieve sieve = new(filter);

            while (true) {
                int number = GetIntFromUser("Enter a number to check in a sieve: ");
                Console.WriteLine(sieve.IsGood(number));
            }
        }

        private static bool IsEven(int number) => number % 2 == 0;
        private static bool IsPositive(int number) => number >= 0;
        private static bool MultipleOf10(int number) => number % 10 == 0;
    }
}