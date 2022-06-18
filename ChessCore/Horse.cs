/* 
    Vasilev Roman 220P,
    Chessmen3-Horse,
    12.04.22
 */

using System;
namespace ChessCore
{
    public class Horse : ChessPiece
    {
        public Horse(int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;
        }

        public Horse(string str) : base(str)
        {
            this.x = positionsCharInt[str[0]];
            this.y = int.Parse(str[1].ToString());
        }

        protected override bool isRightMove(int x2, int y2)
        {
            return ((Math.Abs(x2 - x) == 1 && Math.Abs(y2 - y) == 2) ||
                (Math.Abs(x2 - x) == 2 && Math.Abs(y2 - y) == 1));
        }
    }
}
