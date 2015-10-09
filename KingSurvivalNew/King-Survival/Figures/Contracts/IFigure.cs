namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;

    public interface IFigure:IFigurePrototype
    {
        string ProvideFigureShape();

        void CheckIfCommandIsValid(string command);
    }
}