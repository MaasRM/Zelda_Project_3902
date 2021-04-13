using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Sprint0
{
    public class DodongoStateMachine
    {
        private enum State
        {
            Normal,
            Eating,
            Dying,
            Dead
        }

        private Direction direction;
        private State state;
        private int xLoc;
        private int yLoc;
        private int frame;
        private int health;
        private int eatFrames;

        public DodongoStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            eatFrames = 0;
            health = DodongoConstants.MAXHEALTH;
            direction = Direction.Left;
            state = State.Normal;
        }

        public Rectangle GetDestination()
        {
            if(direction == Direction.Left || direction == Direction.Right)
            {
                return new Rectangle(xLoc, yLoc, DodongoConstants.HORIMOVEWIDTH * GameConstants.SCALE, DodongoConstants.HEIGHT * GameConstants.SCALE);
            }
            else
            {
                return new Rectangle(xLoc, yLoc, DodongoConstants.VERTMOVEWIDTH * GameConstants.SCALE, DodongoConstants.HEIGHT * GameConstants.SCALE);
            }
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public void Move()
        {
            if (state == State.Normal)
            {
                frame++;

                if (frame % 8 == 0) direction = ChangeDirection();

                if (direction == Direction.Up) yLoc -= DodongoConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Down) yLoc += DodongoConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Left) xLoc -= DodongoConstants.moveDist * GameConstants.SCALE;
                else xLoc += DodongoConstants.moveDist * GameConstants.SCALE;
            }
            else if (state == State.Eating)
            {
                eatFrames++;
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
            return state == State.Dead;
        }

        public void TakeDamage(int damage)
        {
            if (state == State.Normal)
            {
                health -= damage;
                state = State.Eating;
                eatFrames = 1;
            }
        }

        public void ReturnToNormal()
        {
            if (eatFrames > DodongoConstants.EATFRAMECOUNT)
            {
                state = State.Normal;
            }
        }

        public bool IsDamaged()
        {
            return state == State.Eating;
        }

        public int GetEatFrame()
        {
            return eatFrames;
        }
    }
}