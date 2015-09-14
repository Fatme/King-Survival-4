using KingSurvival.Engine;
using KingSurvival.Engine.Contracts;
using KingSurvival.Input;
using KingSurvival.Input.Contracts;

namespace KingSurvival
{
    using KingSurvival.Renderers;
    using KingSurvival.Renderers.Contracts;

    public class EntryPoint
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();
            IInputProvider provider = new ConsoleInputProvider();
            IChessEngine chessEngine = new KingSurvivalEngine(renderer, provider);
            chessEngine.Initialize();
            chessEngine.Start();
            //TODO:add main menu

        }
    }
}
