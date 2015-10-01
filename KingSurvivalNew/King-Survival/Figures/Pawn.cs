using KingSurvival.Commands.Contracts;

namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Commands;

    public class Pawn : Figure, IFigure,IContentProvider
    {
        public Pawn(FigureSign sign)
            : base(sign)
        {
        }

       
    }
}
