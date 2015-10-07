namespace KingSurvival.ConsoleUI
{
    using KingSurvival;
    using KingSurvival.ConsoleUI.Input;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Renderers.Contracts;
    using KingSurvival.ConsoleUI.Renderers;

    public class EntryPoint
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputProvider provider = new ConsoleInputProvider();
            Facade facade=new Facade();
            facade.Start(renderer,provider);

        }
    }
}
