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

        private enum State
        {
            Normal,
            Damaged,
            Stun
        }

        private Direction direction;
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
        private int MAXHEALTH = 2;
        private const int PIXELSCALER = 4;
        private const int moveDist = 2;

        public StalfosStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            width = 16;
            height = 16;
            frame = -1;
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
            return new Rectangle(1, 59, width, height);
        }

        public void Move()
        {
            if(state == State.Normal || (state == State.Damaged && damageDirection == new Vector2(0,0)))
            {
                frame++;

                if (frame % 8 == 0)
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

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(4);

            return (Direction) num;
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

                damageDirection = direction;
            }
        }

        public void SetStun()
        {
            state = State.Stun;
            stunFrames = 0;
        }

        public void ReturnToNormal()
        {
            if (damageFrames > 24 || stunFrames > 60)
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
    }
}
