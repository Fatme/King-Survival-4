using System.Linq;

namespace KingSurvival.Common
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Common.Contracts;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;

    public class WinningConditions : IWinningConditions
    {
        public bool KingWon(IList<IPlayer> players, IBoard board)
        {
            for (var i = 0; i < players.Count; i++)
            {
                if (players[i].Figures[0].Sign == FigureSign.K)
                {
                    if (board.GetFigurePosition(players[i].Figures[0]).Row == 0)//check if king is on the first row
                    {
                        return true;
                    }
                }

            }
             for (int i = 0; i < board.NumberOfRows; i += 2) // check if all powns are on the last row
            {
                if (board.GetFigureAtPosition(new Position(board.NumberOfColumns - 1, i)) == null )
                {
                    return false;
                }
            }
            return true;

        }

        public bool KingLost(IList<IPlayer> players, IBoard board)
        {
            var king = players[0];
            int kingRow = board.GetFigurePosition(king.Figures[0]).Row;
            int kingCol = board.GetFigurePosition(king.Figures[0]).Col;
            if (!proverka2(new Position(kingRow + 1, kingCol + 1),board) && !proverka2(new Position(kingRow + 1, kingCol - 1),board) &&
               !proverka2(new Position(kingRow - 1, kingCol + 1),board) && !proverka2(new Position(kingRow - 1, kingCol - 1),board))
            {
                return true;
            }
            return false;
        }
        private bool proverka2(Position position,IBoard board)
        {

            if (CheckIfInsideTheBoard(position))
            {
                if (board.GetFigureAtPosition(position)==null)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfInsideTheBoard(Position position)
        {
            try
            {
                Validator.CheckIfPositionValid(position, GlobalErrorMessages.PositionNotValidMessage);
                return true;
            }
            catch (IndexOutOfRangeException ex)
            {
                return false;
            }
        }

        
    }
}
