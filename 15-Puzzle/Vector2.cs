namespace GameOfFifteen {
    public readonly struct Vector2 {
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

        public static Vector2 operator +(Vector2 lhs, Direction dir) {
            Vector2 addent = dir switch {
                Direction.Left => new(-1,0),
                Direction.Right => new(1,0),
                Direction.Up => new(0,1),
                Direction.Down => new(0,-1),
                _ => throw new ArgumentException("Cannot add given Direction to Vector2")
            };

            return lhs + addent;
        }
        public static Vector2 operator -(Vector2 lhs, Direction dir) {
            Vector2 addent = dir switch {
                Direction.Left => new(-1, 0),
                Direction.Right => new(1, 0),
                Direction.Up => new(0, 1),
                Direction.Down => new(0, -1),
                _ => throw new ArgumentException("Cannot add given Direction to Vector2")
            };

            return lhs - addent;
        }

        public override bool Equals(object? obj) {
            return obj is Vector2 v && v.X == X && v.Y == Y;
        }

        public override int GetHashCode() => X * 12 + Y * 12;
    }
}
