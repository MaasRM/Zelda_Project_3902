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

        public GohmaStateMachine(int x, int y, GohmaColor c)
        {
            direction = GohmaConstants.Directions[0];
            eye = Eye.Closed;
            state = State.Alive;
            frame = -1;
            closeFrames = 1;
            transitionFrame = 0;
            eyeDirection = 1;
            lastFire = 0;
            xLoc = x;
            yLoc = y;
            color = c;
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
            return new Rectangle();
        }

        public void Move()
        {
            frame++;

            if (frame % GohmaConstants.CHANGEDIRECTIONFRAME == 0) direction = ChangeDirection();

            if (direction == Direction.Left) xLoc -= GohmaConstants.moveDist * GameConstants.SCALE;
            else if(direction == Direction.Right) xLoc += GohmaConstants.moveDist * GameConstants.SCALE;
            else if (direction == Direction.Up) yLoc -= GohmaConstants.moveDist * GameConstants.SCALE;
            else yLoc += GohmaConstants.moveDist * GameConstants.SCALE;
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
            state = State.Dead;
        }

        public bool EyeOpen()
        {
            return eye == Eye.Open;
        }
    }
}
