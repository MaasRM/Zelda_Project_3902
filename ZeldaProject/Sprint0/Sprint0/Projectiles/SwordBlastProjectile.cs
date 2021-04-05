using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Text;

namespace Sprint0
{
    class SwordBlastProjectile : IProjectile, IPlayerProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D spritesheet;
        private int xLoc;
        private int yLoc;
        private int frame;
        private Direction projectileVerticleDirection;
        private Direction projectileHorizontalDirection;
        private SpriteEffects flip;

        public SwordBlastProjectile(Texture2D spritesheet, int x, int y, Direction verticleDirection, Direction horizontalDirection, SpriteEffects flip)
        {
            this.spritesheet = spritesheet;
            xLoc = x;
            yLoc = y;
            projectileVerticleDirection = verticleDirection;
            projectileHorizontalDirection = horizontalDirection;
            this.flip = flip;
            destinationRectangle = new Rectangle(xLoc, yLoc, 30, 60);
            sourceRectangle = new Rectangle(27, 155, 8, 15);
            frame = 0;
        }

        public void Update()
        {
            frame++;
            sourceRectangle.Offset(35 * (int)Math.Pow(-1, (frame % 2) + 1), 0);
            if(projectileVerticleDirection == Direction.MoveUp)
            {
                yLoc -= SwordBlastConstants.blastSpeed;
            } else
            {
                yLoc += SwordBlastConstants.blastSpeed;
            }
            if (projectileHorizontalDirection == Direction.MoveLeft)
            {
                xLoc -= SwordBlastConstants.blastSpeed;
            }
            else
            {
                xLoc += SwordBlastConstants.blastSpeed;
            }
            destinationRectangle = new Rectangle(xLoc, yLoc, 30, 60);
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
            return frame >= SwordBlastConstants.HITFRAME;
        }

        public int GetDamage()
        {
            return SwordBlastConstants.DAMAGE;
        }

        public void Hit()
        {
            //This projectile doesn't interact
        }
    }
}
