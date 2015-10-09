namespace KingSurvival.Figures
{
    using System.Collections.Generic;

    using KingSurvival.Figures.Contracts;

    public class PawnDFigure : Figure, IFigure
    {
        public override string DisplayName
        {
            get
            {
                return "D";
            }
        }

        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "ddr", "ddl" };
            }
        }
    }
}
