using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    public class GelStateMachine
    {
        public enum GelColor
        {
            Teal,
            Emerald,
            Blue,
            Orange,
            Green,
            Grey,
            Oil,
            Black
        }

        private enum State
        {
            Normal,
            Stun
        }

        private Direction direction;
        private GelColor color;
        private State state;
        private int xLoc;
        private int yLoc;
        private int frame;
        private bool wait;
        private int waitFrames;
        public int stunFrames;
        private int health;


        public GelStateMachine(int x, int y, GelColor c)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            color = c;
            wait = false;
            health = GelConstants.MAXHEALTH;
            stunFrames = 0;
            state = State.Normal;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, GelConstants.WIDTH * GameConstants.SCALE, GelConstants.HEIGHT * GameConstants.SCALE);
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
                return new Rectangle(1 + 18 * ((int)color % 4), 11 + 17 * ((int)color % 2), GelConstants.WIDTH, GelConstants.HEIGHT);
            }
            else
            {
                return new Rectangle(10 + 18 * ((int)color % 4), 11 + 17 * ((int)color % 2), GelConstants.WIDTH, GelConstants.HEIGHT);
            }
        }

        public void Move()
        {
            if(state == State.Normal) {
                frame++;

                if (frame > waitFrames || frame > GelConstants.moveFrames) {
                    wait = !wait;
                    frame = 0;
                    waitFrames = (RandomNumberGenerator.GetInt32(6) + 2) * 5;
                }

                if (frame == 0) direction = ChangeDirection();

                if (!wait)
                {
                    if (direction == Direction.Up) yLoc -= GelConstants.moveDist * GameConstants.SCALE;
                    else if (direction == Direction.Down) yLoc += GelConstants.moveDist * GameConstants.SCALE;
                    else if (direction == Direction.Left) xLoc -= GelConstants.moveDist * GameConstants.SCALE;
                    else xLoc += GelConstants.moveDist * GameConstants.SCALE;
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
