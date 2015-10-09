namespace KingSurvival.ConsoleUI.Renderers
{
    using System;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public const char EmptyWhiteCell = '-';
        public const char EmptyBlackCell = '+';

        public void RenderMainMenu()
        {
            Console.WriteLine("King Survival Game");
        }

        public void RenderBoard(IBoard board)
        {
            this.PrintHorizontalNumbers();
            for (int row = 0; row < board.NumberOfRows; row++)
            {
                Console.Write(row + "| ");
                for (int column = 0; column < board.NumberOfColumns; column++)
                {
                    Position position = new Position(row, column);
                    var figure = board.GetFigureAtPosition(position);

                    if (figure != null)
                    {
                        Console.Write(figure.ProvideFigureShape() + " ");
                    }
                    else
                    {
                        this.PrintCell(position);
                    }
                }

                Console.Write("|");
                Console.WriteLine();
            }

            this.PrintHorizontalLines();
        }

        public void PrintMessage(string error)
        {
            Console.WriteLine(error);
        }

        private void PrintCell(Position position)
        {
            if ((position.Row + position.Col) % 2 != 0)
            {
                Console.Write(EmptyWhiteCell + " ");
            }
            else
            {
                Console.Write(EmptyBlackCell + " ");
            }
        }

        private void PrintHorizontalNumbers()
        {
            Console.Write("   ");

            for (var i = 0; i < Constants.StandardBoardColumns; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            this.PrintHorizontalLines();
        }

        private void PrintHorizontalLines()
        {
            Console.Write("   ");
            Console.WriteLine("---------------");
        }
    }
}
