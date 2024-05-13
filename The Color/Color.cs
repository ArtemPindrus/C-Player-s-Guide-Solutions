namespace TheColor {
    public class Color {
        public enum PredefinedColors {
            White, Black, Red, Orange, Yellow, Green, Blue, Purple
        }

        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        public Color(PredefinedColors color) {
            if (color == PredefinedColors.White) {
                R = 255;
                G = 255;
                B = 255;
            } else if (color == PredefinedColors.Black) {
                R = 0;
                G = 0;
                B = 0;
            } else if (color == PredefinedColors.Red) {
                R = 255;
                G = 0;
                B = 0;
            } else if (color == PredefinedColors.Orange) {
                R = 255;
                G = 165;
                B = 0;
            } else if (color == PredefinedColors.Yellow) {
                R = 255;
                G = 255;
                B = 0;
            } else if (color == PredefinedColors.Red) {
                R = 0;
                G = 128;
                B = 0;
            } else if (color == PredefinedColors.Blue) {
                R = 0;
                G = 0;
                B = 255;
            } else if (color == PredefinedColors.Purple) {
                R = 128;
                G = 0;
                B = 128;
            }
        }
        public Color(byte R, byte G, byte B) {
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public override string ToString() {
            return $"({R}, {G}, {B})";
        }
    }
}