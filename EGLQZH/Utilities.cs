namespace Utilities {
    sealed class Vector {
        public int Row { get; set; }
        public int Col { get; set; }

        public Vector(int row, int col) {
            Row = row;
            Col = col;
        }

        public static Vector operator +(Vector left, Vector right)
            => new Vector(left.Row + right.Row, left.Col + right.Col);

        public static Vector operator +(Vector left, int number)
            => new Vector(left.Row + number, left.Col + number);

        public static Vector operator -(Vector left, Vector right)
            => new Vector(left.Row - right.Row, left.Col - right.Col);

        public static Vector operator -(Vector left, int number)
            => new Vector(left.Row - number, left.Col - number);

        public static Vector operator *(Vector left, Vector right)
            => new Vector(left.Row * right.Row, left.Col * right.Col);

        public static Vector operator *(Vector left, int number)
            => new Vector(left.Row * number, left.Col * number);
    }

    static class BooleanExtensions {
        public static int ToInt(this bool value) {
            return value ? 1 : 0;
        }
    }

    static class MathOperation {
        // In C# the % operator is not a modulo it's a remainder.
        public static int Mod(int x, int m) {
            int r = x % m;
            return r < 0 ? r + m : r;
        }
    }
}
