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
           
            //TODO:add main menu

        }
    }
}
