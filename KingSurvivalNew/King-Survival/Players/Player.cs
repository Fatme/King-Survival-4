using KingSurvival.Common;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Players
{
    using System.Collections.Generic;
    using KingSurvival.Players.Contracts;
  
    public class Player:IPlayer
    {
        private ICollection<IFigure> figures;

        public Player(string name,ChessColor color)
        {
            this.Color = color;
            this.Name = name;
            this.figures=new List<IFigure>();
        }

        public ChessColor Color { get; private set; }


        public string Name { get; private set; }


        public void AddFigure(IFigure figure)
        {
           this.figures.Add(figure);
        }
    }
}
