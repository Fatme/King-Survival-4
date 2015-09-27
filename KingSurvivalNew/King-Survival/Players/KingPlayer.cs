namespace KingSurvival.Players
{
    using System;
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;

    public class KingPlayer : Player, IPlayer
    {
        public KingPlayer(string name)
            : base(name)
        {
        }

        public override Move Move(string command,IBoard board)
        {
            int indexOfChange = -1;

            if (command.Length != 3)
            {
                //TODO: change the exception to custom exception
                throw new ArgumentOutOfRangeException("The command should contain three symbols.");
            }

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

            var oldPosition = board.GetFigurePosition(this.Figures[0]);
            return this.GenerateNewMove(oldPosition, indexOfChange);
        }
    }
}
