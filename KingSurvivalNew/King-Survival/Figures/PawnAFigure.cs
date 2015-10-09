namespace KingSurvival.Figures
{
    using System.Collections.Generic;
    using KingSurvival.Figures.Contracts;

    public class PawnAFigure : Figure, IFigure
    {
        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "adr", "adl" };
            }
        }

        public override string DisplayName
        {
            get
            {
                return "A";
            }
        }
    }
}
