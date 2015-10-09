namespace KingSurvival.Figures
{
    using System.Collections.Generic;
    using KingSurvival.Figures.Contracts;

    public class PawnBFigure : Figure, IFigure
    {
        public override string DisplayName
        {
            get
            {
                return "B";
            }
        }

        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "bdr", "bdl" };
            }
        }
    }
}
