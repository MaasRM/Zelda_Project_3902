using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class BlueArrowProjectile : IProjectile, IPlayerProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D spritesheet;
        private int xLoc;
        private int yLoc;
        private int xSize;
        private int ySize;
        private const int ArrowSpeed = 30; //x4 specs
        private const int DAMAGE = 2;
        private int ArrowLength = 60;
        private int ArrowWidth = 30;
        private int frame;
        private const int HITFRAME = 14;
        private const int REMOVEFRAME = 17;
        private Direction projectileDirection;
        private SpriteEffects flip;
        public BlueArrowProjectile(Texture2D spritesheet, LinkStateMachine stateMachine)
        {
            this.spritesheet = spritesheet;
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp)
            {
                xSize = ArrowWidth;
                ySize = ArrowLength;
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() - ySize;
                flip = SpriteEffects.None;
            }
            else if (projectileDirection == Direction.MoveDown)
            {
                xSize = ArrowWidth;
                ySize = ArrowLength;
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() + ySize;
                flip = SpriteEffects.FlipVertically;
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                xSize = ArrowLength;
                ySize = ArrowWidth;
                xLoc = stateMachine.getXLoc() - xSize;
                yLoc = stateMachine.getYLoc() + ySize / 2;
                flip = SpriteEffects.FlipHorizontally;
            }
            else //MoveRight
            {
                xSize = ArrowLength;
                ySize = ArrowWidth;
                xLoc = stateMachine.getXLoc() + xSize;
                yLoc = stateMachine.getYLoc() + ySize / 2;
                flip = SpriteEffects.None;
            }
            if (projectileDirection == Direction.MoveUp || projectileDirection == Direction.MoveDown)
            {
                sourceRectangle = new Rectangle(27, 185, 8, 15);
            }
            else
            {
                sourceRectangle = new Rectangle(36, 188, 15, 8);
            }
            destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            frame = 0;
        }
        public void Update()
        {
            if (frame < HITFRAME + 1)
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
                destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            }
            else
            {
                sourceRectangle = new Rectangle(53, 185, 8, 15);
                if (projectileDirection == Direction.MoveLeft || projectileDirection == Direction.MoveRight)
                {
                    if (frame == HITFRAME + 1)
                    {
                        yLoc -= ySize / 2;
                        if (projectileDirection == Direction.MoveLeft) xLoc -= xSize/2;
                        else xLoc += xSize/2;
                    }
                    destinationRectangle = new Rectangle(xLoc, yLoc, ySize, xSize);
                }
                else
                {
                    destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
                }
            }
            frame++;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), flip, 0f);
        }

        public Rectangle GetProjectileLocation()
        {
            return destinationRectangle;
        }

        public bool CheckForRemoval()
        {
            return frame >= REMOVEFRAME;
        }

        public int GetDamage()
        {
            return DAMAGE;
        }

        public void Hit()
        {
            if (frame < HITFRAME)
            {
                frame = HITFRAME;
            }
        }
    }
}
