namespace KingSurvival.Figures
{
    using System.Collections.Generic;

    using KingSurvival.Figures.Contracts;

    public class PawnCFigure : Figure, IFigure
    {
        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "cdr", "cdl" };
            }
        }

        public override string DisplayName
        {
            get
            {
                return "C";
            }
        }
    }
}
