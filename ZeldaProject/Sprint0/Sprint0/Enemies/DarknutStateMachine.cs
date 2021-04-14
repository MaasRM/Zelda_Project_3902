using Microsoft.Xna.Framework;
using System;
using System.Security.Cryptography;

namespace Sprint0
{
    public class DarknutStateMachine
    {
        public enum DarknutColor
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
        private DarknutColor color;
        private State state;
        private Vector2 damageDirection;
        private int xLoc;
        private int yLoc;
        private int frame;
        private int health;
        private int damageFrames;
        private int stunFrames;

        public DarknutStateMachine(int x, int y, DarknutColor c)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            color = c;
            if (color == DarknutColor.Red) health = DarknutConstants.REDMAXHEALTH;
            else health = DarknutConstants.BLUEMAXHEALTH;
            state = State.Normal;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, DarknutConstants.WIDTHANDHEIGHT * GameConstants.SCALE, DarknutConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            if (direction == Direction.Up)
            {
                return new Rectangle(35, 90 + 17 * (int)color, DarknutConstants.WIDTHANDHEIGHT, DarknutConstants.WIDTHANDHEIGHT);
            }
            else
            {
                if(direction == Direction.Down)
                {
                    return new Rectangle(1 + 17 * (frame % 2), 90 + 17 * (int)color, DarknutConstants.WIDTHANDHEIGHT, DarknutConstants.WIDTHANDHEIGHT);
                }
                else
                {
                    return new Rectangle(52 + 17 * (frame % 2), 90 + 17 * (int)color, DarknutConstants.WIDTHANDHEIGHT, DarknutConstants.WIDTHANDHEIGHT);
                }
            }
        }

        public void Move()
        {
            frame++;
            if (state == State.Normal)
            {
                if (frame % 10 == 0) direction = ChangeDirection();

                if (direction == Direction.Up) yLoc -= DarknutConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Down) yLoc += DarknutConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Left) xLoc -= DarknutConstants.moveDist * GameConstants.SCALE;
                else xLoc += DarknutConstants.moveDist * GameConstants.SCALE;
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
            int num = RandomNumberGenerator.GetInt32(DarknutConstants.CHANGEDIRECTION);

            return (Direction)num;
        }

        public bool HasHealth()
        {
            return health > 0;
        }

        public void TakeDamage(int damage, Vector2 damageVector)
        {
            if (state != State.Damaged)
            {
                damageDirection = damageVector;
                health -= damage;
                state = State.Damaged;
                stunFrames = 1;
                damageFrames = 1;
            }
        }

        public void SetStun()
        {
            state = State.Stun;
            stunFrames = 1;
        }

        public int GetDamage()
        {
            if (color == DarknutColor.Red)
            {
                return DarknutConstants.REDDAMAGE;
            }
            else
            {
                return DarknutConstants.BLUEDAMAGE;
            }

        }

        public void ReturnToNormal()
        {
            if (damageFrames > DarknutConstants.DAMAGEFRAMECOUNT || stunFrames > DarknutConstants.STUNFRAMECOUNT)
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
