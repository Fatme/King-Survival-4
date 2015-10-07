namespace KingSurvival.Board
{
    using System.Collections.Generic;

    using KingSurvival.Common.Contracts;
    using KingSurvival.Figures.Contracts;

    public class Memento
    {
        private IFigure[,] board;

        public Memento(IFigure[,] board, Dictionary<string, IPosition> figurePositionsOnBoard)
        {
            this.board = new IFigure[board.GetLength(0), board.GetLength(1)];
            this.Board = board;
            this.FigurePositionsOnBoard = figurePositionsOnBoard;
        }

        public int NumberOfRows { get; private set; }

        public IFigure[,] Board
        {
            get
            {
                return this.board;
            }

            private set
            {
                for (var i = 0; i < value.GetLength(0); i++)
                {
                    for (var j = 0; j < value.GetLength(1); j++)
                    {
                        if (value[i, j] != null)
                        {
                            this.board[i, j] = value[i, j].Clone();
                        }
                    }
                }
            }
        }

        public Dictionary<string, IPosition> FigurePositionsOnBoard { get; set; }

        public int NumberOfColumns { get; private set; }
    }
}
