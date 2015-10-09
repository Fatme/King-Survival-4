using System;
using System.Collections.Generic;

namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;

    public abstract class Figure:IFigure,IFigurePrototype
    {
        public string ProvideFigureShape()
        {
            return this.ProvideShape();
        }

        protected abstract string ProvideShape();
        protected abstract List<string> ValidCommands { get; }

        public IFigure Clone()
        {
            return (IFigure)this.MemberwiseClone();
        }

        public void CheckIfCommandIsValid(string command)
        {
            if (!this.ValidCommands.Contains(command))
            {
                throw new ArgumentException("This command is not valid for this player");
            }
        }
    }
}
