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
        private int frame;
        private int stunFrames;
        private int damageFrames;
        private int health;
        private const int WIDTHANDHEIGHT = 16;
        private const int MAXHEALTH = 2;
        private const int PIXELSCALER = 4;
        private const int moveDist = 2;

        public StalfosStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            stunFrames = 0;
            damageFrames = 0;
            health = MAXHEALTH;
            state = State.Normal;
            damageDirection = new Vector2(1, 1);
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, WIDTHANDHEIGHT * PIXELSCALER, WIDTHANDHEIGHT * PIXELSCALER);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            return new Rectangle(1, 59, WIDTHANDHEIGHT, WIDTHANDHEIGHT);
        }

        public void Move()
        {
            if(state == State.Normal || damageDirection == new Vector2(0,0)) {
                frame++;

                if (frame % 8 == 0) direction = ChangeDirection();

                if (direction == Direction.Up) yLoc -= moveDist * PIXELSCALER;
                else if (direction == Direction.Down) yLoc += moveDist * PIXELSCALER;
                else if (direction == Direction.Left) xLoc -= moveDist * PIXELSCALER;
                else xLoc += moveDist * PIXELSCALER;
                damageFrames++;
            }
            else if(state == State.Damaged) {
                xLoc += (int)damageDirection.X * PIXELSCALER;
                yLoc += (int)damageDirection.Y * PIXELSCALER;
                damageFrames++;
            }
            else if(state == State.Stun) {
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
            if (damageFrames > 8 || stunFrames > 30)
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
    }
}
