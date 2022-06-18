using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    public static class ChessFactory
    {
        public static ChessPiece MakeChess(string chessCode, string coords)
        {
            int x = int.Parse(coords[0].ToString());
            int y = int.Parse(coords[1].ToString());

            return MakeChess(chessCode, x, y);
        }

        public static ChessPiece MakeChess(string chessCode, int x, int y)
        {
            ChessPiece chess;

            switch(chessCode)
            {
                case "K":
                case "King":
                case "k":
                case "king":
                    chess = new King(x,y);
                    break;

                case "B":
                case "Bishop":
                case "b":
                case "bishop":
                    chess = new Bishop(x, y);
                    break;

                case "H":
                case "Horse":
                case "h":
                case "horse":
                    chess = new Horse(x, y);
                    break;

                case "Q":
                case "Queen":
                case "q":
                case "queen":
                    chess = new Queen(x, y);
                    break;

                case "R":
                case "Rook":
                case "r":
                case "rook":
                    chess = new Rook(x, y);
                    break;
                case "P":
                case "Pawn":
                case "p":
                case "pawn":
                    chess = new Pawn(x, y);
                    break;

                default: throw new Exception("Unknown chess");
            }
            return chess;
        }
    }
}
