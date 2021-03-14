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

        private Direction direction;
        private int xLoc;
        private int yLoc;
        private int width;
        private int height;
        private int frame;
        private int lastFire;
        private const int FIRECOOLDOWN = 40;
        private const int PIXELSCALER = 4;
        private const int moveDist = 2;
        private bool firing;

        public AquamentusStateMachine(int x, int y)
        {
            xLoc = x;
            yLoc = y;
            width = 24;
            height = 32;
            frame = -1;
            lastFire = FIRECOOLDOWN * -1;
            firing = false;
            direction = Direction.Left;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, width * PIXELSCALER, height * PIXELSCALER);
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
                if(frame % 2 == 0)
                {
                    return new Rectangle(1, 11, width, height);
                }
                else
                {
                    return new Rectangle(26, 11, width, height);
                }
            }
            else
            {
                if (frame % 2 == 0)
                {
                    return new Rectangle(51, 11, width, height);
                }
                else
                {
                    return new Rectangle(76, 11, width, height);
                }
            }
        }

        public void Move()
        {
            frame++;

            if (frame % 10 == 0)
            {
                direction = ChangeDirection();
            }

            if (direction == Direction.Left)
            {
                xLoc -= moveDist * PIXELSCALER;
            }
            else
            {
                xLoc += moveDist * PIXELSCALER;
            }

            if(firing)
            {
                StopFiring();
            }
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
    }
}