using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class GoriyaStateMachine
    {
        public enum Direction
        {
            Down,
            Up,
            Left,
            Right
        }

        public enum GoriyaColor
        {
            Red,
            Blue
        }

        private Direction direction;
        private GoriyaColor color;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;
        private bool throwing;
        private const int PIXELSCALER = 2;
        private const int moveDist = 2;

        public GoriyaStateMachine(int x, int y, GoriyaColor c)
        {
            xLoc = x;
            yLoc = y;
            width = 16;
            height = 16;
            frame = -1;
            color = c;
            throwing = false;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width * PIXELSCALER, height * PIXELSCALER);
        }

        public Rectangle GetSource()
        {
            if(direction == Direction.Down || direction == Direction.Up)
            {
                return new Rectangle(222 + 17 * (int)direction, 11 + 17 * (int)color, width, height);
            }
            else
            {
                if(frame % 2 == 0)
                {
                    return new Rectangle(256, 11 + 17 * (int)color, width, height);
                }
                else
                {
                    return new Rectangle(273, 11 + 17 * (int)color, width, height);
                }
            }
        }

        public void Move()
        {
            frame++;

            if(!throwing)
            {
                if (frame % 5 == 0)
                {
                    direction = ChangeDirection();
                }

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

        public Direction GetDirection()
        {
            return direction;
        }

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(4);

            return (Direction)num;
        }

        private void ThrowChance()
        {
            int num = RandomNumberGenerator.GetInt32(100);

            if(num % 17 == 0)
            {
                throwing = !throwing;
            }
        }

        public void BoomerangReturned()
        {
            throwing = !throwing;
        }

        public bool TryToThrow()
        {
            ThrowChance();
            return throwing;
        }

        public bool Throwing()
        {
            return throwing;
        }

        public int GetWidth()
        {
            return width * PIXELSCALER;
        }

        public int GetHeight()
        {
            return height * PIXELSCALER;
        }
    }
}
