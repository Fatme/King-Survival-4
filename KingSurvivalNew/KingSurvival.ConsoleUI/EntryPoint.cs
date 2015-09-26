using KingSurvival.Common;
using KingSurvival.Common.Contracts;

namespace KingSurvivalUI
{
    using KingSurvival.Engine;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Renderers;
    using KingSurvival.Renderers.Contracts;
    using KingSurvivalUI.Input;
    using KingSurvivalUI.Renderers;

    public class EntryPoint
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();
            IInputProvider provider = new ConsoleInputProvider();
            IWinningConditions winningConditions=new WinningConditions();
            IChessEngine chessEngine = new KingSurvivalEngine(renderer, provider,winningConditions);
            chessEngine.Initialize();
            chessEngine.Start();
            //TODO:add main menu

        }
    }
}
