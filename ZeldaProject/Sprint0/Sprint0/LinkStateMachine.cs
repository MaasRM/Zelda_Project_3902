﻿using Microsoft.Xna.Framework;
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
            if(this.direction == Direction.MoveUp)
            {
                this.animation = Animation.Walk;
                yLoc -= 5; //May need to change value
            } else
            {
                this.direction = Direction.MoveUp;
                this.animation = Animation.Idle;
            }
        }

        public void faceDown()
        {
            if (this.direction == Direction.MoveDown)
            {
                this.animation = Animation.Walk;
                yLoc += 5; //May need to change value
            }
            else
            {
                this.direction = Direction.MoveDown;
                this.animation = Animation.Idle;
            }
        }

        public void faceLeft()
        {
            if (this.direction == Direction.MoveLeft)
            {
                this.animation = Animation.Walk;
                xLoc -= 5; //May need to change value
            }
            else
            {
                this.direction = Direction.MoveLeft;
                this.animation = Animation.Idle;
            }
        }

        public void faceRight()
        {
            if (this.direction == Direction.MoveRight)
            {
                this.animation = Animation.Walk;
                xLoc += 5; //May need to change value
            }
            else
            {
                this.direction = Direction.MoveRight;
                this.animation = Animation.Idle;
            }
        }

        public void changeXLocation(int change)
        {
            xLoc += change;
        }

        public void changeYLocation(int change)
        {
            yLoc += change;
        }

        //implement commands for attack, damaged, useItem
    }
}
