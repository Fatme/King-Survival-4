namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;
    using System;

    public class Pawn : Figure,IFigure
    {
        public Pawn(FigureSign sign,Position position)
            : base(sign,position)
        {
        }
       
       

        
    }
}
