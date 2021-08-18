using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public abstract class Chesspiece
    {
        public Color color;
        public string kind;
        public int row;
        public int column;

        public Chesspiece(Color color, string kind, int initialRow, int initialColumn)
        {
            this.color = color;
            this.kind = kind;
            this.row = initialRow;
            this.column = initialColumn;
        }

        public abstract List<int[]> LegalMoves();

        public override string ToString()
        {
            return this.kind;
        }
    }
}
