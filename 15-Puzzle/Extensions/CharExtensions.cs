namespace GameOfFifteen.Extensions {
    public static class CharExtensions {
        public static Direction ToDirection(this char c) {
            return c switch {
                'w' => Direction.Down,
                's' => Direction.Up,
                'a' => Direction.Left,
                'd' => Direction.Right,
                _ => throw new ArgumentException("Direction isn't defined for given character.")
            };
        }
    }
}
