﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class CandleFireProjectile: IProjectile
    {
        private LinkStateMachine stateMachine;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xLoc;
        private int yLoc;
        private int candleSpeed;
        private int frame;
        private Boolean flip;
        private Direction projectileDirection;

        public CandleFireProjectile(LinkStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            projectileDirection = stateMachine.getDirection();
            if(projectileDirection == Direction.MoveUp)
            {
                xLoc = stateMachine.getXLoc();
                yLoc = stateMachine.getYLoc() - 15;
            } 
            else if(projectileDirection == Direction.MoveDown)
            {
                xLoc = stateMachine.getXLoc();
                yLoc = stateMachine.getYLoc() + 15;
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                xLoc = stateMachine.getXLoc() - 15;
                yLoc = stateMachine.getYLoc();
            }
            else //MoveRight
            {
                xLoc = stateMachine.getXLoc() + 15;
                yLoc = stateMachine.getYLoc();
            }
            flip = false;
            sourceRectangle = new Rectangle(191, 185, 15, 15);
            destinationRectangle = new Rectangle(xLoc, yLoc, 15, 15);
            candleSpeed = 3;
            frame = 0;
        }
        public void Update()
        {
            if (frame >= 40) stateMachine.RemoveProjectile(this);
            if (frame < 10)
            {
                if (projectileDirection == Direction.MoveUp)
                {
                    yLoc -= candleSpeed;
                }
                else if (projectileDirection == Direction.MoveDown)
                {
                    yLoc += candleSpeed;
                }
                else if (projectileDirection == Direction.MoveLeft)
                {
                    xLoc -= candleSpeed;
                }
                else //MoveRight
                {
                    xLoc += candleSpeed;
                }
            }
            destinationRectangle = new Rectangle(xLoc, yLoc, 15, 15);
            flip = !flip;
            frame++;
        }

        public void Draw(Texture2D spritesheet, SpriteBatch spriteBatch)
        {
            if(!flip)
            {
                spriteBatch.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
            } else
            {
                spriteBatch.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
        }
    }
}
