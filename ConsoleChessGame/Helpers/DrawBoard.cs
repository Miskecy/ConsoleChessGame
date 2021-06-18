using ChessLib;
using System;

namespace ConsoleChessGame.Helpers
{
    public class DrawBoard
    {
        public static void Print(Board myBoard)
        {
            StandartMessages.ClearMessages();
            int rows = 8;
            // print the chess board to the console. Use 'X' for the piece location. '+' for legal move. '.' for empty square
            for (int i = 0; i < myBoard.Size; i++)
            {
                StandartMessages.FreeMessage("+---+---+---+---+---+---+---+---+", true);
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];

                    if (c.CurrentlyOccupied)
                    {
                        StandartMessages.FreeMessage(string.Format("| {0} ", "X"));
                    }
                    else if (c.LegalNextMove)
                    {
                        StandartMessages.FreeMessage(string.Format("| {0} ", "+"));
                    }
                    else
                    {
                        StandartMessages.FreeMessage(string.Format("| {0} ", " "));
                    }
                }
                StandartMessages.FreeMessage(string.Format("| {0}", rows--));
                StandartMessages.FreeMessage("", true);
            }
            StandartMessages.FreeMessage("+---+---+---+---+---+---+---+---+", true);
            StandartMessages.FreeMessage("  A   B   C   D   E   F   G   H", true);

            StandartMessages.FreeMessage("--------------------------", true);
            StandartMessages.FreeMessage(string.Format("Piece choose: {0}", UserInputCapture.CurrentPiece), true);
            StandartMessages.FreeMessage("--------------------------", true);
        }
    }
}
