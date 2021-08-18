using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class King : Chesspiece
    {
        public King(Color color, string type, int initialRow, int initialColumn) : base(color, type, initialRow, initialColumn)
        {

        }
        public override List<int[]> LegalMoves()
        {
            List<int[]> legalMoves = new List<int[]>();


            int row = this.row;
            int col = this.column;

            legalMoves.Add(new int[] { row + (-1), col});
            legalMoves.Add(new int[] { row + (1), col });

            legalMoves.Add(new int[] { row, col + (-1) });
            legalMoves.Add(new int[] { row, col + (1) });

            legalMoves.Add(new int[] { row + (-1), col + (1) });
            legalMoves.Add(new int[] { row + (-1), col + (-1) });

            legalMoves.Add(new int[] { row + (1), col + (1) });
            legalMoves.Add(new int[] { row + (1), col + (-1) });

            return legalMoves;
        }
    }
}
