/* 
    Vasilev Roman 220P,
    Chessmen3-Bishop,
    12.04.22
 */

using System;

namespace ChessCore
{
    public class Bishop : ChessPiece
    {
        public Bishop(int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.name = "Bishop";
        }

        public Bishop(string str) : base(str)
        {
            this.x = positionsCharInt[str[0]];
            this.y = int.Parse(str[1].ToString());
            this.name = "Bishop";
        }

        protected override bool isRightMove(int x2, int y2)
        {
            return (Math.Abs(y2 - y) == Math.Abs(x2 - x));
        }
    }
}
