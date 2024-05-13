using ConsoleLibrary;

namespace ColoredItems {
    internal class Program {
        static void Main() {
            ColoredItem<Axe> axe = new(new(), ConsoleColor.Green);
            ColoredItem<Sword> sword = new(new(), ConsoleColor.Blue);
            ColoredItem<Bow> bow = new(new(), ConsoleColor.Red);


            DisplayColoredItem(axe);
            DisplayColoredItem(sword);
            DisplayColoredItem(bow);
        }

        private static void DisplayColoredItem<T>(ColoredItem<T> item) where T : Item {
            string? text = item.ToString();
            
            if (text != null) ConsoleHelper.WriteLineBGColor(text, item.Color);
        }
    }
}