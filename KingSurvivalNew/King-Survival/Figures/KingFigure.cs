namespace KingSurvival.Figures
{
    using System.Collections.Generic;
    using KingSurvival.Figures.Contracts;

    public class KingFigure : Figure, IFigure
    {
        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "kur", "kdl", "kul", "kdr" };
            }
        }

        public override string DisplayName
        {
            get
            {
                return "K";
            }
        }
    }
}
