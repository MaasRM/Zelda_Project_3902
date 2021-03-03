using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class WallmasterStateMachine
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public enum Activity
        {
            Waiting,
            OutWall,
            Moving,
            BackIn
        }

        private Direction initialDirection;
        private Direction secondDirection;
        private Activity activity;
        private IPlayer linkRef;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;
        private const int wallFrames = 10;
        private const int moveFrames = 40;
        private const int PIXELSCALER = 2;
        private const int wallMoveDist = 1;
        private const int floorMoveDist = 3;
        private Tuple<int, int> initial;
        private bool grab;

        public WallmasterStateMachine(int x, int y, IPlayer link, Direction d)
        {
            xLoc = x;
            yLoc = y;
            width = 16;
            height = 16;
            frame = 0;
            initial = new Tuple<int, int>(x, y);
            grab = false;
            activity = Activity.Waiting;
            initialDirection = d;
            linkRef = link;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width * PIXELSCALER, height * PIXELSCALER);
        }

        public Rectangle GetSource()
        {
            if (grab || (activity == Activity.Moving && frame % 2 == 1))
            {
                return new Rectangle(410, 11, width, height);
            }
            else
            {
                return new Rectangle(392, 11, width, height);
            }
        }

        public void Move()
        {

            frame++;

            if (activity == Activity.Waiting)
            {
                CheckLink();
            }

            if (activity == Activity.OutWall)
            {
                if(initialDirection == Direction.Down)
                {
                    yLoc += wallMoveDist * PIXELSCALER;
                }
                else if (initialDirection == Direction.Up)
                {
                    yLoc -= wallMoveDist * PIXELSCALER;
                }
                else if (initialDirection == Direction.Left)
                {
                    xLoc -= wallMoveDist * PIXELSCALER;
                }
                else
                {
                    xLoc += wallMoveDist * PIXELSCALER;
                }
                GetOutWall();
            }
            else if (activity == Activity.Moving)
            {
                if (secondDirection == Direction.Down)
                {
                    yLoc += floorMoveDist * PIXELSCALER;
                }
                else if (secondDirection == Direction.Up)
                {
                    yLoc -= floorMoveDist * PIXELSCALER;
                }
                else if (secondDirection == Direction.Left)
                {
                    xLoc -= floorMoveDist * PIXELSCALER;
                }
                else
                {
                    xLoc += floorMoveDist * PIXELSCALER;
                }
                GrabLink();
                BackInWall();
            }
            else if (activity == Activity.BackIn)
            {
                if (initialDirection == Direction.Down)
                {
                    yLoc -= wallMoveDist * PIXELSCALER;
                }
                else if (initialDirection == Direction.Up)
                {
                    yLoc += wallMoveDist * PIXELSCALER;
                }
                else if (initialDirection == Direction.Left)
                {
                    xLoc += wallMoveDist * PIXELSCALER;
                }
                else
                {
                    xLoc -= wallMoveDist * PIXELSCALER;
                }

                ResetPosition();
            }
        }

        public int GetFrame()
        {
            return frame;
        }

        public bool IsWaiting()
        {
            return activity == Activity.Waiting;
        }

        private void GetOutWall()
        {
            if(frame > wallFrames)
            {
                frame = -1;
                activity = Activity.Moving;
            }
        }

        private void BackInWall()
        {
            if(frame > moveFrames)
            {
                frame = -1;
                activity = Activity.BackIn;
            }
        }

        private void ResetPosition()
        {
            if (frame > wallFrames)
            {
                grab = false;
                frame = 0;
                activity = Activity.Waiting;
                xLoc = initial.Item1;
                yLoc = initial.Item2;
            }
        }

        private void CheckLink()
        {
            Rectangle linkPos = linkRef.LinkPosition();

            int linkX = linkPos.X + linkPos.Width / 2;
            int linkY = linkPos.Y + linkPos.Height / 2;

            if(Math.Abs(linkX - xLoc) < 20 * PIXELSCALER && Math.Abs(linkY - yLoc) < 20 * PIXELSCALER)
            {
                activity = Activity.OutWall;
                frame = 0;

                int num = RandomNumberGenerator.GetInt32(2);

                if(initialDirection == Direction.Down || initialDirection == Direction.Up)
                {
                    if(num == 0)
                    {
                        secondDirection = Direction.Left;
                    }
                    else
                    {
                        secondDirection = Direction.Right;
                    }
                }
                else
                {
                    if (num == 0)
                    {
                        secondDirection = Direction.Up;
                    }
                    else
                    {
                        secondDirection = Direction.Down;
                    }
                }
            }
        }

        private void GrabLink()
        {
            Rectangle linkPos = linkRef.LinkPosition();

            int linkX = linkPos.X + linkPos.Width / 2;
            int linkY = linkPos.Y + linkPos.Height / 2;

            if(linkX >= xLoc && linkX < xLoc + width * PIXELSCALER && linkY > yLoc && linkY < yLoc + height * PIXELSCALER)
            {
                grab = true;
            }
        }

        public Direction GetInitialDirection()
        {
            return initialDirection;
        }

        public Direction GetSecondDirection()
        {
            return secondDirection;
        }
    }
}

