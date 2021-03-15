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

        private enum State
        {
            Normal,
            Damaged,
            Stun
        }

        private Direction initialDirection;
        private Direction secondDirection;
        private Activity activity;
        private State state;
        private Vector2 damageDirection;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;
        private int stunFrames;
        private int damageFrames;
        private int health;
        private int MAXHEALTH = 4;
        private const int wallFrames = 10;
        private const int moveFrames = 40;
        private const int PIXELSCALER = 4;
        private const int wallMoveDist = 1;
        private const int floorMoveDist = 3;
        private Tuple<int, int> initial;
        private bool grab;

        public WallmasterStateMachine(int x, int y, Direction d)
        {
            xLoc = x;
            yLoc = y;
            width = 16;
            height = 16;
            frame = 0;
            health = 0;
            initial = new Tuple<int, int>(x, y);
            grab = false;
            activity = Activity.Waiting;
            initialDirection = d;
            stunFrames = 0;
            damageFrames = 0;
            health = MAXHEALTH;
            state = State.Normal;
            damageDirection = new Vector2(0, 0);
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

            if (state == State.Normal)
            {
                frame++;

                if (activity == Activity.OutWall)
                {
                    if (initialDirection == Direction.Down)
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
            else if(state == State.Damaged)
            {
                xLoc += (int)damageDirection.X;
                yLoc += (int)damageDirection.Y;
                damageFrames++;
            }
            else if(state == State.Stun)
            {
                stunFrames++;
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

        public void SetWallmaster()
        {
            activity = Activity.OutWall;
            frame = 0;

            int num = RandomNumberGenerator.GetInt32(2);

            if (initialDirection == Direction.Down || initialDirection == Direction.Up)
            {
                if (num == 0)
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

        public void GrabLink()
        {
            if(activity == Activity.OutWall)
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

        public bool GetGrabStatus()
        {
            return grab;
        }

        public bool HasHealth()
        {
            return health > 0;
        }

        public void TakeDamage(int damage, Vector2 direction)
        {
            if (state != State.Damaged)
            {
                health -= damage;
                state = State.Damaged;
                stunFrames = 1;
                damageFrames = 1;

                damageDirection = direction;
            }
        }

        public void SetStun()
        {
            state = State.Stun;
            stunFrames = 1;
        }

        public void ReturnToNormal()
        {
            if (damageFrames > 12 || stunFrames > 30)
            {
                state = State.Normal;
                stunFrames = 0;
                damageFrames = 0;
                damageDirection = new Vector2(0, 0);
            }
        }

        public bool IsDamaged()
        {
            return state == State.Damaged;
        }

        public int GetDamageFrame()
        {
            return damageFrames;
        }
    }
}

