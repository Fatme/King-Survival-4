namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;

    public class Pawn : Figure, IFigure
    {
        public Pawn(FigureSign sign, Position position)
            : base(sign,position)
        {

        }  
    }
}
