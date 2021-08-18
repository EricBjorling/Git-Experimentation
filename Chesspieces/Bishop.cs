using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Bishop : Chesspiece
    {
        public Bishop(Color color, string type, int initialRow, int initialColumn) : base(color, type, initialRow, initialColumn)
        {

        }
       
        public override List<int[]> LegalMoves()
        {
            List<int[]> legalMoves = new List<int[]>();


            int row = this.row;
            int col = this.column;

            for (int i = 1; i < 8; i++)
            {
                // Diagonal
                legalMoves.Add(new int[] { row + (i), col + (i)});
                legalMoves.Add(new int[] { row + (i), col + (-i)});
                legalMoves.Add(new int[] { row + (-i), col + (i) });
                legalMoves.Add(new int[] { row + (-i), col + (-i) });
            }

            return legalMoves;
        }
    }
}
