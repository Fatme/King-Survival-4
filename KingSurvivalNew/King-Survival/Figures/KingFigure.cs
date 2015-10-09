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

        protected override string ProvideShape()
        {
            return "K";
        }
    }
}
