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
        private int xLoc;
        private int yLoc;
        private int linkHeight;
        private int linkWidth;

        public LinkStateMachine()
        {
            spriteFactory = new LinkSpriteFactory();
            direction = Direction.MoveRight;
            color = LinkColor.Green;
            animation = Animation.Idle;
            useItem = false;
            isDamaged = false;
            xLoc = 100; //Original Position, probably needs to change
            yLoc = 100;
            //set link height/width
        }

        public Rectangle getDestination()
        {
            return new Rectangle(this.xLoc, this.yLoc, this.linkWidth, this.linkHeight);
        }

        public Rectangle getSource()
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

        public void changeXLocation(int change)
        {
            xLoc += change;
        }

        public void changeYLocation(int change)
        {
            yLoc += change;
        }

        //implement commands for attack, moving, idle, damaged, useItem
    }
}
