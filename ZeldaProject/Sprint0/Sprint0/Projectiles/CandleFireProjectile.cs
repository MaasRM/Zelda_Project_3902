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

        private const int candleSpeed = 12; //x4 specs
        private const int candleSize = 60;
        private const int DAMAGE = 1;
        private const int LASTMOVINGFRAME = 10;
        private const int REMOVEFRAME = 20;

        public CandleFireProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, List<SoundEffect> Link_soundEffects)
        {
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
            Link_soundEffects[3].Play();
        }
        public void Update()
        {
            if (frame < LASTMOVINGFRAME)
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
            // Do nothing
        }
    }
}
