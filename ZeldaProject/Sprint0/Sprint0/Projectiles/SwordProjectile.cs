using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace Sprint0
{
    class SwordProjectile : IProjectile, IPlayerProjectile
    {
        //This class is for the sword beam mechanic when link is at full health. Not used in sprint 2

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D spritesheet;
        private Sprint3 game;
        private int xLoc;
        private int yLoc;
        private int xSize;
        private int ySize;
        private int frame;
        private Direction projectileDirection;
        private SpriteEffects flip;

        public SwordProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, Sprint3 game)
        {
            this.spritesheet = spritesheet;
            this.game = game;
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp)
            {
                xSize = SwordProjectileConstants.SwordWidth;
                ySize = SwordProjectileConstants.SwordLength;
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() - ySize;
                flip = SpriteEffects.None;
            }
            else if (projectileDirection == Direction.MoveDown)
            {
                xSize = SwordProjectileConstants.SwordWidth;
                ySize = SwordProjectileConstants.SwordLength;
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() + ySize;
                flip = SpriteEffects.FlipVertically;
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                xSize = SwordProjectileConstants.SwordLength;
                ySize = SwordProjectileConstants.SwordLength;
                xLoc = stateMachine.getXLoc() - xSize;
                yLoc = stateMachine.getYLoc() + ySize / 8;
                flip = SpriteEffects.FlipHorizontally;
            }
            else //MoveRight
            {
                xSize = SwordProjectileConstants.SwordLength;
                ySize = SwordProjectileConstants.SwordLength;
                xLoc = stateMachine.getXLoc() + xSize;
                yLoc = stateMachine.getYLoc() + ySize / 4;
                flip = SpriteEffects.None;
            }
            if (projectileDirection == Direction.MoveUp || projectileDirection == Direction.MoveDown)
            {
                sourceRectangle = new Rectangle(1, 154, 8, 15);
            }
            else
            {
                sourceRectangle = new Rectangle(10, 154, 15, 15);
            }
            destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            frame = 0;
            game.Link_soundEffects[7].Play();
        }

        public void Update()
        {
            frame++;
            sourceRectangle.Offset(35 * (int)Math.Pow(-1, (frame % 2) + 1), 0);
            if (frame < SwordProjectileConstants.HITFRAME)
            {
                if (projectileDirection == Direction.MoveUp)
                {
                    yLoc -= SwordProjectileConstants.SwordSpeed;
                }
                else if (projectileDirection == Direction.MoveDown)
                {
                    yLoc += SwordProjectileConstants.SwordSpeed;
                }
                else if (projectileDirection == Direction.MoveLeft)
                {
                    xLoc -= SwordProjectileConstants.SwordSpeed;
                }
                else //MoveRight
                {
                    xLoc += SwordProjectileConstants.SwordSpeed;
                }
                destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            } 
            else
            {
                game.Link_soundEffects[1].Play();
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc - SwordProjectileConstants.XBLASTOFFSET, yLoc - SwordProjectileConstants.YBLASTOFFSET, Direction.MoveUp, Direction.MoveLeft, SpriteEffects.None));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc, yLoc - SwordProjectileConstants.YBLASTOFFSET, Direction.MoveUp, Direction.MoveRight, SpriteEffects.FlipHorizontally));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc - SwordProjectileConstants.XBLASTOFFSET, yLoc + SwordProjectileConstants.YBLASTOFFSET, Direction.MoveDown, Direction.MoveLeft, SpriteEffects.FlipVertically));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc, yLoc + SwordProjectileConstants.YBLASTOFFSET, Direction.MoveDown, Direction.MoveRight, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally));
            }
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
            return frame >= SwordProjectileConstants.HITFRAME;
        }

        public int GetDamage()
        {
            return SwordProjectileConstants.DAMAGE;
        }

        public void Hit()
        {
            if (frame < SwordProjectileConstants.HITFRAME)
            {
                frame = SwordProjectileConstants.HITFRAME;
            }
        }
    }
}
