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

        public BlueArrowProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, List<SoundEffect> Link_soundEffects)
        {
            this.spritesheet = spritesheet;
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp) {
                xLoc = stateMachine.getXLoc() + ArrowConstants.ArrowWidth / 2;
                yLoc = stateMachine.getYLoc() - ArrowConstants.ArrowLength;
                flip = SpriteEffects.None;
            } else if (projectileDirection == Direction.MoveDown) {
                xLoc = stateMachine.getXLoc() + ArrowConstants.ArrowWidth / 2;
                yLoc = stateMachine.getYLoc() + ArrowConstants.ArrowLength;
                flip = SpriteEffects.FlipVertically;
            } else if (projectileDirection == Direction.MoveLeft) {
                xLoc = stateMachine.getXLoc() - ArrowConstants.ArrowWidth;
                yLoc = stateMachine.getYLoc() + ArrowConstants.ArrowLength / 2;
                flip = SpriteEffects.FlipHorizontally;
            } else {
                xLoc = stateMachine.getXLoc() + ArrowConstants.ArrowWidth;
                yLoc = stateMachine.getYLoc() + ArrowConstants.ArrowLength / 2;
                flip = SpriteEffects.None;
            }
            if (projectileDirection == Direction.MoveUp || projectileDirection == Direction.MoveDown) {
                sourceRectangle = new Rectangle(27, 185, 8, 15);
                destinationRectangle = new Rectangle(xLoc, yLoc, ArrowConstants.ArrowWidth, ArrowConstants.ArrowLength);
            } else {
                sourceRectangle = new Rectangle(36, 188, 15, 8);
                destinationRectangle = new Rectangle(xLoc, yLoc, ArrowConstants.ArrowLength, ArrowConstants.ArrowWidth);
            }
            frame = 0;
            Link_soundEffects[0].Play();
        }

        public void Update()
        {
            if (frame < ArrowConstants.BLUEHITFRAME + 1)
            {
                if (projectileDirection == Direction.MoveUp) yLoc -= ArrowConstants.BlueArrowSpeed;
                else if (projectileDirection == Direction.MoveDown) yLoc += ArrowConstants.BlueArrowSpeed;
                else if (projectileDirection == Direction.MoveLeft)xLoc -= ArrowConstants.BlueArrowSpeed;
                else xLoc += ArrowConstants.BlueArrowSpeed;

                if (projectileDirection == Direction.MoveUp || projectileDirection == Direction.MoveDown)
                    destinationRectangle = new Rectangle(xLoc, yLoc, ArrowConstants.ArrowWidth, ArrowConstants.ArrowLength);
                else destinationRectangle = new Rectangle(xLoc, yLoc, ArrowConstants.ArrowLength, ArrowConstants.ArrowWidth);
            }
            else
            {
                sourceRectangle = new Rectangle(53, 185, 8, 15);
                if (projectileDirection == Direction.MoveLeft || projectileDirection == Direction.MoveRight)
                {
                    if (frame == ArrowConstants.BLUEHITFRAME + 1)
                    {
                        if (projectileDirection == Direction.MoveLeft) xLoc -= ArrowConstants.ArrowWidth / 2;
                        else xLoc += ArrowConstants.ArrowWidth / 2;
                    }
                    destinationRectangle = new Rectangle(xLoc, yLoc, ArrowConstants.ArrowLength, ArrowConstants.ArrowWidth);
                }
                else destinationRectangle = new Rectangle(xLoc, yLoc, ArrowConstants.ArrowWidth, ArrowConstants.ArrowLength);
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
            return frame >= ArrowConstants.BLUEREMOVEFRAME;
        }

        public int GetDamage()
        {
            return ArrowConstants.BLUEDAMAGE;
        }

        public void Hit()
        {
            if (frame < ArrowConstants.BLUEHITFRAME)
            {
                frame = ArrowConstants.BLUEHITFRAME;
            }
        }
    }
}
