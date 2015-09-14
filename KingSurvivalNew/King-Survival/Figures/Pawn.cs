namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;

    public class Pawn : Figure,IFigure
    {
        public Pawn(ChessColor color,Position position)
            : base(color,position)
        {
        }

        
    }
}
