namespace KingSurvival.Common
{
    using System;

    public struct Position
    {
        public Position(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static void CheckIfValid(Position position, string errorMessage)
        {

            if (position.Row < Constants.MinimumRowValueOnBoard
                || position.Row > Constants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }

            if (position.Col < Constants.MinimumColumnValueOnBoard
                || position.Col > Constants.MaximumColumnValueOnBoard)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }
        }
        public int Row { get; private set; }

        public int Col { get; private set; }

    }
}
