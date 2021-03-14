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

        private enum State
        {
            Normal,
            Damaged,
            Stun
        }

        private Direction direction;
        private GoriyaColor color;
        private State state;
        private Vector2 damageDirection;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;
        private bool throwing;
        private int health;
        private int damageFrames;
        private int stunFrames;
        private const int MAXHEALTH = 3;
        private const int PIXELSCALER = 4;
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

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
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
            if(!throwing && state == State.Normal)
            {
                if (frame % 10 == 0)
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
                frame++;
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

            ReturnToNormal();
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
                stunFrames = 0;
                damageFrames = 0;

                if(!throwing)
                {
                    damageDirection = direction;
                }
            }
        }

        public void SetStun()
        {
            state = State.Stun;
            stunFrames = 0;
        }

        public int GetDamage()
        {
            if(color == GoriyaColor.Red)
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }

        public void ReturnToNormal()
        {
            if(damageFrames > 24 || stunFrames > 60)
            {
                state = State.Normal;
            }
        }
    }
}
