using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Board.Contracts;
using KingSurvival.Common;
using KingSurvival.Common.Contracts;
using KingSurvival.Engine;
using KingSurvival.Engine.Contracts;
using KingSurvival.Input.Contracts;
using KingSurvival.Renderers.Contracts;
using KingSurvival.Board.Contracts;
using KingSurvival.Board;
using KingSurvival.Commands;
using KingSurvival.Commands.Contracts;

namespace KingSurvival
{
    
    public class Facade
    {
        public void Start(IRenderer renderer,IInputProvider provider)
        {
            
            renderer.RenderMainMenu();
            IWinningConditions winningConditions = new WinningConditions();
            IBoard board=new Board.Board();
            IChessEngine chessEngine = new KingSurvivalEngine(renderer, provider, board, winningConditions);
            chessEngine.InitializeGame().StartGame();
            
            //TODO:add main menu
        }
    }
}
