using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Sprint0
{
    public class AquamentusStateMachine
    {
        public enum Direction
        {
            Left,
            Right
        }

        private enum State
        {
            Normal,
            Damaged,
        }

        private Direction direction;
        private State state;
        private int xLoc;
        private int yLoc;
        private int frame;
        private int lastFire;
        private int health;
        private int damageFrames;
        private const int WIDTH = 24;
        private const int HEIGHT = 32;
        private const int MAXHEALTH = 16;
        private const int FIRECOOLDOWN = 40;
        private const int PIXELSCALER = 4;
        private const int moveDist = 2;
        private bool firing;

        public AquamentusStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            damageFrames = 0;
            lastFire = FIRECOOLDOWN * -1;
            firing = false;
            health = MAXHEALTH;
            direction = Direction.Left;
            state = State.Normal;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, WIDTH * PIXELSCALER, HEIGHT * PIXELSCALER);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            if(firing)
            {
                if(frame % 2 == 0) return new Rectangle(1, 11, WIDTH, HEIGHT);
                else return new Rectangle(26, 11, WIDTH, HEIGHT);
            }
            else
            {
                if (frame % 2 == 0) return new Rectangle(51, 11, WIDTH, HEIGHT);
                else return new Rectangle(76, 11, WIDTH, HEIGHT);
            }
        }

        public void Move()
        {
            frame++;

            if (frame % 10 == 0) direction = ChangeDirection();
            if (direction == Direction.Left) xLoc -= moveDist * PIXELSCALER;
            else xLoc += moveDist * PIXELSCALER;

            if(firing) StopFiring();

            if(state == State.Damaged) damageFrames++;

            ReturnToNormal();
        }

        public int GetFrame()
        {
            return frame;
        }

        private static Direction ChangeDirection()
        {
            int num = RandomNumberGenerator.GetInt32(2);

            return (Direction)num;
        }

        public bool TryToFire()
        {
            if(frame - lastFire >= FIRECOOLDOWN)
            {
                int num = RandomNumberGenerator.GetInt32(30);

                if(num % 15 == 0)
                {
                    firing = true;
                    lastFire = frame;
                }
            }

            return firing;
        }

        private void StopFiring()
        {
            if(frame - lastFire == 8 && firing)
            {
                firing = false;
            }
        }

        public bool IsFiring()
        {
            return firing;
        }

        public bool HasHealth()
        {
            return health > 0;
        }

        public void TakeDamage(int damage)
        {
            if (state != State.Damaged)
            {
                health -= damage;
                state = State.Damaged;
                damageFrames = 1;
            }
        }

        public void ReturnToNormal()
        {
            if (damageFrames > 8)
            {
                state = State.Normal;
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