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

        public void Clear()
        {
            chesses.Clear();
        }
    }
}
