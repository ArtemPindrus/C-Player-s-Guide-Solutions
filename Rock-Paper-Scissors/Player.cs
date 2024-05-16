namespace RockPaperScissors {
    public class Player {
        public string Name { get; }

        public int Wins { get; private set; }

        public Player(string name) {
            Name = name;
        }

        public void Win() {
            Wins++;
        }

        public override string ToString() => $"{Name}: {Wins}";
    }
}