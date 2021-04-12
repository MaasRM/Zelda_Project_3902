using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class ZolStateMachine
    {
        public enum ZolColor
        {
            Green,
            Oil,
            DarkGreen,
            Brown,
            Gray,
            Black
        }

        private enum State
        {
            Normal,
            Stun
        }

        private Direction direction;
        private ZolColor color;
        private State state;
        private int xLoc;
        private int yLoc;
        private int frame;
        private bool wait;
        private int waitFrames;
        public int stunFrames;
        private int health;


        public ZolStateMachine(int x, int y, ZolColor c)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            color = c;
            wait = false;
            health = ZolConstants.MAXHEALTH;
            stunFrames = 0;
            state = State.Normal;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, ZolConstants.WIDTH * GameConstants.SCALE, ZolConstants.HEIGHT * GameConstants.SCALE);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            if (frame % 2 == 0)
            {
                return new Rectangle(77 + 34 * ((int)color % 3), 11 + 17 * ((int)color % 2), ZolConstants.WIDTH, ZolConstants.HEIGHT);
            }
            else
            {
                return new Rectangle(94 + 34 * ((int)color % 3), 11 + 17 * ((int)color % 2), ZolConstants.WIDTH, ZolConstants.HEIGHT);
            }
        }

        public void Move()
        {
            if(state == State.Normal) {
                frame++;

                if (frame > waitFrames || frame > ZolConstants.moveFrames) {
                    wait = !wait;
                    frame = 0;
                    waitFrames = (RandomNumberGenerator.GetInt32(6) + 2) * 5;
                }

                if (frame == 0) direction = ChangeDirection();

                if (!wait)
                {
                    if (direction == Direction.Up) yLoc -= ZolConstants.moveDist * GameConstants.SCALE;
                    else if (direction == Direction.Down) yLoc += ZolConstants.moveDist * GameConstants.SCALE;
                    else if (direction == Direction.Left) xLoc -= ZolConstants.moveDist * GameConstants.SCALE;
                    else xLoc += ZolConstants.moveDist * GameConstants.SCALE;
                }
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

            return (Direction)num;
        }

        public bool HasHealth()
        {
            return health > 0;
        }

        public void TakeDamage(int damage)
        {
            
            health -= damage;
        }

        public void SetStun()
        {
            state = State.Stun;
            stunFrames = 1;
        }

        public void ReturnToNormal()
        {
            if (stunFrames > 30)
            {
                state = State.Normal;
            }
        }
    }
}
