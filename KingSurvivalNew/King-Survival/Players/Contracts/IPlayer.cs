using System.Collections;
using System.Collections.Generic;
using KingSurvival.Board.Contracts;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Players.Contracts
{
    using KingSurvival.Common;

    public interface IPlayer
    {
       
        string Name { get; }

        void AddFigure(IFigure figure);

        IList<IFigure> Figures { get; }

        Move Move(string command,IBoard board);

        
    }
}

