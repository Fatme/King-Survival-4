namespace KingSurvival.Figures
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Figures.Contracts;

    public abstract class Figure : IFigure, IFigurePrototype
    {
        public abstract string DisplayName { get; }

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
