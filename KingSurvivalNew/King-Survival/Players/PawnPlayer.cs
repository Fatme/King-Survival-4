namespace KingSurvival.Players
{
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;
    using System;

    public class PawnPlayer : Player, IPlayer
    {
        public PawnPlayer(string name)
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
                //TODO:Change the exception to custom exception
                throw new ArgumentOutOfRangeException("The command should contain three symbols");
            }

            switch (command)
            {
                case "adr":
                case "bdr":
                case "cdr":
                case "ddr":
                    { indexOfChange = 1; }
                    break;
                case "adl":
                case "bdl":
                case "cdl":
                case "ddl":
                    { indexOfChange = 2; }
                    break;
                default:
                    //TODO:change the exception to custom exception
                    throw new ArgumentOutOfRangeException("The command is not correct");
            }
            int pawnIndex = -1;
            switch (command[0])
            {
                case 'a':
                case 'A':
                    { pawnIndex = 0; }
                    break;
                case 'b':
                case 'B':
                    { pawnIndex = 1; }
                    break;
                case 'c':
                case 'C':
                    { pawnIndex = 2; }
                    break;
                case 'd':
                case 'D':
                    { pawnIndex = 3; }
                    break;
            }
            var oldPosition = this.Figures[pawnIndex].Position;
            int pawnNewRow = oldPosition.Row + deltaRed[indexOfChange];
            int pawnNewColum = oldPosition.Col + deltaColona[indexOfChange];
            var newPosition = new Position(pawnNewRow, pawnNewColum);
            return new Move(oldPosition, newPosition);
        }
    }
}
