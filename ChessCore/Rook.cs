/* 
    Vasilev Roman 220P,
    Chessmen3-Rook,
    12.04.22
 */

namespace ChessCore
{
    public class Rook : ChessPiece
    {
        public Rook(int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;
        }

        public Rook(string str) : base(str)
        {
            this.x = positionsCharInt[str[0]];
            this.y = int.Parse(str[1].ToString());
        }

        protected override bool isRightMove(int x2, int y2)
        {
            return (x == x2 || y == y2);
        }
    }
}
