namespace KingSurvival
{
    using System.Collections.Generic;

    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Engine;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Players;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Renderers.Contracts;

    public class Facade
    {
        public void Start(IRenderer renderer, IInputProvider provider)
        {
            renderer.RenderMainMenu();
            IWinningConditions winningConditions = new WinningConditions();
            var players = new List<IPlayer>();
            var kingPlayer = new Player("king");
            var pawnPlayer = new Player("pawn");
            players.Add(kingPlayer);
            players.Add(pawnPlayer);

            var board = new Board.Board();

            var engine = new KingSurvivalEngine(renderer, provider, board, winningConditions, players);
            engine.InitializeGame().StartGame();
        }
    }
}
