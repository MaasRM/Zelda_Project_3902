﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        private const int PIXELSCALER = 2;
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
            return new Rectangle(xLoc, yLoc, width * PIXELSCALER, height * PIXELSCALER);
        }

        public Rectangle GetSource()
        {
            if (frame % 2 == 0)
            {
                return new Rectangle(1 + 18 * ((int)color % 4), 11 + 17 * ((int)color % 2), width, height);
            }
            else
            {
                return new Rectangle(10 + 18 * ((int)color % 4), 11 + 17 * ((int)color % 2), width, height);
            }
        }

        public void Move()
        {
            frame++;

            if(frame > waitFrames || frame > moveFrames)
            {
                wait = !wait;
                frame = 0;
                waitFrames = (RandomNumberGenerator.GetInt32(6) + 2) * 5;
            }

            if(frame == 0)
            {
                direction = ChangeDirection();
            }

            if(!wait)
            {
                if (direction == Direction.Up)
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
        }

        public int GetFrame()
        {
            return frame;
        }

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(4);

            return (Direction)num;
        }
    }
}
