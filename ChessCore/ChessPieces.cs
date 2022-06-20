using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    public class ChessPieces
    {
        public List<ChessPiece> chesses;

        public ChessPieces()
        {
            chesses = new List<ChessPiece>();
        }

        public void Add(ChessPiece chess)
        {
            chesses.Add(chess);
        }

        public void PopBack()
        {
            if(chesses.Count != 0)
            {
                chesses.RemoveAt(chesses.Count - 1);
            }
        }

        public ChessPiece Find(ChessPiece chess)
        {
            foreach(var s in chesses)
            {
                if(chess.GetName().Equals(s.GetName()))
                {
                    return s;
                }
            }

            return null;
        }

        public ChessPiece Find(string chessName)
        {
            foreach (var s in chesses)
            {
                if (chessName.Equals(s.GetName()))
                {
                    return s;
                }
            }

            return null;
        }

        public void Delete(ChessPiece chess)
        {
            ChessPiece chess2 = Find(chess);

            if (chess2 != null)
            {
                chesses.Remove(chess2);
            }
        }

        public void Delete(string chessName)
        {
            ChessPiece chess2 = Find(chessName);

            if (chess2 != null)
            {
                chesses.Remove(chess2);
            }
        }

        public void Replace(ChessPiece chess)
        {
            ChessPiece chess2 = Find(chess);

            if(chess2 != null)
            {
                chesses.Remove(chess2);
                chesses.Add(chess);
            }
        }

        public void Clear()
        {
            chesses.Clear();
        }
    }
}
