using ConsoleLibrary;

namespace HuntingTheManticore {
    public enum GameState { Going, ManticoreWon, CityWon }

    public class Game {
        private const int maxDistanceFromCity = 100;
        private readonly Manticore manticore;
        private readonly Entity city;
        private int currentRound = 1;
        private int CurrentRoundDamage {
            get {
                if (currentRound % 3 == 0 && currentRound % 5 == 0) return 10;
                else if (currentRound % 3 == 0 || currentRound % 5 == 0) return 3;
                else return 1;
            }
        }

        private GameState _currentState = GameState.Going;

        public Game(int cityHealth, int manticoreHealth) {
            Random random = new();

            manticore = new(manticoreHealth, random.Next(maxDistanceFromCity + 1));
            city = new(cityHealth);
        }

        public void StartGame() {
            ConsoleHelper.WriteLineColor("The game's started!", ConsoleColor.Green);

            while (_currentState == GameState.Going) RunGameRound();

            End();
        }

        public void End() { 
            if (_currentState == GameState.CityWon)
                ConsoleHelper.WriteLineColor("The Manticore has been destroyed! The city of Consolas has been saved!", ConsoleColor.Green);
            else if (_currentState == GameState.ManticoreWon)
                ConsoleHelper.WriteLineColor("The city of Consolas was destroyed under the ominous thread of the Manticore. The hope is lost...", ConsoleColor.Red);
        }

        /// <summary>
        /// Returns true if game is ended (win/lose)
        /// </summary>
        /// <returns></returns>
        private void RunGameRound() {
            Console.WriteLine($@"-----------------------------------------------------------
STATUS: Round: {currentRound} City: {city.Health}/{city.MaxHealth} Manticore: {manticore.Health}/{manticore.MaxHealth}
The cannon is expected to deal {CurrentRoundDamage} damage this round.");


            int cannonRange = ConsoleHelper.GetInt("Enter desired cannon range: ", 0, maxDistanceFromCity);

            if (cannonRange < manticore.DistanceFromTheCity) ConsoleHelper.WriteLineColor("That round FELL SHORT of the target.", ConsoleColor.Red);
            else if (cannonRange > manticore.DistanceFromTheCity) ConsoleHelper.WriteLineColor("That round OVERSHOT the target.", ConsoleColor.Red);
            else if (cannonRange == manticore.DistanceFromTheCity) {
                ConsoleHelper.WriteLineColor("That round was a DIRECT HIT!", ConsoleColor.Green);
                manticore.Damage(CurrentRoundDamage);
            }

            if (manticore.IsAlive) city.Damage(1);

            if (!manticore.IsAlive) {
                _currentState = GameState.CityWon;
            } else if (!city.IsAlive) {
                _currentState = GameState.ManticoreWon;
            } else {
                currentRound++;
            }
        }
    }
}