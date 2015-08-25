﻿namespace KingSurvival.Common
{
    public struct Position
    {
        public Position(int row,int col):this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

    }
}
