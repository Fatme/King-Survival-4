namespace KingSurvival.Common
{
    using KingSurvival.Common.Contracts;

    public class Position : IPosition
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }
    }
}
