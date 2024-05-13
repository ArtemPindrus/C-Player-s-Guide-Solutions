namespace ColoredItems {
    public class Item { }
    public class Sword : Item { }
    public class Bow : Item { }
    public class Axe : Item { }

    public class ColoredItem<T> where T : Item {
        public T Item { get; init; }
        public ConsoleColor Color { get; init; }

        public ColoredItem(T item, ConsoleColor associatedColor) {
            Item = item;
            Color = associatedColor;
        }

        public void Display() {
            Console.BackgroundColor = Color;
            Console.WriteLine(Item.ToString());
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}