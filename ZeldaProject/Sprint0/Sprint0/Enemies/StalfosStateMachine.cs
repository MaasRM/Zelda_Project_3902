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
        private const int SCALER = 2;
        private const int moveDist = 2;

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
            return new Rectangle(xLoc, yLoc, width * SCALER, height * SCALER);
        }

        public Rectangle GetSource()
        {
            return new Rectangle(1, 59, width, height);
        }

        public void move()
        {
            frame++;

            if (frame % 5 == 0)
            {
                direction = changeDirection();
            }

            if(direction == Direction.Up)
            {
                yLoc -= moveDist * SCALER;
            }

            else if (direction == Direction.Down)
            {
                yLoc += moveDist * SCALER;
            }

            else if (direction == Direction.Left)
            {
                xLoc -= moveDist * SCALER;
            }
            else
            {
                xLoc += moveDist * SCALER;
            }
        }

        public int getFrame()
        {
            return frame;
        }

        private static Direction changeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(4);

            return (Direction) num;
        }
    }
}
