namespace KingSurvival.Figures
{
    using System.Collections.Generic;
    using KingSurvival.Figures.Contracts;

    public class PawnAFigure : Figure, IFigure
    {
        public override string DisplayName
        {
            get
            {
                return "A";
            }
        }

        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "adr", "adl" };
            }
        }
    }
}
