namespace KingSurvival.Players
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Figures.Contracts;
  
    public abstract class Player : IPlayer
    {
        private IList<IFigure> figures;

        public string Name { get; private set; }

        public IList<IFigure> Figures
        {
            get { return this.figures; }
        }

        public Player(string name)
        {            
            this.Name = name;
            this.figures = new List<IFigure>();
        }

        public void AddFigure(IFigure figure)
        {
           this.figures.Add(figure);
        }

        public abstract Move Move(string command, IBoard board);       
    }
}
