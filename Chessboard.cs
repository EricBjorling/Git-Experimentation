using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Chessboard
    {
        private Chesspiece[,] board;  // int col, int row
        private bool[,] markedBoard;
        public bool isGameOver = false;

        public Chessboard()
        {
            board = new Chesspiece[8, 8];
            initialize();
            PrintBoard();
            // Init the 8x8 grid
            // Init all the pieces in the correct place
            // 

            //_board = new Piece[ROW_SIZE, COL_SIZE]; // Create the board
            //InitPieces(); // Initialize and place down all the pieces on the board
            //PrintBoard();
        }

        public void initialize()
        {
            string[,] boardSetup = new string[8, 8]
{
            { "Rook",   "Knight",   "Bishop",   "King",     "Queen",    "Bishop",   "Knight",   "Rook"  },
            { "Pawn",   "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn"  },
            { "Empty",  "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty" },
            { "Empty",  "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty" },
            { "Empty",  "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty" },
            { "Empty",  "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty",    "Empty" },
            { "Pawn",   "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn",     "Pawn"  },
            { "Rook",   "Knight",   "Bishop",   "Queen",    "King",     "Bishop",   "Knight",   "Rook"  },
            };

            Color color;
            string type;
            int[] position;

            for (int i = 0; i < 8; i++) // ROW
            {
                for (int j = 0; j < 8; j++) // COLUMN
                {
                    type = boardSetup[i, j];
                    color = (i < 3) ? Color.Black : Color.White;

                    switch (type)
                    {
                        case "Rook":
                            board[i, j] = new Rook(color, type, i, j);
                            break;
                        case "Knight":
                            board[i, j] = new Knight(color, type, i, j);
                            break;
                        case "Bishop":
                            board[i, j] = new Bishop(color, type, i, j);
                            break;
                        case "King":
                            board[i, j] = new King(color, type, i, j);
                            break;
                        case "Queen":
                            board[i, j] = new Queen(color, type, i, j);
                            break;
                        case "Pawn":
                            board[i, j] = new Pawn(color, type, i, j);
                            break;
                        default:
                            board[i, j] = null;
                            break;
                    }
                }
            }
        }

        public void PrintBoard()
        {
            Console.Write("───────────────────────────┬");
            Console.Write("\n");
            Console.WriteLine("         ══ BLACK ══");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0} ", 8 - i);
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null)
                        Console.Write("[#]");
                    else if (board[i, j] == null)
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.Write("\n");
            }
            Console.Write("   ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0}  ", Convert.ToChar(i + 65));
            }
            Console.Write("\n");
            Console.WriteLine("         ══ WHITE ══");
            Console.Write("───────────────────────────┴");
            Console.Write("\n");
        }

        private void PrintBoardOverlay(Chesspiece piece)
        {
            Console.Write("───────────────────────────┬");
            Console.Write("\n");
            List<int[]> LegalMoves = piece.LegalMoves();
            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0} ", 8 - i);
                for (int j = 0; j < 8; j++)
                {
                    if (i == piece.row && j == piece.column)
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    foreach (int[] legalMove in LegalMoves)
                    {
                        if (legalMove[0] == i && legalMove[1] == j)
                        {
                            if (board[i, j] != null)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else 
                                Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }

                    if (board[i, j] != null)
                        Console.Write("[#]");
                    else if (board[i, j] == null)
                    {
                        Console.Write("[ ]");
                    }

                    Console.ResetColor();
                }
                Console.Write("\n");
            }
            Console.Write("   ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0}  ", Convert.ToChar(i + 65));
            }
            Console.Write("\n");
            Console.Write("───────────────────────────┴");
            Console.Write("\n");
        }



        public Chesspiece GetPiece(int row, int col)
        {
            try {
                if (board[row, col] != null)
                {
                    Console.WriteLine("Selected piece: " + board[row, col].color.ToString() + " " + board[row, col].ToString());
                    PrintBoardOverlay(board[row, col]);
                    return board[row, col];
                } 
                else
                {
                    Console.WriteLine("Slot is empty or out of bounds");
                    return board[0, 0];
                }
            }
            catch
            {
                Console.WriteLine("Slot is empty or out of bounds");
                return board[0, 0];
            }
        }

        public void move(int fromRow, int fromCol, int toRow, int toCol)
        {
            bool success = false;
            if (board[fromRow, fromCol] == null)
            {
                Console.WriteLine("Invalid Move");
                return;
            }

            foreach (int[] legalMove in board[fromRow, fromCol].LegalMoves())
            {
                if (legalMove[0] == toRow && legalMove[1] == toCol)
                {
                    if (board[toRow, toCol] != null && board[toRow, toCol].kind == "King")
                    {
                        PrintBoardOverlay(board[toRow, toCol]);
                        this.isGameOver = true;
                        Console.WriteLine(board[fromRow,fromCol].color + " Won - King Captured");
                        return;
                    }
                    board[toRow, toCol] = board[fromRow, fromCol];
                    board[toRow, toCol].row = toRow;
                    board[toRow, toCol].column = toCol;
                    board[fromRow, fromCol] = null;
                    success = true;
                }
            }
            if (success)
            {
                Console.WriteLine("Move successful");
                success = false;
            }
            else
                Console.WriteLine("Illegal Move");
        }

        public void markBoard(List<string> legalMoves)
        {

        }

        public override string ToString()
        {
            return base.ToString(); 
        }

    }
}
