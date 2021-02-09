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

    public enum LinkColor
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
        private LinkSpriteFactory spriteFactory;
        private Direction direction;
        private LinkColor color;
        private Animation animation;
        private Boolean useItem;
        private Boolean isDamaged;

        public LinkStateMachine()
        {
            spriteFactory = new LinkSpriteFactory();
            direction = Direction.MoveRight;
            color = LinkColor.Green;
            animation = Animation.Idle;
            useItem = false;
            isDamaged = false;
        }

        public Rectangle getSprite()
        {
            return spriteFactory.getRectangle(direction, color, animation, useItem, isDamaged);
        }

        public void faceUp()
        {
            this.direction = Direction.MoveUp;
        }

        public void faceDown()
        {
            this.direction = Direction.MoveDown;
        }

        public void faceLeft()
        {
            this.direction = Direction.MoveLeft;
        }

        public void faceRight()
        {
            this.direction = Direction.MoveRight;
        }

        //implement commands for attack, moving, idle, damaged, useItem
    }
}
