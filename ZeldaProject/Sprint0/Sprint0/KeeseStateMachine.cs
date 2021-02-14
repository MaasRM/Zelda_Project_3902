using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class KeeseStateMachine
    {
        public enum Direction
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        }

        private Direction direction;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;

        public KeeseStateMachine(int x, int y, int xLen, int yLen)
        {
            xLoc = x;
            yLoc = y;
            width = xLen;
            height = yLen;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width, height);
        }

        public Rectangle GetSource()
        {
            return new Rectangle(1, 59, width, height);
        }

        public void move(int frame)
        {
            if (frame % 20 == 0)
            {
                direction = changeDirection();
            }

            if (direction == Direction.North)
            {
                yLoc -= 5;
            }
            else if (direction == Direction.NorthEast)
            {
                
            }
            else if (direction == Direction.East)
            {
                xLoc += 5;
            }
            else if (direction == Direction.SouthEast)
            {

            }
            else if (direction == Direction.South)
            {
                yLoc += 5;
            }
            else if (direction == Direction.SouthWest)
            {

            }
            else if (direction == Direction.West)
            {
                xLoc -= 5;
            }
        }

        private static Direction changeDirection()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 7);

            return (Direction)num;
        }
    }
}
