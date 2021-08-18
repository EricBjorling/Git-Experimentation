using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Knight : Chesspiece
    {
        public Knight(Color color, string type, int initialRow, int initialColumn) : base(color, type, initialRow, initialColumn)
        {

        }

        public override List<int[]> LegalMoves()
        {
            List<int[]> legalMoves = new List<int[]>();


            int row = this.row;
            int col = this.column;

            legalMoves.Add(new int[] { row + (-2), col + (1) });  // first below right
            legalMoves.Add(new int[] { row + (-2), col + (-1) });  // first below left

            legalMoves.Add(new int[] { row + (2), col + (1) });  // first above right
            legalMoves.Add(new int[] { row + (2), col + (-1) });  // first above left

            legalMoves.Add(new int[] { row + (1), col + (2) });  // first right below
            legalMoves.Add(new int[] { row + (-1), col + (2) });  // first above up

            legalMoves.Add(new int[] { row + (1), col + (-2) });  // first left up below
            legalMoves.Add(new int[] { row + (-1), col + (-2) });  // first left up

            return legalMoves;
        }
    }
}
