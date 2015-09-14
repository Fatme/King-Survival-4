using System;
namespace KingSurvival.Common
{
    public struct Position
    {
        public Position(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static void CheckIfValid(Position position)
        {

            if (position.Row < Constants.MinimumRowValueOnBoard
                || position.Row > Constants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected row position on the board is not valid!");
            }

            if (position.Col < Constants.MinimumColumnValueOnBoard
                || position.Col > Constants.MaximumColumnValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected column position on the board is not valid!");
            }
        }
        public int Row { get; private set; }

        public int Col { get; private set; }

    }
}
