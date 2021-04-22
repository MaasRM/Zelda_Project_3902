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
            Damaged,
            Stun
        }

        private Direction direction;
        private ZolColor color;
        private State state;
        private Vector2 damageDirection;
        private int xLoc;
        private int yLoc;
        private int frame;
        private bool wait;
        private int waitFrames;
        private int stunFrames;
        private int damageFrames;
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
            damageFrames = 0;
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
            ChangeDirection();
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

                if (!wait) {
                    if (direction == Direction.Up) yLoc -= ZolConstants.moveDist * GameConstants.SCALE;
                    else if (direction == Direction.Down) yLoc += ZolConstants.moveDist * GameConstants.SCALE;
                    else if (direction == Direction.Left) xLoc -= ZolConstants.moveDist * GameConstants.SCALE;
                    else xLoc += ZolConstants.moveDist * GameConstants.SCALE;
                }
            }
            else if(state == State.Stun) {
                stunFrames++;
            }
            else if (state == State.Damaged) {
                damageFrames++;
                xLoc += (int)damageDirection.X * GameConstants.SCALE;
                yLoc += (int)damageDirection.Y * GameConstants.SCALE;
            }
            ReturnToNormal();
        }

        public int GetFrame()
        {
            return frame;
        }

        public int GetDamageFrame()
        {
            return damageFrames;
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
            if (stunFrames > 30 || damageFrames > 8)
            {
                state = State.Normal;
            }
        }

        public bool IsDamaged()
        {
            return state == State.Damaged;
        }
    }
}
