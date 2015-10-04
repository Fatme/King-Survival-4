﻿namespace KingSurvival.Figures
{
    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Figures.Contracts;

    public  class Figure : IFigure, IContentProvider, IFigurePrototype
    {
        public Figure()
        {
        }

        public Figure(FigureSign sign)
        {
            this.Sign = sign;
        }

        public FigureSign Sign { get;  private set; }

        public string ProvideContent()
        {
            return this.Sign.ToString();
        }

        public void AddSign(FigureSign sign)
        {
            this.Sign = sign;
        }

        public IFigure Clone()
        {
            return (IFigure) this.MemberwiseClone();
        }
    }
}
