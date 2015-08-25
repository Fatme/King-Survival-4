namespace KingSurvival.Renderers
{
    using System;
    using Board.Contracts;
    using KingSurvival.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {

        public void RenderMainMenu()
        {
            Console.WriteLine("King Survival Game");
        }

        public void RenderBoard(IBoard board)
        {
            throw new System.NotImplementedException();
        }
    }
}
