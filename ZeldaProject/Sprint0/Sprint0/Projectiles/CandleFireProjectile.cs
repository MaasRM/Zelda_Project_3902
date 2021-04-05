using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class CandleFireProjectile: IProjectile, IPlayerProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D spritesheet;
        private int xLoc;
        private int yLoc;
        private int frame;
        private bool flip;
        private Direction projectileDirection;

        public CandleFireProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, List<SoundEffect> Link_soundEffects)
        {
            projectileDirection = stateMachine.getDirection();
            if(projectileDirection == Direction.Up)
            {
                xLoc = stateMachine.getXLoc();
                yLoc = stateMachine.getYLoc() - CandleFireConstants.candleSize;
            } 
            else if(projectileDirection == Direction.Down)
            {
                xLoc = stateMachine.getXLoc();
                yLoc = stateMachine.getYLoc() + CandleFireConstants.candleSize;
            }
            else if (projectileDirection == Direction.Left)
            {
                xLoc = stateMachine.getXLoc() - CandleFireConstants.candleSize;
                yLoc = stateMachine.getYLoc();
            }
            else //MoveRight
            {
                xLoc = stateMachine.getXLoc() + CandleFireConstants.candleSize;
                yLoc = stateMachine.getYLoc();
            }
            flip = false;
            sourceRectangle = new Rectangle(191, 185, 15, 15);
            destinationRectangle = new Rectangle(xLoc, yLoc, CandleFireConstants.candleSize, CandleFireConstants.candleSize);
            frame = 0;
            this.spritesheet = spritesheet;
            Link_soundEffects[3].Play();
        }
        public void Update()
        {
            if (frame < CandleFireConstants.LASTMOVINGFRAME)
            {
                if (projectileDirection == Direction.Up)
                {
                    yLoc -= CandleFireConstants.candleSpeed;
                }
                else if (projectileDirection == Direction.Down)
                {
                    yLoc += CandleFireConstants.candleSpeed;
                }
                else if (projectileDirection == Direction.Left)
                {
                    xLoc -= CandleFireConstants.candleSpeed;
                }
                else //MoveRight
                {
                    xLoc += CandleFireConstants.candleSpeed;
                }
            }
            destinationRectangle = new Rectangle(xLoc, yLoc, CandleFireConstants.candleSize, CandleFireConstants.candleSize);
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

        public Rectangle GetProjectileLocation()
        {
            return destinationRectangle;
        }

        public bool CheckForRemoval()
        {
            return frame >= CandleFireConstants.REMOVEFRAME;
        }

        public int GetDamage()
        {
            return CandleFireConstants.DAMAGE;
        }

        public void Hit()
        {
            // Do nothing
        }
    }
}
