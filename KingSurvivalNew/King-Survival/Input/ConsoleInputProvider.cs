using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Common;
using KingSurvival.Common.Console;
using KingSurvival.Input.Contracts;
using KingSurvival.Players;
using KingSurvival.Players.Contracts;

namespace KingSurvival.Input
{
    public class ConsoleInputProvider : IInputProvider
    {
        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Clear();
                Console.Write(string.Format("Enter player {0} name ", i));
                string name = Console.ReadLine();

                var player = new Player(name, (ChessColor)(i));
                players.Add(player);
            }
            return players;
        }

        public Move GetNextMoveFigure(IPlayer player)
        {
            Console.Write("{0} is next", player.Name);
            var command = Console.ReadLine();
            if (player.Figures[0].Color == ChessColor.K)
            {
                return MoveKing(player, command);
            }
            else
            {
                return MovePawn(player, command);
            }
        }
        private Move MoveKing(IPlayer player, string command)
        {

            int[] deltaRed = { -1, +1, +1, -1 }; //UR, DR, DL, UL

            int[] deltaColona = { +1, +1, -1, -1 };
            int indexOfChange = -1;



            if (command.Length != 3)
            {
                throw new ArgumentOutOfRangeException("The command should contain three symbols");
            }

            var oldPosition = player.Figures[0].Position;

            switch (command)
            {
                case "kur": { indexOfChange = 0; } break;
                case "kdr": { indexOfChange = 1; } break;
                case "kdl": { indexOfChange = 2; } break;
                case "kul": { indexOfChange = 3; } break;
                default:
                    break;


            }
            int newRow = oldPosition.Row + deltaRed[indexOfChange];
            int newColumn = oldPosition.Col + deltaColona[indexOfChange];
            var newPosition = new Position(newRow, newColumn);
            return new Move(oldPosition, newPosition);


        }

        private Move MovePawn(IPlayer player, string command)
        {
            int[] deltaRed = { -1, +1, +1, -1 }; //UR, DR, DL, UL

            int[] deltaColona = { +1, +1, -1, -1 };
            int indexOfChange = -1;


            if (command.Length != 3)
            {
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
                    break;
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
            var oldPosition = player.Figures[pawnIndex].Position;
            int pawnNewRow = oldPosition.Row + deltaRed[indexOfChange];
            int pawnNewColum = oldPosition.Col + deltaColona[indexOfChange];
            var newPosition = new Position(pawnNewRow, pawnNewColum);
            return new Move(oldPosition, newPosition);
        }

    }
}
