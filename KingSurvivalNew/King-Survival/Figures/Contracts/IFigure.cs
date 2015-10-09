namespace KingSurvival.Figures.Contracts
{
    public interface IFigure : IFigurePrototype
    {
        string ProvideFigureShape();

        void CheckIfCommandIsValid(string command);
    }
}