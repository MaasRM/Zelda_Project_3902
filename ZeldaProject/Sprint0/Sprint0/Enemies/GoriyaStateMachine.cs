using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class GoriyaStateMachine
    {
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
        private int frame;
        private bool throwing;
        private int health;
        private int damageFrames;
        private int stunFrames;

        public GoriyaStateMachine(int x, int y, GoriyaColor c)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            color = c;
            throwing = false;
            health = GoriyaConstants.MAXHEALTH;
            state = State.Normal;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, GoriyaConstants.WIDTHANDHEIGHT * GameConstants.SCALE, GoriyaConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            if (direction == Direction.Down || direction == Direction.Up)
            {
                return new Rectangle(222 + 17 * (int)direction, 11 + 17 * (int)color, GoriyaConstants.WIDTHANDHEIGHT, GoriyaConstants.WIDTHANDHEIGHT);
            }
            else
            {
                if (frame % 2 == 0)
                {
                    return new Rectangle(256, 11 + 17 * (int)color, GoriyaConstants.WIDTHANDHEIGHT, GoriyaConstants.WIDTHANDHEIGHT);
                }
                else
                {
                    return new Rectangle(273, 11 + 17 * (int)color, GoriyaConstants.WIDTHANDHEIGHT, GoriyaConstants.WIDTHANDHEIGHT);
                }
            }
        }

        public void Move()
        {
            frame++;
            if (!throwing && state == State.Normal)
            {
                if (frame % 10 == 0) direction = ChangeDirection();

                if (direction == Direction.Up) yLoc -= GoriyaConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Down) yLoc += GoriyaConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Left) xLoc -= GoriyaConstants.moveDist * GameConstants.SCALE;
                else xLoc += GoriyaConstants.moveDist * GameConstants.SCALE;
            }
            else if (state == State.Damaged)
            {
                xLoc += (int)damageDirection.X * GameConstants.SCALE;
                yLoc += (int)damageDirection.Y * GameConstants.SCALE;
                damageFrames++;
            }
            else if (state == State.Stun)
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
            int num = RandomNumberGenerator.GetInt32(GoriyaConstants.CHANGEDIRECTION);

            return (Direction)num;
        }

        private void ThrowChance()
        {
            int num = RandomNumberGenerator.GetInt32(GoriyaConstants.THROWCHANCE);

            if (num % (GoriyaConstants.THROWCHANCE - 1) == 0)
            {
                throwing = true;
                damageFrames = 0;
            }
        }

        public void BoomerangReturned()
        {
            throwing = false;
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

        public bool HasHealth()
        {
            if (health == 0)
            {
                throwing = false;
            }

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

                if (!throwing)
                {
                    damageDirection = direction;
                }
            }
        }

        public void SetStun()
        {
            state = State.Stun;
            stunFrames = 1;
        }

        public int GetDamage()
        {
            if (color == GoriyaColor.Red)
            {
                return GoriyaConstants.REDDAMAGE;
            }
            else
            {
                return GoriyaConstants.BLUEDAMAGE;
            }

        }

        public void ReturnToNormal()
        {
            if (damageFrames > GoriyaConstants.DAMAGEFRAMECOUNT || stunFrames > GoriyaConstants.STUNFRAMECOUNT)
            {
                state = State.Normal;
                stunFrames = 0;
                damageFrames = 0;
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