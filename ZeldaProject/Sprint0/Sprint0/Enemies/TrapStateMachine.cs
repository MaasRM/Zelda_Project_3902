using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class TrapStateMachine
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }

        public enum Activity
        {
            Charging,
            Returning,
            Still
        }

        private Direction direction;
        private Activity active;
        private IPlayer linkRef;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;
        private int maxX, minX, maxY, minY;
        private const int PIXELSCALER = 2;
        private const int chargeMoveDist = 4;
        private const int returnMoveDist = 2;
        private Tuple<int, int> initial;

        public TrapStateMachine(int x, int y, IPlayer link)
        {
            xLoc = x;
            yLoc = y;
            width = 16;
            height = 16;
            frame = -1;
            linkRef = link;
            maxX = 800 - width * PIXELSCALER;
            minX = 0;
            maxY = 800 - height * PIXELSCALER;
            minY = 0;
            initial = new Tuple<int, int>(x, y);
            active = Activity.Still;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width * PIXELSCALER, height * PIXELSCALER);
        }

        public Rectangle GetSource()
        {
            return new Rectangle(164, 59, width, height);
        }

        public void Move()
        {
            frame++;

            if(active == Activity.Still)
            {
                CheckLink();
            }

            if(active == Activity.Charging)
            {
                if(direction == Direction.Down)
                {
                    yLoc += chargeMoveDist * PIXELSCALER;
                }
                else if (direction == Direction.Up)
                {
                    yLoc -= chargeMoveDist * PIXELSCALER;
                }
                else if (direction == Direction.Left)
                {
                    xLoc -= chargeMoveDist * PIXELSCALER;
                }
                else
                {
                    xLoc += chargeMoveDist * PIXELSCALER;
                }

                ShouldReturn();
            }
            else if (active == Activity.Returning)
            {
                if (direction == Direction.Down)
                {
                    yLoc -= returnMoveDist * PIXELSCALER;
                }
                else if (direction == Direction.Up)
                {
                    yLoc += returnMoveDist * PIXELSCALER;
                }
                else if (direction == Direction.Left)
                {
                    xLoc += returnMoveDist * PIXELSCALER;
                }
                else
                {
                    xLoc -= returnMoveDist * PIXELSCALER;
                }

                Returned();
            }
        }

        public int GetFrame()
        {
            return frame;
        }

        private void CheckLink()
        {
            Rectangle linkPos = linkRef.LinkPosition();

            int linkX = linkPos.X + linkPos.Width / 2;
            int linkY = linkPos.Y + linkPos.Height / 2;

            if(linkX >= xLoc && linkX < xLoc + width)
            {
                if(linkY < yLoc)
                {
                    direction = Direction.Up;
                    active = Activity.Charging;
                }
                else
                {
                    direction = Direction.Down;
                    active = Activity.Charging;
                }
            }
            else if (linkY >= yLoc && linkY < yLoc + height)
            {
                if (linkX < xLoc)
                {
                    direction = Direction.Left;
                    active = Activity.Charging;
                }
                else
                {
                    direction = Direction.Right;
                    active = Activity.Charging;
                }
            }
        }

        private void ShouldReturn()
        {
            if(direction == Direction.Down && yLoc >= maxY)
            {
                active = Activity.Returning;
            }
            else if (direction == Direction.Up && yLoc <= minY)
            {
                active = Activity.Returning;
            }
            else if (direction == Direction.Left && xLoc <= minX)
            {
                active = Activity.Returning;
            }
            else if (direction == Direction.Right && xLoc >= maxX)
            {
                active = Activity.Returning;
            }
        }

        private void Returned()
        {
            if(initial.Item1 == xLoc && initial.Item2 == yLoc)
            {
                active = Activity.Still;
            }
        }
    }
}

