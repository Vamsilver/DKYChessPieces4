using System;
using ChessCore;

namespace ChessPiecesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ChessPiece chessPiece;
                string chessCode;
                string coords1;
                string coords2;

                Console.WriteLine("Введите фигур, если хотите выйти, то напишите exit");
                chessCode = Console.ReadLine();

                if (chessCode.Equals("exit"))
                {
                    break;
                }

                Console.WriteLine("Введите изначальные координаты,например 11");
                coords1 = Console.ReadLine();

                Console.WriteLine("Введите координаты,где хотите сходить, например 11");
                coords2 = Console.ReadLine();

                try
                {
                    chessPiece = ChessFactory.MakeChess(chessCode, coords1);
                    Console.WriteLine(chessPiece.TryMoveString(coords2) ? "Yes" : "NO");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
