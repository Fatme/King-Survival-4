using KingSurvival.Common;
using KingSurvival.Common.Console;

namespace KingSurvival.Renderers
{
    using System;
    using Board.Contracts;
    using KingSurvival.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
       
        public void RenderMainMenu()
        {
            Console.WriteLine("King Survival Game");
        }

        public void RenderBoard(IBoard board)
        {
            for (int row = 0; row < board.NumberOfRows; row++)
            {
                for (int column = 0; column < board.NumberOfColumns; column++)
                {

                   // int cell = board[row, colum];
                    Position position=new Position(row,column);
                    var figure = board.GetFigureAtPosition(position);
               
                    ConsoleHelpers.PrintFigure(figure,position);              
               }
                Console.WriteLine();
            }
        }
    }
}
