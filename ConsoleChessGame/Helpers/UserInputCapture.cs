using ChessLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessGame.Helpers
{
    public class UserInputCapture
    {
        private static int _currentRow { get; set; }
        private static int _currentColumn { get; set; }
        private static string _currentPiece { get; set; }

        private static Cell _currentCell;

        public static Cell CurrentCell
        {
            get { return _currentCell; }
            set { _currentCell = value; }
        }

        public static string CurrentPiece
        {
            get 
            {                
                return _currentPiece; 
            }
            set 
            { 
                _currentPiece = value; 
            }
        }

        public static string GetCurrentPiece
        {
            get
            {
                GetUserPieceChoose();
                return _currentPiece;
            }
            set
            {
                _currentPiece = value;
            }
        }

        private static bool _isChooseCoods { get; set; } = false;
        private static bool _isChoosePiece { get; set; } = false;

        private static void GetUserCoodsChoose()
        {
            Console.Clear();
            while (!_isChooseCoods)
            {                
                try
                {
                    do
                    {
                        StandartMessages.FreeMessage("--------------------------", true);
                        StandartMessages.EnterMessage("row number");
                        _currentRow = int.Parse(Console.ReadLine());
                        if (_currentRow > 7) StandartMessages.OutOfRangeMessage(_currentRow.ToString());

                    } while (_currentRow < 0 || _currentRow > 7);

                    do
                    {
                        StandartMessages.FreeMessage("--------------------------", true);
                        StandartMessages.EnterMessage("column number");
                        _currentColumn = int.Parse(Console.ReadLine());
                        if (_currentColumn > 7) StandartMessages.OutOfRangeMessage(_currentColumn.ToString());

                    } while (_currentColumn < 0 || _currentColumn > 7);

                    Console.Clear();
                    _isChooseCoods = true;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    StandartMessages.InvalidCoodsMessage(e.Message);                 
                }
            }
        }

        private static void GetUserPieceChoose()
        {
            string[] pieces = { "Knight", "King", "Queen", "Bishop", "Rook", "Pawn" };
            Console.Clear();
            while (!_isChoosePiece)
            {
                int selectedPiece = 0;
                StandartMessages.FreeMessage("--------------------------", true);
                StandartMessages.EnterMessage("piece who you want to play! [ Knight, King, Queen, Bishop, Rook, Pawn ]", true);

                for (int i = 0; i < pieces.Length; i++)
                {
                    StandartMessages.FreeMessage(string.Format("{0} - {1}", i + 1 , pieces[i]), true);
                }
                StandartMessages.FreeMessage("Option: ");
                selectedPiece = int.Parse(Console.ReadLine());

                if (pieces.Contains(pieces[selectedPiece - 1]))
                {
                    _currentPiece = pieces[selectedPiece - 1];
                    _isChoosePiece = true;
                }
            }
        }

        public static void GetCurrentCellChoose(Board myBoard)
        {
            //get x and y coordinates from the user. return a cell location.
            GetUserCoodsChoose();

            myBoard.theGrid[_currentRow, _currentColumn].CurrentlyOccupied = true;
            _currentCell = myBoard.theGrid[_currentRow, _currentColumn];

            _currentCell.CurrentlyOccupied = true;
            _isChooseCoods = false;
        }
    }
}
