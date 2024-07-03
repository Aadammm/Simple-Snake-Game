namespace Simply_Snake_Game
{    public struct Position(int row, int column)
    {
        public int Row { get; set; } = row;
        public int Column { get; set; } = column;

        public override readonly bool Equals(object? obj) =>
            obj is Position position &&
            Row == position.Row && Column == position.Column;
        public override readonly int GetHashCode() => Row ^ Column;

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
