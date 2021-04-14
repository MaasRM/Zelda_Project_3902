using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace Sprint0
{
    public class GohmaStateMachine
    {
        public enum GohmaColor
        {
            Red,
            Blue
        }

        private enum Eye
        {
            Closed,
            Slightly,
            Mostly,
            Open
        }

        private enum State
        {
            Alive,
            Dead
        }

        private Direction direction;
        private GohmaColor color;
        private Eye eye;
        private State state;
        private int xLoc;
        private int yLoc;
        private int frame;
        private int closeFrames;
        private int transitionFrame;
        private int eyeDirection;
        private int lastFire;
        private int moveIndex;

        public GohmaStateMachine(int x, int y, GohmaColor c)
        {
            direction = GohmaConstants.Directions[GohmaConstants.Directions.Length - 1];
            eye = Eye.Closed;
            state = State.Alive;
            frame = -1;
            closeFrames = SetCloseFrames();
            transitionFrame = -1;
            eyeDirection = 1;
            lastFire = 0;
            xLoc = x;
            yLoc = y;
            color = c;
            moveIndex = 0;
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(xLoc, yLoc, GohmaConstants.WIDTH * GameConstants.SCALE, GohmaConstants.HEIGHT * GameConstants.SCALE);
        }

        public void SetDestination(int x, int y)
        {
            xLoc = x;
            yLoc = y;
        }

        public Rectangle GetSource()
        {
            return new Rectangle(298 + 49 * (int)eye, 105 + 17 * (int)color, GohmaConstants.WIDTH, GohmaConstants.HEIGHT);
        }

        public void Move()
        {
            frame++;
            transitionFrame++;

            if (frame % GohmaConstants.CHANGEDIRECTIONFRAME == 0) direction = ChangeDirection();

            if (direction == Direction.Left) xLoc -= GohmaConstants.moveDist * GameConstants.SCALE;
            else if(direction == Direction.Right) xLoc += GohmaConstants.moveDist * GameConstants.SCALE;
            else if (direction == Direction.Up) yLoc -= GohmaConstants.moveDist * GameConstants.SCALE;
            else yLoc += GohmaConstants.moveDist * GameConstants.SCALE;

            EyeTransition();
        }

        public int GetFrame()
        {
            return frame;
        }

        private Direction ChangeDirection()
        {
            moveIndex++;

            moveIndex = moveIndex % GohmaConstants.Directions.Length;

            return GohmaConstants.Directions[moveIndex];
        }

        public bool TryToFire()
        {
            if (frame - lastFire >= GohmaConstants.FIRECOOLDOWN)
            {
                int num = RandomNumberGenerator.GetInt32(GohmaConstants.FIRECHANCE);

                if (num % (GohmaConstants.FIRECHANCE - 1) == 0) lastFire = frame;

                return true;
            }

            return false;
        }

        public bool HasHealth()
        {
            return state == State.Alive;
        }

        public void TakeDamage()
        {
            if(eye == Eye.Open)
            {
                state = State.Dead;
            }
        }

        private int SetCloseFrames()
        {
            return RandomNumberGenerator.GetInt32(GohmaConstants.CLOSEFRAMEMAX) * 2;
        }

        private void EyeTransition()
        {
            if (eye == Eye.Closed) eyeDirection = 1;
            else if (eye == Eye.Open)
            {
                eyeDirection = -1;
                closeFrames = SetCloseFrames();
            }

            if ((eye == Eye.Closed && transitionFrame >= closeFrames) ||
                ((eye == Eye.Slightly || eye == Eye.Mostly) && transitionFrame >= GohmaConstants.EYETRANSITIONFRAMES) ||
                (eye == Eye.Open && transitionFrame >= GohmaConstants.EYEOPENFRAMES))
            {
                transitionFrame = 0;
                eye = (Eye)(((int)eye) + eyeDirection);
            }
        }
    }
}
