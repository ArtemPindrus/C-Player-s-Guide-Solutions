namespace ConsoleLibrary {
    public readonly record struct ValidStringConstruct(Predicate<string> ConditionToMeet, string? ErrorPrompt = null);

    public class ConsoleHelper {
        /// <summary>
        /// Prompts user to enter a string until it matches a given ValidStringConsruct[] predicates
        /// </summary>
        /// <param name="prompt">Prompt to user</param>
        /// <param name="validStrings"></param>
        /// <returns>String that matches all the predicates and is not null or empty</returns>
        public static string GetValidString(string prompt, params ValidStringConstruct[] validStrings) {
            string? response;

            while (true) {
                Console.Write(prompt);
                response = Console.ReadLine();

                if (string.IsNullOrEmpty(response)) {
                    WriteLineColor("Error! Empty string!", ConsoleColor.Red);
                    continue;
                }

                if (CheckConditions()) break;
            }

            return response;

            bool CheckConditions() {
                foreach (var condition in validStrings) {
                    if (!condition.ConditionToMeet(response)) {
                        if (condition.ErrorPrompt != null) WriteLineColor(condition.ErrorPrompt, ConsoleColor.Red);
                        return false;
                    }
                }

                return true;
            }
        }

        public static char GetValidKey(string prompt, bool intercept, bool errorPrompt, params char[] validChars) {
            Console.Write(prompt);
            char key = Console.ReadKey(intercept).KeyChar;

            while (!validChars.Contains(key)) {
                key = Console.ReadKey(intercept).KeyChar;
                if (errorPrompt) {
                    WriteLineColor($"Error! Keys: {string.Join(", ", validChars)} - are expected", ConsoleColor.Red);
                    Console.Write(prompt);
                }
            }

            return key;
        }

        /// <summary>
        /// Prompts user to enter a string until it's an int in a range of [min, max]
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>int in a range [min, max] (inclusive!)</returns>
        public static int GetInt(string prompt, int min = int.MinValue, int max = int.MaxValue) {
            string valid = GetValidString(prompt, 
                new ValidStringConstruct(
                    x => int.TryParse(x, out int num) && num >= min && num <= max, 
                    $"Error! Number in [{min}, {max}] range is expected!"
                )
            );

            return int.Parse(valid);
        }

        /// <summary>
        /// Prompts user to enter "Y" or "N"
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>Return whether confirmed (Y)</returns>
        public static bool AskForConfirmation(string prompt = "Continue? ") {
            ValidStringConstruct valid = new(
                x => { 
                    string temp = x.ToLower();
                    return temp == "y" || temp == "n";
                },
                "Error! Y or N are expected"
            );

            string response = GetValidString(prompt, valid);
            return response == "y";
        }

        public static void WriteLineColor(string text, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteLineBGColor(string text, ConsoleColor color) {
            Console.BackgroundColor = color;
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void WriteColor(string text, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}