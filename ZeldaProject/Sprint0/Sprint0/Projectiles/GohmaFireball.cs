using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class GohmaFireball : IProjectile, IEnemyProjectile
    {
        private Texture2D spritesheet;
        private double x, y;
        private int frame;
        private int gameMaxX, gameMaxY;

        public GohmaFireball(int x, int y, Texture2D spritesheet, Sprint4 game)
        {
            this.x = x;
            this.y = y;
            frame = -1;
            this.spritesheet = spritesheet;
            gameMaxX = game.GraphicsDevice.Viewport.Width;
            gameMaxY = game.GraphicsDevice.Viewport.Height;
        }

        public void Update()
        {
            frame++;
            y -= FireballConstants.MOVEDIST * GameConstants.SCALE;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, GetProjectileLocation(), GetSource(), Color.White);
        }

        public Rectangle GetProjectileLocation()
        {
            return new Rectangle((int)x, (int)y, FireballConstants.WIDTH * GameConstants.SCALE, FireballConstants.HEIGHT * GameConstants.SCALE);
        }

        private Rectangle GetSource()
        {
            if (frame % 4 == 0)
            {
                return new Rectangle(101, 11, FireballConstants.WIDTH, FireballConstants.HEIGHT);
            }
            else if (frame % 4 == 1)
            {
                return new Rectangle(110, 11, FireballConstants.WIDTH, FireballConstants.HEIGHT);
            }
            else if (frame % 4 == 2)
            {
                return new Rectangle(119, 11, FireballConstants.WIDTH, FireballConstants.HEIGHT);
            }
            else
            {
                return new Rectangle(128, 11, FireballConstants.WIDTH, FireballConstants.HEIGHT);
            }
        }

        public bool CheckForRemoval()
        {
            double xCenter = x + FireballConstants.WIDTH * GameConstants.SCALE / 2;
            double yCenter = y + FireballConstants.HEIGHT * GameConstants.SCALE / 2;
            return (xCenter < 0 || xCenter >= gameMaxX) && (yCenter < 0 || yCenter >= gameMaxY);
        }

        public int GetDamage()
        {
            return FireballConstants.DAMAGE;
        }

        public void Deflect(Vector2 deflectVector)
        {
            //Doesn't deflect
        }

        public void Hit()
        {
            //Doesn't hit
        }
    }
}