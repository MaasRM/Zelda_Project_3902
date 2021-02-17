using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class GelStateMachine
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public enum GelColor
        {
            Teal,
            Emerald,
            Blue,
            Orange,
            Green,
            Grey,
            Oil,
            Black
        }

        private Direction direction;
        private GelColor color;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;
        private const int moveDist = 2;
        private bool wait;
        private int waitFrames;
        private const int moveFrames = 10;


        public GelStateMachine(int x, int y, int xLen, int yLen, GelColor c)
        {
            xLoc = x;
            yLoc = y;
            width = xLen;
            height = yLen;
            frame = -1;
            color = c;
            wait = false;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width, height);
        }

        public Rectangle GetSource()
        {
            return new Rectangle(1 + 19*((int)color % 4), 11 + 17 *((int)color % 2), width, height);
        }

        public void move()
        {
            frame++;

            if (frame % 5 == 0)
            {
                direction = changeDirection();
            }

            if (direction == Direction.Up)
            {
                yLoc -= moveDist;
            }

            else if (direction == Direction.Down)
            {
                yLoc += moveDist;
            }

            else if (direction == Direction.Left)
            {
                xLoc -= moveDist;
            }
            else
            {
                xLoc += moveDist;
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

            return (Direction)num;
        }
    }
}
