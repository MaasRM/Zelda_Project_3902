using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Sprint0
{
    public class DodongoStateMachine
    {
        public enum State
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
        private int bombDamage;
        private int dyingFrames;

        public DodongoStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            eatFrames = 0;
            dyingFrames = 0;
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
            if(direction == Direction.Up)
            {
                if (state == State.Eating && eatFrames >= DodongoConstants.PAUSETOEAT) return new Rectangle(52, 58, DodongoConstants.VERTMOVEWIDTH, DodongoConstants.HEIGHT);
                else return new Rectangle(35, 58, DodongoConstants.VERTMOVEWIDTH, DodongoConstants.HEIGHT);
            }
            else if (direction == Direction.Down && (state != State.Eating || eatFrames >= DodongoConstants.PAUSETOEAT))
            {
                if (state == State.Eating) return new Rectangle(18, 58, DodongoConstants.VERTMOVEWIDTH, DodongoConstants.HEIGHT);
                else return new Rectangle(1, 58, DodongoConstants.VERTMOVEWIDTH, DodongoConstants.HEIGHT);
            }
            else
            {
                if (state == State.Eating && eatFrames >= DodongoConstants.PAUSETOEAT) return new Rectangle(135, 58, DodongoConstants.HORIMOVEWIDTH, DodongoConstants.HEIGHT);
                else return new Rectangle(69 + 33 * (frame % 2), 58, DodongoConstants.HORIMOVEWIDTH, DodongoConstants.HEIGHT);
            }
        }

        public void Move()
        {
            frame++;
            if (state == State.Normal)
            {
                if (frame % DodongoConstants.CHANGEDIRECTIONFRAME == 0) direction = ChangeDirection();

                if (direction == Direction.Up) yLoc -= DodongoConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Down) yLoc += DodongoConstants.moveDist * GameConstants.SCALE;
                else if (direction == Direction.Left) xLoc -= DodongoConstants.moveDist * GameConstants.SCALE;
                else xLoc += DodongoConstants.moveDist * GameConstants.SCALE;
            }
            else if (state == State.Eating)
            {
                eatFrames++;
                if(eatFrames > DodongoConstants.EATFRAMECOUNT)
                {
                    health -= bombDamage;
                    eatFrames = 0;
                    if (health <= 0) state = State.Dying;
                    else state = State.Normal;
                }
            }
            else if(state == State.Dying)
            {
                dyingFrames++;
                if (dyingFrames > DodongoConstants.DEATHFRAMES) state = State.Dead;
            }
        }

        public int GetFrame()
        {
            return frame;
        }

        public Direction GetDirection()
        {
            return direction;
        }

        public State GetState()
        {
            return state;
        }

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(4);

            return (Direction)num;
        }

        public bool NotDead()
        {
            return state != State.Dead;
        }

        public void Eat(int damage)
        {
            if(state == State.Normal)
            {
                bombDamage = damage;
                state = State.Eating;
                eatFrames = 0;
            }
        }

        public bool IsEating()
        {
            return state == State.Eating;
        }

        public int GetEatFrame()
        {
            return eatFrames;
        }
    }
}