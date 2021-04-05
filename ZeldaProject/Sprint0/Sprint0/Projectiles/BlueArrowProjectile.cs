using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
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
        private int frame;
        private Direction projectileDirection;
        private SpriteEffects flip;

        private const int ArrowSpeed = 30; //x4 specs
        private const int DAMAGE = 2;
        private const int ArrowLength = 60;
        private const int ArrowWidth = 30;
        private const int HITFRAME = 14;
        private const int REMOVEFRAME = 17;

        public BlueArrowProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, List<SoundEffect> Link_soundEffects)
        {
            this.spritesheet = spritesheet;
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp)
            {
                xLoc = stateMachine.getXLoc() + ArrowWidth / 2;
                yLoc = stateMachine.getYLoc() - ArrowLength;
                flip = SpriteEffects.None;
            }
            else if (projectileDirection == Direction.MoveDown)
            {
                xLoc = stateMachine.getXLoc() + ArrowWidth / 2;
                yLoc = stateMachine.getYLoc() + ArrowLength;
                flip = SpriteEffects.FlipVertically;
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                xLoc = stateMachine.getXLoc() - ArrowWidth;
                yLoc = stateMachine.getYLoc() + ArrowLength / 2;
                flip = SpriteEffects.FlipHorizontally;
            }
            else //MoveRight
            {
                xLoc = stateMachine.getXLoc() + ArrowWidth;
                yLoc = stateMachine.getYLoc() + ArrowLength / 2;
                flip = SpriteEffects.None;
            }
            if (projectileDirection == Direction.MoveUp || projectileDirection == Direction.MoveDown)
            {
                sourceRectangle = new Rectangle(27, 185, 8, 15);
                destinationRectangle = new Rectangle(xLoc, yLoc, ArrowWidth, ArrowLength);
            }
            else
            {
                sourceRectangle = new Rectangle(36, 188, 15, 8);
                destinationRectangle = new Rectangle(xLoc, yLoc, ArrowLength, ArrowWidth);
            }
            frame = 0;
            Link_soundEffects[0].Play();
        }
        public void Update()
        {
            if (frame < HITFRAME + 1)
            {
                if (projectileDirection == Direction.MoveUp) yLoc -= ArrowSpeed;
                else if (projectileDirection == Direction.MoveDown) yLoc += ArrowSpeed;
                else if (projectileDirection == Direction.MoveLeft)xLoc -= ArrowSpeed;
                else xLoc += ArrowSpeed;

                if (projectileDirection == Direction.MoveUp || projectileDirection == Direction.MoveDown) destinationRectangle = new Rectangle(xLoc, yLoc, ArrowWidth, ArrowLength);
                else destinationRectangle = new Rectangle(xLoc, yLoc, ArrowLength, ArrowWidth);
            }
            else
            {
                sourceRectangle = new Rectangle(53, 185, 8, 15);
                if (projectileDirection == Direction.MoveLeft || projectileDirection == Direction.MoveRight)
                {
                    if (frame == HITFRAME + 1)
                    {
                        if (projectileDirection == Direction.MoveLeft) xLoc -= ArrowWidth / 2;
                        else xLoc += ArrowWidth / 2;
                    }
                    destinationRectangle = new Rectangle(xLoc, yLoc, ArrowLength, ArrowWidth);
                }
                else destinationRectangle = new Rectangle(xLoc, yLoc, ArrowWidth, ArrowLength);
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
