

using KingSurvival.Figures;

namespace KingSurvival.Common.Console
{
    using KingSurvival.Figures.Contracts;
    using System;
    public static class ConsoleHelpers
    {
        public const char PawnStartSymbol = 'A';
        public const char KingSymbol = 'K';
        public const char EmptyWhiteCell = '-';
        public const char EmptyBlackCell = '+';

        public static void PrintFigure(IFigure figure,Position position)
        {
            if (figure==null)
            {

                if ((position.Row + position.Col) % 2 != 0)
                {

                   Console.Write(EmptyWhiteCell);

                }
                else
                {
                    Console.Write(EmptyBlackCell);
                }

            }
            else
            {
                //TODO:put this logic to separate class
                if (figure.Color == ChessColor.A)
                {
                    Console.Write('A');
                }
                if (figure.Color == ChessColor.B)
                {
                    Console.Write('B');
                }
                if (figure.Color == ChessColor.C)
                {
                    Console.Write('C');
                }
                if (figure.Color == ChessColor.D)
                {
                    Console.Write('D');
                }
                if (figure.Color == ChessColor.K)
                {
                    Console.Write('K');
                }
            }
        }
    }
}
