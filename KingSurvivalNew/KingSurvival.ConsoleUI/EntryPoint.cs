namespace KingSurvivalUI
{
    using KingSurvival.Engine;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Input.Contracts;
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
            IChessEngine chessEngine = new KingSurvivalEngine(renderer, provider);
            chessEngine.Initialize();
            chessEngine.Start();
            //TODO:add main menu

        }
    }
}
