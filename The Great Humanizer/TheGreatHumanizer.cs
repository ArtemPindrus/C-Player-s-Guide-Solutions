namespace TheGreatHumanizer {
    using Humanizer;
    internal class TheGreatHumanizer {
        static void Main() {
            DateTime feastTime = DateTime.UtcNow.AddHours(60);
            Console.WriteLine("Where is the feast? "+feastTime.Humanize(true));
        }
    }
}