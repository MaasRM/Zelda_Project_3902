using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Sprint0
{
    public class KeeseStateMachine
    {
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

        private enum State
        {
            Normal,
            Stun
        }

        private Direction direction;
        private KeeseColor color;
        private Movement mov;
        private State state;
        private double xLoc;
        private double yLoc;
        private int movementIndex;
        private int currFrame;
        private int waitFrameCount;
        private int fastFrameCount;
        private int health;
        private int stunFrames;
        

        public KeeseStateMachine(int x, int y, KeeseColor c)
        {
            xLoc = x;
            yLoc = y;
            color = c;
            mov = Movement.Slow;
            movementIndex = -1;
            health = KeeseConstants.MAXHEALTH;
            stunFrames = 0;
            direction = ChangeDirection()
        }

        public Rectangle GetDestination()
        {
            return new Rectangle((int) xLoc, (int) yLoc, KeeseConstants.WIDTHANDHEIGHT * GameConstants.SCALE, KeeseConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
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
                return new Rectangle(183, 11 + 17 * (int)color, KeeseConstants.WIDTHANDHEIGHT, KeeseConstants.WIDTHANDHEIGHT);
            }
            else
            {
                return new Rectangle(200, 11 + 17 * (int)color, KeeseConstants.WIDTHANDHEIGHT, KeeseConstants.WIDTHANDHEIGHT);
            }
        }

        public void Move()
        {
            if(state == State.Normal)
            {
                currFrame++;
                if (currFrame == KeeseConstants.SLOWFRAMECOUNT || currFrame == fastFrameCount || currFrame == waitFrameCount)
                {
                    ResetFrames();
                    ChangeMovement();
                }

                if ((mov == Movement.Slow && currFrame % 4 == 0) || mov == Movement.Fast)
                {
                    ChangePosition();
                }
            }
            else if(state == State.Stun)
            {
                stunFrames++;
            }
        }

        private void ChangePosition()
        {
            if(state == State.Normal) {
                if (currFrame % KeeseConstants.DIRECTIONCHANGEFRAME == 0) direction = ChangeDirection();

                if (direction == Direction.Up) yLoc -= KeeseConstants.axialMoveDist * GameConstants.SCALE;
                else if (direction == Direction.UpRight) {
                    xLoc += KeeseConstants.diagonalMoveDist * GameConstants.SCALE;
                    yLoc -= KeeseConstants.diagonalMoveDist * GameConstants.SCALE;
                }
                else if (direction == Direction.Right) xLoc += KeeseConstants.axialMoveDist * GameConstants.SCALE;
                else if (direction == Direction.DownRight) {
                    xLoc += KeeseConstants.diagonalMoveDist * GameConstants.SCALE;
                    yLoc += KeeseConstants.diagonalMoveDist * GameConstants.SCALE;
                }
                else if (direction == Direction.Down) yLoc += KeeseConstants.axialMoveDist * GameConstants.SCALE;
                else if (direction == Direction.DownLeft) {
                    xLoc -= KeeseConstants.diagonalMoveDist * GameConstants.SCALE;
                    yLoc += KeeseConstants.diagonalMoveDist * GameConstants.SCALE;
                }
                else if (direction == Direction.Left) xLoc -= KeeseConstants.axialMoveDist * GameConstants.SCALE;
                else {
                    xLoc -= KeeseConstants.diagonalMoveDist * GameConstants.SCALE;
                    yLoc -= KeeseConstants.diagonalMoveDist * GameConstants.SCALE;
                }
            }
            else if(state == State.Stun) {
                stunFrames++;
            }
        }

        private static Direction ChangeDirection()
        {
            int num;
         
            num = RandomNumberGenerator.GetInt32(8);

            return (Direction)num;
        }

        private void ResetFrames()
        {
            currFrame = -1;
            fastFrameCount = RandomNumberGenerator.GetInt32(KeeseConstants.MOVEFRAMEDIVISOR) * KeeseConstants.FRAMESCALE;
            waitFrameCount = RandomNumberGenerator.GetInt32(KeeseConstants.WAITFRAMEDIVISOR) * KeeseConstants.FRAMESCALE;
        }

        private void ChangeMovement()
        {
            movementIndex++;

            if(movementIndex >= KeeseConstants.movements.Length)
            {
                movementIndex = 0;
            }

            mov = KeeseConstants.movements[movementIndex];
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
