using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    class ChessBoard
    {
        private int[,] board;
        private int whiteCell = '+';
        private int blackCell = '-';

        public ChessBoard()
        {
            board = new int[8, 8];
        }
        /// <summary>
        /// The method fills the chess board with black and white fields
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public void GetChessBoard()
        {

            for (int row = 0; row < this.board.GetLength(0); row++)
            {

                for (int colum = 0; colum < this.board.GetLength(1); colum++)
                {

                    if ((row + colum) % 2 == 0)
                    {

                        this.board[row, colum] = this.whiteCell;

                    }

                    else
                    {

                        this.board[row, colum] = this.blackCell;

                    }

                }

            }
        }
    }
}
