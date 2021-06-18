using ChessLib;
using ConsoleChessGame.Helpers;
using System;

namespace ConsoleChessGame
{
    class Program
    {
        static Board myBoard = new(8);
        private static bool _continue { get; set; } = true;
        static void Main(string[] args)
        {
            while (_continue)
            {
                //show the empty chess board.
                //DrawBoard.Print(myBoard);

                //ask the user for an x and y coordinate where we will place a piece.
                UserInputCapture.GetCurrentCellChoose(myBoard);

                //calculate all legal moves for that piece.
                myBoard.MarkNextLegalMoves(UserInputCapture.CurrentCell, UserInputCapture.GetCurrentPiece);

                //print the chess board. Use an X for occupied square. Use a + for legal move. Use . for empty cell.
                DrawBoard.Print(myBoard);

                StandartMessages.FreeMessage("[!] Write \"Exit\" to close, or press enter to select another piece!", true);
                string choose = Console.ReadLine();

                if (choose.Equals("Exit") || choose.Equals("exit")) _continue = false;
            }
        }               
    }
}
