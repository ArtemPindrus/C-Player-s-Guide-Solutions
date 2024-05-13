namespace TheColor {
    public class Program {
        public static void Main() {
            Color red = new(Color.PredefinedColors.Red);
            Console.WriteLine(red.ToString());

            Color blue = new(0, 0, 255);
            Console.WriteLine(blue.ToString());
        }
    }
}