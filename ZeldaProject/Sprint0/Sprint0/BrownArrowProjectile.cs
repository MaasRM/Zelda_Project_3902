using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class BrownArrowProjectile : IProjectile
    {
        private LinkStateMachine stateMachine;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xLoc;
        private int yLoc;
        private int xSize;
        private int ySize;
        private const int ArrowSpeed = 20;
        private int ArrowLength = 60;
        private int ArrowWidth = 30;
        private int frame;
        private Direction projectileDirection;
        private SpriteEffects flip;
        private float rotation;
        public BrownArrowProjectile(LinkStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp)
            {
                xSize = ArrowWidth;
                ySize = ArrowLength;
                xLoc = stateMachine.getXLoc() + xSize/4;
                yLoc = stateMachine.getYLoc() - ySize;
                flip = SpriteEffects.None;
            }
            else if (projectileDirection == Direction.MoveDown)
            {
                xSize = ArrowWidth;
                ySize = ArrowLength;
                xLoc = stateMachine.getXLoc() + xSize/4;
                yLoc = stateMachine.getYLoc() + ySize;
                flip = SpriteEffects.FlipVertically;
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                xSize = ArrowLength;
                ySize = ArrowWidth;
                xLoc = stateMachine.getXLoc() - xSize;
                yLoc = stateMachine.getYLoc() + ySize/4;
                flip = SpriteEffects.FlipHorizontally;
            }
            else //MoveRight
            {
                xSize = ArrowLength;
                ySize = ArrowWidth;
                xLoc = stateMachine.getXLoc() + xSize;
                yLoc = stateMachine.getYLoc() + ySize/4;
                flip = SpriteEffects.None;
            }
            if(projectileDirection == Direction.MoveUp || projectileDirection == Direction.MoveDown)
            {
                sourceRectangle = new Rectangle(1, 185, 8, 15);
            } else
            {
                sourceRectangle = new Rectangle(10, 188, 15, 8);
            }
            destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            frame = 0;
            rotation = 0;
        }

        public void Update()
        {
            if (frame >= 18) stateMachine.RemoveProjectile(this);
            if (frame < 15)
            {
                if (projectileDirection == Direction.MoveUp)
                {
                    yLoc -= ArrowSpeed;
                }
                else if (projectileDirection == Direction.MoveDown)
                {
                    yLoc += ArrowSpeed;
                }
                else if (projectileDirection == Direction.MoveLeft)
                {
                    xLoc -= ArrowSpeed;
                }
                else //MoveRight
                {
                    xLoc += ArrowSpeed;
                }
            } else
            {
                sourceRectangle = new Rectangle(53, 185, 8, 15);
                if (projectileDirection == Direction.MoveLeft)
                {
                    //rotation = 0.75f;
                }
                else if (projectileDirection == Direction.MoveRight)
                {
                    //rotation = 0.25f;
                }
            }
            destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            frame++;
        }
        public void Draw(Texture2D spritesheet, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, rotation, new Vector2(0, 0), flip, 0f);
        }
    }
}
