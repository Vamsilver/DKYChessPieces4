/* 
    Vasilev Roman 220P,
    Chessmen3-Queen,
    12.04.22
 */

using System;
namespace ChessCore
{
    public class Queen : ChessPiece
    {
        public Queen(int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;
        }

        public Queen(string str) : base(str)
        {
            this.x = positionsCharInt[str[0]];
            this.y = int.Parse(str[1].ToString());
        }

        protected override bool isRightMove(int x2, int y2)
        {
            return ((x - x2 == 0 || y - y2 == 0) || (Math.Abs(x - x2) == Math.Abs(y - y2)));
        }
    }
}
