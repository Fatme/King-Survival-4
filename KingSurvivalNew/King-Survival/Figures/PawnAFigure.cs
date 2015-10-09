using KingSurvival.Figures.Contracts;

namespace KingSurvival.Figures
{
    public class PawnAFigure : Figure,IFigure
    {
        protected override string ProvideShape()
        {
            return "A";
        }
    }
}
