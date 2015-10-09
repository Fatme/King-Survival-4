
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Figures
{
    public class KingFigure:Figure,IFigure
    {
        protected override string ProvideShape()
        {
            return "K";
        }
    }
}
