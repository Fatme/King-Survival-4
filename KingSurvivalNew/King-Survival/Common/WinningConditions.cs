namespace KingSurvival.Common
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Players.Contracts;

    public class WinningConditions : IWinningConditions
    {
        public bool KingWon(IList<IPlayer> players, IBoard board)
        {
            var kingPlayer = players[0];
            var pawnPlayer = players[1];

            ////check if king is on the first row
            if (board.GetFigurePosition(kingPlayer.Figures[0]).Row == 0) 
            {
                return true;
            }

            //// check if all powns are on the last row
            for (int i = 0; i < board.NumberOfRows; i += 2) 
            {
                if (board.GetFigureAtPosition(new Position(board.NumberOfColumns - 1, i)) == null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool KingLost(IList<IPlayer> players, IBoard board)
        {
            IPlayer kingPlayer = players[0];

            if (this.CheckIfKingIsCatched(kingPlayer, board))
            {
                return true;
            }

            return false;
        }

        private bool CheckIfKingIsCatched(IPlayer player, IBoard board)
        {
            int kingRow = board.GetFigurePosition(player.Figures[0]).Row;
            int kingCol = board.GetFigurePosition(player.Figures[0]).Col;
            var kingDownRightPosition = new Position(kingRow + 1, kingCol + 1);
            var kingDownLeftPosition = new Position(kingRow + 1, kingCol - 1);
            var kingUpRightPosition = new Position(kingRow - 1, kingCol + 1);
            var kingUpLeftPosition = new Position(kingRow - 1, kingCol - 1);
            if (!this.CheckIfPositionIsEmpty(kingDownRightPosition, board) && !this.CheckIfPositionIsEmpty(kingDownLeftPosition, board) &&
               !this.CheckIfPositionIsEmpty(kingUpRightPosition, board) && !this.CheckIfPositionIsEmpty(kingUpLeftPosition, board))
            {
                return true;
            }

            return false;
        }

        private bool CheckIfPositionIsEmpty(Position position, IBoard board)
        {
            if (this.CheckIfInsideTheBoard(position))
            {
                if (board.GetFigureAtPosition(position) == null)
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
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
    }
}
