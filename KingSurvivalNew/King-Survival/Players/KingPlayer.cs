using KingSurvival.Common;
using KingSurvival.Figures.Contracts;
using KingSurvival.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Players
{
    public class KingPlayer : Player, IPlayer
    {
        public KingPlayer(string name)
            : base(name)
        {
        }

        public override Move Move(string command)
        {

            int[] deltaRed = { -1, +1, +1, -1 }; //UR, DR, DL, UL

            int[] deltaColona = { +1, +1, -1, -1 };
            int indexOfChange = -1;



            if (command.Length != 3)
            {
                //TODO:change the exception to custom exception
                throw new ArgumentOutOfRangeException("The command should contain three symbols");
            }

            var oldPosition = this.Figures[0].Position;

            switch (command)
            {
                case "kur": { indexOfChange = 0; } break;
                case "kdr": { indexOfChange = 1; } break;
                case "kdl": { indexOfChange = 2; } break;
                case "kul": { indexOfChange = 3; } break;
                default:
                    //TODO:change the exception to custom exception
                    throw new ArgumentOutOfRangeException("The command is not correct");


            }
            int newRow = oldPosition.Row + deltaRed[indexOfChange];
            int newColumn = oldPosition.Col + deltaColona[indexOfChange];
            var newPosition = new Position(newRow, newColumn);
            this.Figures[0].Position = newPosition;
            Position.CheckIfValid(newPosition, GlobalErrorMessages.PositionNotValidMessage);
            return new Move(oldPosition, newPosition);



        }

    }
}
