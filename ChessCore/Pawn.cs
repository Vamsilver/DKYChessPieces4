using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    class Pawn : ChessPiece
    {
        public Pawn(string position) : base(position)
        {
            this.x = positionsCharInt[position[0]];
            this.y = int.Parse(position[1].ToString());
            this.name = "Pawn";
        }

        public Pawn(int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.name = "Pawn";
        }

        protected override bool isRightMove(int x2, int y2)
        {
            return x == x2 && y2 - y <= 1;
        }
    }
}
