namespace KingSurvival.Figures.Contracts
{
    using System.Collections.Generic;

    interface IFiguresFactory
    {

        IFigure CreateKing();

        IList<IFigure> CreatePawns();
    }
}
