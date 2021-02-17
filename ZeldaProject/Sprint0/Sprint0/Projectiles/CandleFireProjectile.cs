using Microsoft.Xna.Framework;
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
        private Texture2D spritesheet;
        private int xLoc;
        private int yLoc;
        private const int candleSpeed = 12; //x4 specs
        private const int candleSize = 60;
        private int frame;
        private Boolean flip;
        private Direction projectileDirection;

        public CandleFireProjectile(Texture2D spritesheet, LinkStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            projectileDirection = stateMachine.getDirection();
            if(projectileDirection == Direction.MoveUp)
            {
                xLoc = stateMachine.getXLoc();
                yLoc = stateMachine.getYLoc() - candleSize;
            } 
            else if(projectileDirection == Direction.MoveDown)
            {
                xLoc = stateMachine.getXLoc();
                yLoc = stateMachine.getYLoc() + candleSize;
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                xLoc = stateMachine.getXLoc() - candleSize;
                yLoc = stateMachine.getYLoc();
            }
            else //MoveRight
            {
                xLoc = stateMachine.getXLoc() + candleSize;
                yLoc = stateMachine.getYLoc();
            }
            flip = false;
            sourceRectangle = new Rectangle(191, 185, 15, 15);
            destinationRectangle = new Rectangle(xLoc, yLoc, candleSize, candleSize);
            frame = 0;
            this.spritesheet = spritesheet;
        }
        public void Update()
        {
            if (frame >= 20) stateMachine.RemoveProjectile(this);
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
            destinationRectangle = new Rectangle(xLoc, yLoc, candleSize, candleSize);
            flip = !flip;
            frame++;
        }

        public void Draw(SpriteBatch spriteBatch)
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
