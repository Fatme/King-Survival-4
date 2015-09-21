using KingSurvival.Common;
using KingSurvival.Figures.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Figures
{
    public class FiguresFactory:IFiguresFactory
    {
        public IFigure CreateKing()
        {
            var positionKing = new Position(7,3);
            var king = new King(FigureSign.K, positionKing);
            return king;
        }
        public IList<IFigure> CreatePawns()
        {
            int positionColPawn = 0;
            IList<IFigure> pawns = new List<IFigure>();
            for (var i = 0; i < Constants.numberOfPawns; i++)
            {
                var positionPawn = new Position(0, positionColPawn);
                var pawn = new Pawn((FigureSign)(i), positionPawn);
                pawns.Add(pawn);
                positionColPawn += 2;
               
            }
            return pawns;
        }


       
    }
}
