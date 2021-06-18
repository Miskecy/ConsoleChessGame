using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessGame.Helpers
{
    public class StandartMessages
    {
        public static void EnterMessage(string str, bool cw = false)
        {
            if (cw) Console.WriteLine(string.Format("[+] Enter the current {0}: ", str));
            else Console.Write(string.Format("[+] Enter the current {0}: ", str));
        }

        public static void OutOfRangeMessage(string str)
        {
            Console.WriteLine(string.Format("\n[-] Out of Range! Max value is 8 and you choose {0}!", str));
        }

        public static void WrongPieceChooseMessage(string str)
        {
            Console.WriteLine(string.Format("\n[-] Invalid piece choosed > {0} <, please enter a valid Chess piece: [ Knight, King, Queen, Bishop, Rook, Pawn ]!", str));
        }

        public static void InvalidCoodsMessage<T>(T str)
        {
            Console.WriteLine(string.Format("[-] Invalid coordinates: {0}", str));
        }

        public static void FreeMessage<T>(T str, bool cw = false)
        {
            if (cw) Console.WriteLine(str);
            else Console.Write(str);
        }

        public static void ClearMessages()
        {
            Console.Clear();
        }
    }
}
