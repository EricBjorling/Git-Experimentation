using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Queen : Chesspiece
    {
        public Queen(Color color, string type, int initialRow, int initialColumn) : base(color, type, initialRow, initialColumn)
        {

        }
       
        public override List<int[]> LegalMoves()
        {
            List<int[]> legalMoves = new List<int[]>();


            int row = this.row;
            int col = this.column;

            for (int i = 1; i < 8; i++)
            {
                // Horizontal
                legalMoves.Add(new int[] { row + (-i), col });  // first below
                legalMoves.Add(new int[] { row + (i), col });   // first above
                legalMoves.Add(new int[] { row, col + (i) });  // first right
                legalMoves.Add(new int[] { row, col + (-i) });  // first right

                // Diagonal
                legalMoves.Add(new int[] { row + (i), col + (i) });
                legalMoves.Add(new int[] { row + (i), col + (-i) });
                legalMoves.Add(new int[] { row + (-i), col + (i) });
                legalMoves.Add(new int[] { row + (-i), col + (-i) });
            }

            return legalMoves;
        }
    }
}
