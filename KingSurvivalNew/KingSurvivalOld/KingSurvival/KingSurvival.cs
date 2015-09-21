using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvival
{
    public class KingSurvival
    {
        private int[,] chessBoard;

        private int[] pawnRows = { 0, 0, 0, 0 };

        private int[] pawnColumns = { 0, 2, 4, 6 };

        private int kingRow = 7;

        private int kingColumn = 3;

        //s + belejim belite poleta
        //s - belejim chernite poleta

        //Aleksandra-The white and black cells can be done with enumeration where white will have meaning 1 and black will have meaning two
        //...needs to be changed everywhere in the code if we decide to change it to enumeration
        public enum Cell
        {
            White,
            Black
        }
        private int whiteCell = '+';

        private int blackCell = '-';

        private int[] deltaRed = { -1, +1, +1, -1 }; //UR, DR, DL, UL

        private int[] deltaColona = { +1, +1, -1, -1 };

        public KingSurvival()
        {
            chessBoard = new int[8, 8];
            GetChessBoard();
        }

        //Aleksandra
        /// <summary>
        /// The method fills the chess board with black and white fields
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public void GetChessBoard()
        {

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {

                for (int colum = 0; colum < chessBoard.GetLength(1); colum++)
                {

                    if ((row + colum) % 2 == 0)
                    {

                        chessBoard[row, colum] = whiteCell;

                    }

                    else
                    {

                        chessBoard[row, colum] = blackCell;

                    }

                }

            }

            chessBoard[pawnRows[0], pawnColumns[0]] = 'A';

            chessBoard[pawnRows[1], pawnColumns[1]] = 'B';

            chessBoard[pawnRows[2], pawnColumns[2]] = 'C';

            chessBoard[pawnRows[3], pawnColumns[3]] = 'D';

            chessBoard[kingRow, kingColumn] = 'K';
        }

     
        public bool MoveKingIfPossible(string command)
        {
            if (command.Length != 3)
            {
                return false;
            }
            string commandLowerCase = command.ToLower();
            int indexOfChange = -1;
            switch (commandLowerCase)
            {
                case "kur": { indexOfChange = 0; } break;
                case "kdr": { indexOfChange = 1; } break;
                case "kdl": { indexOfChange = 2; } break;
                case "kul": { indexOfChange = 3; } break;
                default: return false;
            }
            int kingNewRow = kingRow + deltaRed[indexOfChange];
            int kingNewColum = kingColumn + deltaColona[indexOfChange];
            if (proverka2(kingNewRow, kingNewColum))
            {
                chessBoard[kingRow, kingColumn] = chessBoard[kingNewRow, kingNewColum];
                chessBoard[kingNewRow, kingNewColum] = 'K';
                kingRow = kingNewRow;
                kingColumn = kingNewColum;
                return true;
            }
            return false;
        }

        public bool MovePawnIfPossible(string command)
        {
            if (command.Length != 3)
            {
                return false;
            }
            string commandToLower = command.ToLower();
            int indexOfChange = -1;
            switch (commandToLower)
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
                default: return false;
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

            int pawnNewRow = pawnRows[pawnIndex] + deltaRed[indexOfChange];
            int pawnNewColum = pawnColumns[pawnIndex] + deltaColona[indexOfChange];
            if (proverka2(pawnNewRow, pawnNewColum))
            {
                chessBoard[pawnRows[pawnIndex], pawnColumns[pawnIndex]] = chessBoard[pawnNewRow, pawnNewColum];
                chessBoard[pawnNewRow, pawnNewColum] = command.ToUpper()[0];
                pawnRows[pawnIndex] = pawnNewRow;
                pawnColumns[pawnIndex] = pawnNewColum;
                return true;
            }
            return false;
        }

        public bool KingWon()
        {
            if (kingRow == 0) //check if king is on the first row
            {
                return true;
            }
            for (int i = 0; i < chessBoard.GetLength(0); i += 2) // check if all powns are on the last row
            {
                if (chessBoard[chessBoard.GetLength(1) - 1, i] == whiteCell || chessBoard[chessBoard.GetLength(1) - 1, i] == blackCell)
                {
                    return false;
                }
            }
            return true;
        }

        //Aleksandra
        /// <summary>
        /// The method check whether the given row and column are inside the board
        /// </summary>
        /// <param name="row">The row that we want to check</param>
        /// <param name="column">The column that we want to check</param>
        /// <returns>Returns true if the given row and column are inside the board</returns>
        private bool CheckIfInsideTheBoard(int row, int column)
        {
            if (row < 0 || row > chessBoard.GetLength(0) - 1 || column < 0 || column > chessBoard.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }

        private bool proverka2(int row, int colum)
        {

            if (CheckIfInsideTheBoard(row, colum))
            {
                if (chessBoard[row, colum] == whiteCell || chessBoard[row, colum] == blackCell)
                {
                    return true;
                }
            }
            return false;


        }

        public bool KingLost()
        {
            if (!proverka2(kingRow + 1, kingColumn + 1) && !proverka2(kingRow + 1, kingColumn - 1) &&
                !proverka2(kingRow - 1, kingColumn + 1) && !proverka2(kingRow - 1, kingColumn - 1))
            {
                return true;
            }
            return false;
        }

        public void PrintBoard()
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int colum = 0; colum < chessBoard.GetLength(1); colum++)
                {
                    int cell = chessBoard[row, colum];
                    char toPrint = (char)cell;
                    Console.Write(toPrint + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            KingSurvival game = new KingSurvival();
            int hodoveNaCarq = 0;
            bool isKingsTurn = true;
            while (true) //dokato igrata ne svyrshi - vyrti cikyla
            {
                if (game.KingWon())
                {
                    Console.WriteLine("King won in {0} turns", hodoveNaCarq); break;
                }
                else if (game.KingLost())
                {
                    Console.WriteLine("King lost in {0} turns", hodoveNaCarq);
                    break;
                }
                else
                {
                    Console.WriteLine();
                    game.PrintBoard();
                    if (isKingsTurn)
                    {
                        bool kingMoved = false;
                        while (!kingMoved)
                        {
                            Console.Write("King's turn: ");
                            string command = Console.ReadLine();
                            kingMoved = game.MoveKingIfPossible(command);
                            if (!kingMoved)
                            {
                                Console.WriteLine("Illegal move!");
                            }
                        } isKingsTurn = false;
                        hodoveNaCarq++;
                    }
                    else
                    {
                        bool pawnMoved = false;
                        while (!pawnMoved)
                        {
                            Console.Write("Pawns' turn: ");
                            string command = Console.ReadLine();
                            pawnMoved = game.MovePawnIfPossible(command);
                            if (!pawnMoved)
                            {
                                Console.WriteLine("Illegal move!");
                            }
                        }
                        isKingsTurn = true;
                    }
                }
            }
        }
    }
}
