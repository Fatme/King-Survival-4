using KingSurvival.Board.Contracts;
using KingSurvival.Common;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Players
{
    using System.Collections.Generic;
    using KingSurvival.Players.Contracts;
  
    public abstract class Player:IPlayer
    {
        private IList<IFigure> figures;

        public Player(string name)
        {
            
            this.Name = name;
            this.figures=new List<IFigure>();
        }


        public string Name { get; private set; }


        public void AddFigure(IFigure figure)
        {
           this.figures.Add(figure);
        }

        public IList<IFigure> Figures
        {
            get { return this.figures; }
            private set { this.figures = value; }
        }

       
        public abstract Move Move(string command,IBoard board);
       
    }
}
