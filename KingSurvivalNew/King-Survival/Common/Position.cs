using KingSurvival.Board.Contracts;
using KingSurvival.Common.Contracts;

namespace KingSurvival.Common
{
    using System;
    //TODO:made it to class maybe later
    public class Position:IPosition
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
