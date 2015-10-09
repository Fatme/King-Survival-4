
using System;
using System.Collections.Generic;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Figures
{
    public class KingFigure:Figure,IFigure
    {
        protected override string ProvideShape()
        {
            return "K";
        }
        
        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>(){"kur","kdl","kul","kdr"};
            }
          
        }
    }
}
