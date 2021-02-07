using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkStateMachine
    {
        private enum Direction;
        private enum Color;
        private enum Animation;
        private Boolean useItem
        private Boolean isDamaged;

        // Enums for direction, color, etc
        public LinkStateMachine()
        {
            enum Direction
            {
                MoveUp,
                MoveDown,
                MoveLeft,
                MoveRight
            }

            enum Color
            {
                Green,
                Red,
                White
            }

            enum Animation
            {
                Idle,
                Walk,
                Attack
            }

            useItem = false;

            isDamaged = false;
        }
        
        
        // get/set methods for the fields
    }
}
