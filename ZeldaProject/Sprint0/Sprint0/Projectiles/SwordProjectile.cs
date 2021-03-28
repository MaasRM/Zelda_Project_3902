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
        private const int SwordSpeed = 30; //x4 specs
        private const int DAMAGE = 2;
        private int SwordLength = 60;
        private int SwordWidth = 30;
        private int frame;
        private const int HITFRAME = 20;
        private Direction projectileDirection;
        private SpriteEffects flip;
        public SwordProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, Sprint3 game)
        {
            this.spritesheet = spritesheet;
            this.game = game;
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp)
            {
                xSize = SwordWidth;
                ySize = SwordLength;
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() - ySize;
                flip = SpriteEffects.None;
            }
            else if (projectileDirection == Direction.MoveDown)
            {
                xSize = SwordWidth;
                ySize = SwordLength;
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() + ySize;
                flip = SpriteEffects.FlipVertically;
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                xSize = SwordLength;
                ySize = SwordLength;
                xLoc = stateMachine.getXLoc() - xSize;
                yLoc = stateMachine.getYLoc() + ySize / 8;
                flip = SpriteEffects.FlipHorizontally;
            }
            else //MoveRight
            {
                xSize = SwordLength;
                ySize = SwordLength;
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
        }

        public void Update()
        {
            frame++;
            sourceRectangle.Offset(35 * (int)Math.Pow(-1, (frame % 2) + 1), 0);
            if (frame < HITFRAME)
            {
                if (projectileDirection == Direction.MoveUp)
                {
                    yLoc -= SwordSpeed;
                }
                else if (projectileDirection == Direction.MoveDown)
                {
                    yLoc += SwordSpeed;
                }
                else if (projectileDirection == Direction.MoveLeft)
                {
                    xLoc -= SwordSpeed;
                }
                else //MoveRight
                {
                    xLoc += SwordSpeed;
                }
                destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            } 
            else
            {
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc - 30, yLoc - 10, Direction.MoveUp, Direction.MoveLeft, SpriteEffects.None, game.Link_soundEffects[7].CreateInstance()));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc, yLoc - 10, Direction.MoveUp, Direction.MoveRight, SpriteEffects.FlipHorizontally, game.Link_soundEffects[7].CreateInstance()));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc - 30, yLoc + 10, Direction.MoveDown, Direction.MoveLeft, SpriteEffects.FlipVertically, game.Link_soundEffects[7].CreateInstance()));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc, yLoc + 10, Direction.MoveDown, Direction.MoveRight, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally, game.Link_soundEffects[7].CreateInstance()));
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
            return frame >= HITFRAME;
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
