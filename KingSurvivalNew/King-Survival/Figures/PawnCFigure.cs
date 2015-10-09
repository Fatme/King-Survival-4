namespace KingSurvival.Figures
{
    using System.Collections.Generic;

    using KingSurvival.Figures.Contracts;

    public class PawnCFigure : Figure, IFigure
    {
        public override string DisplayName
        {
            get
            {
                return "C";
            }
        }

        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "cdr", "cdl" };
            }
        }
    }
}
