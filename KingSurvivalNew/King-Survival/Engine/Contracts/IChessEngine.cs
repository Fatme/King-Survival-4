﻿using KingSurvival.Board.Contracts;

namespace KingSurvival.Engine.Contracts
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;

   public interface IChessEngine
    {
        

        void Initialize();

        void Start();

        void WinningConditions();

    }
}