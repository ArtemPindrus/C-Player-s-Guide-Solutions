namespace Vector {
    public readonly struct Vector2 {
        public static readonly Vector2 Up = new(0, 1);
        public static readonly Vector2 Down = new(0, -1);
        public static readonly Vector2 Right = new(1, 0);
        public static readonly Vector2 Left = new(-1, 0);
        public static readonly Vector2 UpRight = new(1,1);
        public static readonly Vector2 UpLeft = new(-1, 1);
        public static readonly Vector2 DownRight = new(1, -1);
        public static readonly Vector2 DownLeft = new(-1, -1);

        public static readonly Vector2[] AllDirections = [Up, Down, Right, Left, UpRight, UpLeft, DownRight, DownLeft];

        public readonly int X;
        public readonly int Y;
        public Vector2(int x, int y) {
            X = x;
            Y = y;
        }

        public Vector2(int xy) {
            X = xy;
            Y = xy;
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs) => lhs.X == rhs.X && lhs.Y == rhs.Y;

        public static bool operator !=(Vector2 lhs, Vector2 rhs) => !(lhs == rhs);

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs) => new(lhs.X + rhs.X, lhs.Y + rhs.Y);
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs) => new(lhs.X - rhs.X, lhs.Y - rhs.Y);

        public override bool Equals(object? obj) {
            return obj is Vector2 v && v.X == X && v.Y == Y;
        }

        public override int GetHashCode() => X * 12 + Y * 12;

        public override string ToString() => $"({X}, {Y})";
    }
}
