using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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

        public enum Movement
        {
            Fast,
            Slow,
            Wait
        }

        private Direction direction;
        private Color color;
        private Movement mov;
        private double xLoc;
        private double yLoc;
        private int width;
        private int height;
        private int movementIndex;
        private int currFrame;
        private int waitFrameCount;
        private int fastFrameCount;
        private static int slowFrameCount = 20;
        private static double axialMoveDist = 5;
        private static double diagonalMoveDist = axialMoveDist * Math.Sqrt(2.0);
        private static Movement[] movements = new Movement[] {Movement.Slow, Movement.Fast, Movement.Slow, Movement.Wait };

        public KeeseStateMachine(int x, int y, int xLen, int yLen, Color c)
        {
            xLoc = x;
            yLoc = y;
            width = xLen;
            height = yLen;
            color = c;
            mov = Movement.Slow;
            movementIndex = 0;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle((int) xLoc, (int) yLoc, width, height);
        }

        public Rectangle GetSource()
        {
            if (color == Color.Blue)
            {
                if (currFrame % 2 == 1)
                {
                    return new Rectangle(200, 11, width, height);
                }
                else
                {
                    return new Rectangle(183, 11, width, height);
                }
            }
            else
            {
                if (currFrame % 2 == 1)
                {
                    return new Rectangle(200, 28, width, height);
                }
                else
                {
                    return new Rectangle(183, 28, width, height);
                }
            }
        }

        public void move()
        {
            if (currFrame == slowFrameCount || currFrame == fastFrameCount || currFrame == waitFrameCount)
            {
                resetFrames();
                changeMovement();
            }

            if((mov == Movement.Slow && currFrame % 2 == 0) || mov == Movement.Fast)
            {
                changePosition();
            }
        }

        private void changePosition()
        {
            currFrame++;

            if (currFrame % 5 == 0)
            {
                direction = changeDirection();
            }

            if (direction == Direction.North)
            {
                yLoc -= axialMoveDist;
            }
            else if (direction == Direction.NorthEast)
            {
                xLoc += diagonalMoveDist;
                yLoc -= diagonalMoveDist;
            }
            else if (direction == Direction.East)
            {
                xLoc += axialMoveDist;
            }
            else if (direction == Direction.SouthEast)
            {
                xLoc += diagonalMoveDist;
                yLoc += diagonalMoveDist;
            }
            else if (direction == Direction.South)
            {
                yLoc += axialMoveDist;
            }
            else if (direction == Direction.SouthWest)
            {
                xLoc -= diagonalMoveDist;
                yLoc += diagonalMoveDist;
            }
            else if (direction == Direction.West)
            {
                xLoc -= axialMoveDist;
            }
            else
            {
                xLoc -= diagonalMoveDist;
                yLoc -= diagonalMoveDist;
            }
        }

        private static Direction changeDirection()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 3);
            if(num == 0)
            {
                num = rnd.Next(0, 7);
            }

            return (Direction)num;
        }

        private void resetFrames()
        {
            Random rnd = new Random();
            currFrame = -1;
            fastFrameCount = rnd.Next(3, 8) * 5;
            waitFrameCount = rnd.Next(1, 5) * 5;
        }

        private void changeMovement()
        {
            movementIndex++;

            if(movementIndex > movements.Length)
            {
                movementIndex = 0;
            }

            mov = movements[movementIndex];
        }
    }
}
