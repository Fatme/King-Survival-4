namespace KingSurvival.ConsoleUI
{
    using KingSurvival;
    using KingSurvival.ConsoleUI.Input;
    using KingSurvival.ConsoleUI.Renderers;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Renderers.Contracts;
    
    public class EntryPoint
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputProvider provider = new ConsoleInputProvider();
            Facade facade = new Facade();
            facade.Start(renderer, provider);
        }
    }
}
