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
        //This class is for the sword beam mechanic when link is at full health. Not used in sprint 2

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D spritesheet;
        private int xLoc;
        private int yLoc;
        private int frame;
        private Direction projectileVerticleDirection;
        private Direction projectileHorizontalDirection;
        private SpriteEffects flip;

        private const int blastSpeed = 10; //x4 specs
        private const int DAMAGE = 0;
        private const int HITFRAME = 5;

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
                yLoc -= blastSpeed;
            } else
            {
                yLoc += blastSpeed;
            }
            if (projectileHorizontalDirection == Direction.MoveLeft)
            {
                xLoc -= blastSpeed;
            }
            else
            {
                xLoc += blastSpeed;
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
            return frame >= HITFRAME;
        }

        public int GetDamage()
        {
            return DAMAGE;
        }

        public void Hit()
        {
            //This projectile doesn't interact
        }
    }
}
