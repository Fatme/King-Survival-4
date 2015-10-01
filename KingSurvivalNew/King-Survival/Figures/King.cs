using KingSurvival.Common.Contracts;

namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;

    public class King : Figure, IFigure
    {
        //TODO:make king as the pawn is made to have consistency
        public King()
            : base(FigureSign.K)
        {
        }

    }
}
