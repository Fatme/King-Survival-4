namespace KingSurvival.Renderers.Contracts
{
    using KingSurvival.Board.Contracts;

    public interface IRenderer
    {
        void RenderMainMenu();

        void RenderBoard(IBoard board);

        void PrintMessage(string error);
    }
}
