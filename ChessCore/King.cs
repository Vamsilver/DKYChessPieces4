/* 
    Vasilev Roman 220P,
    Chessmen3-King,
    12.04.22
 */

using System;

namespace ChessCore
{
    public class King : ChessPiece
    {
        public King(int x, int y) : base(x,y)
        {
            this.x = x;
            this.y = y;
            this.name = "King";
        }

        public King(string str) : base(str)
        {
            this.x = positionsCharInt[str[0]];
            this.y = int.Parse(str[1].ToString());
            this.name = "King";
        }

        protected override bool isRightMove(int x2, int y2)
        {
            return Math.Abs(x2 - x) <= 1 && Math.Abs(y2 - y) <= 1;
        }
    }
}
