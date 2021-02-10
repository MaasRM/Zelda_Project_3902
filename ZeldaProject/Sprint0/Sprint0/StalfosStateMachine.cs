using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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

        private Direction direction;
        private int xLoc;
        private int yLoc;

        public StalfosStateMachine()
        {
        }

        public Rectangle GetDestination()
        {
            return new Rectangle(1, 1, 1, 1);
        }

        public Rectangle GetSource()
        {
            return new Rectangle(1, 1, 1, 1);
        }

        public void move()
        {

        }
    }
}
