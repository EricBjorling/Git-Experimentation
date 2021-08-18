using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Chesspiece selectedPiece = null;
            Chessboard chessboard = new Chessboard();
            while (!chessboard.isGameOver)
            {
                Console.WriteLine("1 = GetPiece(row, column)");
                Console.WriteLine("2 = Move(initRow, initCol, toRow, toCol)");
                Console.WriteLine("3 = PrintBoard()");
                Console.WriteLine("───────────────────────────┼");
                Console.Write("Choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    int selectedRow;
                    int selectedCol;
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Row: ");
                            selectedRow = int.Parse(Console.ReadLine());
                            Console.Write("Enter Column: ");
                            selectedCol = int.Parse(Console.ReadLine());

                            selectedPiece = chessboard.GetPiece(selectedRow, selectedCol);
                            break;
                        case 2:
                            Console.Write("Enter initial Row: ");
                            selectedRow = int.Parse(Console.ReadLine());
                            Console.Write("Enter initial Column: ");
                            selectedCol = int.Parse(Console.ReadLine());

                            Console.Write("Enter final Row: ");
                            int finalRow = int.Parse(Console.ReadLine());
                            Console.Write("Enter final Column:" );
                            int finalCol = int.Parse(Console.ReadLine());

                            chessboard.move(selectedRow, selectedCol, finalRow, finalCol);
                            break;
                        case 3:
                            chessboard.PrintBoard();
                            break;
                    }
                    
                }
            }

           
            Console.ReadKey();
        }
    }
}
