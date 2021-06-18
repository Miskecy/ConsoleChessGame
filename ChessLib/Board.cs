using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Board
    {
        // the size of the board usually 8x8
        public int Size { get; set; }

        //2D array of type Cell.
        public Cell[,] theGrid { get; set; }

        //constructor
        public Board(int s)
        {
            //initial size of the board is defined by s.
            Size = s;

            //create a new 2D array of tipe cell.
            theGrid = new Cell[Size, Size];

            //fill the 2D array with new Cells, each with unique x and y coordinates.
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            //clear all previos legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }
            //find all legal moves and mark the cells as "legal"
            switch (chessPiece)
            {
                case "Knight":
                    if (isSafe(currentCell.RowNumber -2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    
                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    
                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    
                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;

                case "King":
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    break;

                case "Rook":                    
                    for (int i = 0; i < 8; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    break;

                case "Bishop":
                    for (int i = 0; i < 8; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    break;

                case "Queen":  
                    for (int i = 0; i < 8; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    break;

                case "Pawn":
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber].LegalNextMove = true;

                    break;

                default:
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }

        private bool isSafe(int x, int y)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
            {
                //Console.WriteLine(string.Format("Pos \"{0}\", \"{1}\" is NOT safe.", x, y));
                return false;
            }
            else
            {
                //Console.WriteLine(string.Format("Pos \"{0}\", \"{1}\" is safe.", x, y));
                return true;
            }
        }
    }
}
