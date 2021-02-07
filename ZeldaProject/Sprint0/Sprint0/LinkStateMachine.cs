using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public enum Direction
    {
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight
    }

    public enum Color
    {
        Green,
        Red,
        White
    }

    public enum Animation
    {
        Idle,
        Walk,
        Attack
    }

    public class LinkStateMachine
    {
        private Direction direction;
        private Color color;
        private Animation animation;
        private Boolean useItem;
        private Boolean isDamaged;

        // Enums for direction, color, etc
        public LinkStateMachine()
        {
            direction = Direction.MoveRight;
            color = Color.Green;
            animation = Animation.Idle;
            useItem = false;
            isDamaged = false;
        }
        
        public Rectangle getSprite(){
            //LinkSpriteFactory, sends current state, returns the rectangle found
            //LinkSpriteFactory.getRectangle(this.Direction, this.Color, );
        }

        //implement commands
    }
}
