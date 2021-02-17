﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class GoriyaStateMachine
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

        public GoriyaStateMachine(int x, int y, int xLen, int yLen)
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

            if (direction == Direction.Up)
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
            Random rnd = new Random();
            int num = rnd.Next(0, 3);

            return (Direction)num;
        }
    }
}