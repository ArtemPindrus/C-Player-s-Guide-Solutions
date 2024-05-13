using ConsoleLibrary;

namespace TesteConH {
    internal class Program {
        static void Main() {
            if (ConsoleHelper.AskForConfirmation()) {
                Console.WriteLine("Hello");
            }
        }
    }
}
