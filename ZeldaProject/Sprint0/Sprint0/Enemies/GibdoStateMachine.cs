using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class GibdoStateMachine
    {

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
        private int frame;
        private int stunFrames;
        private int damageFrames;
        private int health;
        private bool burn;

        public GibdoStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            stunFrames = 0;
            damageFrames = 0;
            health = GibdoConstants.MAXHEALTH;
            state = State.Normal;
            damageDirection = new Vector2(1, 1);
            burn = false;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, GibdoConstants.WIDTHANDHEIGHT * GameConstants.SCALE, GibdoConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            ChangeDirection();
        }

        public Rectangle GetSource()
        {
            if (!burn)
            {
                return new Rectangle(90, 90, GibdoConstants.WIDTHANDHEIGHT, GibdoConstants.WIDTHANDHEIGHT);
            }
            else
            {
                return new Rectangle(1, 59, StalfosConstants.WIDTHANDHEIGHT, StalfosConstants.WIDTHANDHEIGHT);
            }
        }

        public void Move()
        {
            if (state == State.Normal || damageDirection == new Vector2(0, 0))
            {
                frame++;

                if (frame % 8 == 0) direction = ChangeDirection();

                if (direction == Direction.Up) yLoc -= GibdoConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Down) yLoc += GibdoConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Left) xLoc -= GibdoConstants.moveDist * GameConstants.SCALE;
                else xLoc += GibdoConstants.moveDist * GameConstants.SCALE;
                damageFrames++;
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

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(4);

            return (Direction)num;
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
            if (damageFrames > GibdoConstants.DAMAGEFRAMECOUNT || stunFrames > GibdoConstants.STUNFRAMECOUNT)
            {
                state = State.Normal;
                stunFrames = 0;
                damageFrames = 0;
                damageDirection = new Vector2(1, 1);
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

        public void Burn()
        {
            burn = true;
        }

        public bool IsBurned()
        {
            return burn;
        }
    }
}
