namespace KingSurvival.Figures.Contracts
{
    public interface IFigure : IFigurePrototype
    {
        string DisplayName { get; }

        void CheckIfCommandIsValid(string command);
    }
}