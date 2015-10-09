namespace KingSurvival
{
    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Engine;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Renderers.Contracts;

    public class Facade
    {
        public void Start(IRenderer renderer, IInputProvider provider)
        {
            renderer.RenderMainMenu();
            IWinningConditions winningConditions = new WinningConditions();
            var board = new Board.Board();
            var engine = new KingSurvivalEngine(renderer, provider, board, winningConditions);
            engine.InitializeGame().StartGame();
        }
    }
}
