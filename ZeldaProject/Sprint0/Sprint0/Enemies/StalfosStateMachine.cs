using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        private const int PIXELSCALER = 4;
        private const int moveDist = 2;

        public StalfosStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            width = 16;
            height = 16;
            frame = -1;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width * PIXELSCALER, height * PIXELSCALER);
        }

        public Rectangle GetSource()
        {
            return new Rectangle(1, 59, width, height);
        }

        public void Move()
        {
            frame++;

            if (frame % 8 == 0)
            {
                direction = ChangeDirection();
            }

            if(direction == Direction.Up)
            {
                yLoc -= moveDist * PIXELSCALER;
            }

            else if (direction == Direction.Down)
            {
                yLoc += moveDist * PIXELSCALER;
            }

            else if (direction == Direction.Left)
            {
                xLoc -= moveDist * PIXELSCALER;
            }
            else
            {
                xLoc += moveDist * PIXELSCALER;
            }
        }

        public int GetFrame()
        {
            return frame;
        }

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(4);

            return (Direction) num;
        }
    }
}
