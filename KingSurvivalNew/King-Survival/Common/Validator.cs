﻿namespace KingSurvival.Common
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Players.Contracts;
    using System;
    using System.Collections.Generic;

    public static class Validator
    {
        public static void CheckIfObjectIsNull(object obj, string errorMessage)
        {
            if (obj == null)
            {
                throw new NullReferenceException(errorMessage);
            }
        }
        public static void ValidateGameInitialization(IList<IPlayer> players, IBoard board)
        {
            if (players.Count != Constants.StandardNumberOfPlayers)
            {
                throw new InvalidOperationException("King Survival Engine must have two player");
            }

            if (board.NumberOfRows != Constants.StandardChessRows || board.NumberOfColumns != Constants.StandardChessColumns)
            {
                throw new InvalidOperationException("King survial has 8x8 board");
            }
        }
    }
}
