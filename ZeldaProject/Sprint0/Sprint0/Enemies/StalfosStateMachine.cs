using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class StalfosStateMachine
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private Direction direction;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;

        public StalfosStateMachine(int x, int y, int xLen, int yLen)
        {
            xLoc = x;
            yLoc = y;
            width = xLen;
            height = yLen;
            frame = -1;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width, height);
        }

        public Rectangle GetSource()
        {
            return new Rectangle(1, 59, width, height);
        }

        public void move()
        {
            frame++;

            if (frame % 20 == 0)
            {
                direction = changeDirection();
            }

            if(direction == Direction.Up)
            {
                yLoc -= 5;
            }

            else if (direction == Direction.Down)
            {
                yLoc += 5;
            }

            else if (direction == Direction.Left)
            {
                xLoc -= 5;
            }
            else
            {
                xLoc += 5;
            }
        }

        public int getFrame()
        {
            return frame;
        }

        private static Direction changeDirection()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 3);

            return (Direction) num;
        }
    }
}
