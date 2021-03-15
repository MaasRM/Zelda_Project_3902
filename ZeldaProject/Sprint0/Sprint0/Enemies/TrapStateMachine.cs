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
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;
        private const int PIXELSCALER = 4;
        private const int chargeMoveDist = 4;
        private const int returnMoveDist = 2;
        private const int DAMAGE = 4;
        private Tuple<int, int> initial;

        public TrapStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            width = 16;
            height = 16;
            frame = -1;
            initial = new Tuple<int, int>(x, y);
            active = Activity.Still;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width * PIXELSCALER, height * PIXELSCALER);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            return new Rectangle(164, 59, width, height);
        }

        public void Move()
        {
            frame++;

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

        public void SetCharge(Rectangle linkPos)
        {
            if(IsStill())
            {
                int linkX = linkPos.X + linkPos.Width / 2;
                int linkY = linkPos.Y + linkPos.Height / 2;

                active = Activity.Charging;

                if (linkX >= xLoc && linkX < xLoc + width)
                {
                    if (linkPos.Y < yLoc)
                    {
                        direction = Direction.Up;
                    }
                    else
                    {
                        direction = Direction.Down;
                    }
                }
                else if (linkY >= yLoc && linkY < yLoc + height)
                {
                    if (linkPos.X < xLoc)
                    {
                        direction = Direction.Left;
                    }
                    else
                    {
                        direction = Direction.Right;
                    }
                }
            }
        }

        private void Returned()
        {
            if(active == Activity.Returning)
            {
                if (direction == Direction.Down && yLoc <= initial.Item2)
                {
                    active = Activity.Still;
                    xLoc = initial.Item1;
                    yLoc = initial.Item2;
                }
                else if (direction == Direction.Up && yLoc >= initial.Item2)
                {
                    active = Activity.Still;
                    xLoc = initial.Item1;
                    yLoc = initial.Item2;
                }
                else if (direction == Direction.Left && xLoc >= initial.Item1)
                {
                    active = Activity.Still;
                    xLoc = initial.Item1;
                    yLoc = initial.Item2;
                }
                else if (direction == Direction.Right && xLoc <= initial.Item1)
                {
                    active = Activity.Still;
                    xLoc = initial.Item1;
                    yLoc = initial.Item2;
                }
            }
        }

        public bool IsStill()
        {
            return active == Activity.Still;
        }

        public void Return()
        {
            if(active == Activity.Charging)
            {
                active = Activity.Returning;
            }
        }

        public int GetDamage()
        {
            return DAMAGE;
        }
    }
}

