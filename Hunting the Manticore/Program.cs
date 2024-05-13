namespace HuntingTheManticore {
    internal partial class Program {
        static void Main() {
            int cityHealth = 15;
            int manticoreHealth = 10;

            Game game = new(cityHealth, manticoreHealth);
            game.StartGame();
        }
    }
}