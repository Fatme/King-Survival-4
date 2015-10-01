using KingSurvival.Common.Contracts;

namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;

    public class Pawn : Figure, IFigure,IContentProvider
    {
        public Pawn(FigureSign sign)
            : base(sign)
        {
        }

       
    }
}
