using KingSurvival.Board;
using KingSurvival.Board.Contracts;

namespace KingSurvivalUI
{
    using KingSurvival.Engine;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;
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
            IBoard board=new Board();
           
            IChessEngine chessEngine = new KingSurvivalEngine(renderer, provider,board,winningConditions);
            chessEngine.Initialize();
            chessEngine.Start();
            //TODO:add main menu

        }
    }
}
