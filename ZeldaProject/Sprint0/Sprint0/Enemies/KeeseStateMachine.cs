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
        private const int SCALER = 2;
        private static int slowFrameCount = 30;
        private static double axialMoveDist = 2;
        private static double diagonalMoveDist = axialMoveDist * Math.Sqrt(2.0);
        private static Movement[] movements = new Movement[] {Movement.Slow, Movement.Fast, Movement.Slow, Movement.Wait };

        public KeeseStateMachine(int x, int y, int xLen, int yLen, KeeseColor c)
        {
            xLoc = x;
            yLoc = y;
            width = xLen;
            height = yLen;
            color = c;
            mov = Movement.Slow;
            movementIndex = -1;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle((int) xLoc, (int) yLoc, width * SCALER, height * SCALER);
        }

        public Rectangle GetSource()
        {
            if(currFrame % 2 == 0 || mov == Movement.Wait)
            {
                if(color == KeeseColor.Blue)
                {
                    return new Rectangle(183, 11, width, height);
                }
                else
                {
                    return new Rectangle(183, 28, width, height);
                }
            }
            else
            {
                if (color == KeeseColor.Blue)
                {
                    return new Rectangle(200, 11, width, height);
                }
                else
                {
                    return new Rectangle(200, 28, width, height);
                }
            }
        }

        public void move()
        {
            currFrame++;
            if (currFrame == slowFrameCount || currFrame == fastFrameCount || currFrame == waitFrameCount)
            {
                resetFrames();
                changeMovement();
            }

            if((mov == Movement.Slow && currFrame % 4 == 0) || mov == Movement.Fast)
            {
                changePosition();
            }
        }

        private void changePosition()
        {
            if (currFrame % 5 == 0)
            {
                direction = changeDirection();
            }

            if (direction == Direction.North)
            {
                yLoc -= axialMoveDist * SCALER;
            }
            else if (direction == Direction.NorthEast)
            {
                xLoc += diagonalMoveDist * SCALER;
                yLoc -= diagonalMoveDist * SCALER;
            }
            else if (direction == Direction.East)
            {
                xLoc += axialMoveDist * SCALER;
            }
            else if (direction == Direction.SouthEast)
            {
                xLoc += diagonalMoveDist * SCALER;
                yLoc += diagonalMoveDist * SCALER;
            }
            else if (direction == Direction.South)
            {
                yLoc += axialMoveDist * SCALER;
            }
            else if (direction == Direction.SouthWest)
            {
                xLoc -= diagonalMoveDist * SCALER;
                yLoc += diagonalMoveDist * SCALER;
            }
            else if (direction == Direction.West)
            {
                xLoc -= axialMoveDist * SCALER;
            }
            else
            {
                xLoc -= diagonalMoveDist * SCALER;
                yLoc -= diagonalMoveDist * SCALER;
            }
        }

        private static Direction changeDirection()
        {
            Random rnd = new Random();
            int num = RandomNumberGenerator.GetInt32(2);
            if (num == 0)
            {
                num = RandomNumberGenerator.GetInt32(8);
            }

            return (Direction)num;
        }

        private void resetFrames()
        {
            currFrame = -1;
            fastFrameCount = (RandomNumberGenerator.GetInt32(8) + 5) * 5;
            waitFrameCount = (RandomNumberGenerator.GetInt32(3) + 3) * 5;
        }

        private void changeMovement()
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
