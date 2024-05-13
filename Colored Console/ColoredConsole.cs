namespace ColoredConsole {
    using ConsoleLibrary;
    internal class ColoredConsole {
        static void Main() {
            string name = ConsoleHelper.GetValidString("What is your name? ");
            ConsoleHelper.WriteLineColor("Hello " + name, ConsoleColor.Green);
        }
    }
}