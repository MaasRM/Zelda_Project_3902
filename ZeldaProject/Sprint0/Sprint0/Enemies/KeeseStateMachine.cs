using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Sprint0
{
    public class KeeseStateMachine
    {
        public enum Direction
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        }

        public enum KeeseColor
        {
            Blue, Red
        }

        public enum Movement
        {
            Fast,
            Slow,
            Wait
        }

        private Direction direction;
        private KeeseColor color;
        private Movement mov;
        private double xLoc;
        private double yLoc;
        private int width;
        private int height;
        private int movementIndex;
        private int currFrame;
        private int waitFrameCount;
        private int fastFrameCount;
        private const int PIXELSCALER = 4;
        private static int slowFrameCount = 30;
        private static double axialMoveDist = 3;
        private static double diagonalMoveDist = axialMoveDist * Math.Sqrt(2.0);
        private static Movement[] movements = new Movement[] {Movement.Slow, Movement.Fast, Movement.Slow, Movement.Wait };

        public KeeseStateMachine(int x, int y, KeeseColor c)
        {
            xLoc = x;
            yLoc = y;
            width = 16;
            height = 16;
            color = c;
            mov = Movement.Slow;
            movementIndex = -1;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle((int) xLoc, (int) yLoc, width * PIXELSCALER, height * PIXELSCALER);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            if(currFrame % 2 == 0 || mov == Movement.Wait)
            {
                return new Rectangle(183, 11 + 17 * (int)color, width, height);
            }
            else
            {
                return new Rectangle(200, 11 + 17 * (int)color, width, height);
            }
        }

        public void Move()
        {
            currFrame++;
            if (currFrame == slowFrameCount || currFrame == fastFrameCount || currFrame == waitFrameCount)
            {
                ResetFrames();
                ChangeMovement();
            }

            if((mov == Movement.Slow && currFrame % 4 == 0) || mov == Movement.Fast)
            {
                ChangePosition();
            }
        }

        private void ChangePosition()
        {
            if (currFrame % 10 == 0)
            {
                direction = ChangeDirection();
            }

            if (direction == Direction.North)
            {
                yLoc -= axialMoveDist * PIXELSCALER;
            }
            else if (direction == Direction.NorthEast)
            {
                xLoc += diagonalMoveDist * PIXELSCALER;
                yLoc -= diagonalMoveDist * PIXELSCALER;
            }
            else if (direction == Direction.East)
            {
                xLoc += axialMoveDist * PIXELSCALER;
            }
            else if (direction == Direction.SouthEast)
            {
                xLoc += diagonalMoveDist * PIXELSCALER;
                yLoc += diagonalMoveDist * PIXELSCALER;
            }
            else if (direction == Direction.South)
            {
                yLoc += axialMoveDist * PIXELSCALER;
            }
            else if (direction == Direction.SouthWest)
            {
                xLoc -= diagonalMoveDist * PIXELSCALER;
                yLoc += diagonalMoveDist * PIXELSCALER;
            }
            else if (direction == Direction.West)
            {
                xLoc -= axialMoveDist * PIXELSCALER;
            }
            else
            {
                xLoc -= diagonalMoveDist * PIXELSCALER;
                yLoc -= diagonalMoveDist * PIXELSCALER;
            }
        }

        private static Direction ChangeDirection()
        {
            Random rnd = new Random();
            int num = RandomNumberGenerator.GetInt32(3);
            if (num != 0)
            {
                num = RandomNumberGenerator.GetInt32(8);
            }

            return (Direction)num;
        }

        private void ResetFrames()
        {
            currFrame = -1;
            fastFrameCount = (RandomNumberGenerator.GetInt32(8) + 5) * 5;
            waitFrameCount = (RandomNumberGenerator.GetInt32(3) + 3) * 5;
        }

        private void ChangeMovement()
        {
            movementIndex++;

            if(movementIndex >= movements.Length)
            {
                movementIndex = 0;
            }

            mov = movements[movementIndex];
        }
    }
}
