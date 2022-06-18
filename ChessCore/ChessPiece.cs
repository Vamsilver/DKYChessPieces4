/* 
    Vasilev Roman 220P,
    Chessmen3-ChessPiece,
    12.04.22
 */

using System;
using System.Collections.Generic;

namespace ChessCore
{
    public class ChessPiece
    {
        protected int x; 
        protected int y; 

        protected Dictionary<char, int> positionsCharInt = new Dictionary<char, int>()
        {
            {'A', 1},
            {'B', 2},
            {'C', 3},
            {'D', 4},
            {'E', 5},
            {'F', 6},
            {'G', 7},
            {'H', 8},
        };

        protected Dictionary<int, char> positionsIntChar = new Dictionary<int, char>()
        {
            {1, 'A'},
            {2, 'B'},
            {3, 'C'},
            {4, 'D'},
            {5, 'E'},
            {6, 'F'},
            {7, 'G'},
            {8, 'H'},
        };

        public ChessPiece(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public ChessPiece(string position)
        {
            this.x = positionsCharInt[position[0]];
            this.x = int.Parse(position[1].ToString());
        }

        protected virtual bool isRightMove(int x, int y) { return true; }

        public void Move(int x2, int y2)
        {
            if (isRightMove(x2, y2))
            {
                this.x = x2;
                this.y = y2;
            }
            else
            {
                throw new Exception("Impossible move");
            }
        }

        public void Move(string position)
        {
            int x2 = positionsCharInt[position[0]];
            int y2 = int.Parse(position[1].ToString());

            Move(x2, y2);
        }

        public bool TryMoveInt(int x2, int y2)
        {
            return isRightMove(x2, y2);
        }

        public bool TryMoveString(string position)
        {
            int x2 = int.Parse(position[0].ToString());
            int y2 = int.Parse(position[1].ToString());

            return TryMoveInt(x2, y2);
        }

        public bool TryMoveChar(string position)
        {
            int x2 = positionsCharInt[position[0]];
            int y2 = int.Parse(position[1].ToString());

            return TryMoveInt(x2, y2);
        }


        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public string GetPosition()
        {
            return positionsIntChar[x] + "" + y;
        }
    }
}