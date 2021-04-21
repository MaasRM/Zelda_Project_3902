using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class WizzrobeMagic : IProjectile, IEnemyProjectile
    {
        private Vector2 movement;
        private int xLoc, yLoc, damage, frame;
        private Texture2D spritesheet;

        public WizzrobeMagic(int x, int y, Texture2D spritesheet, Direction dir, WizzrobeStateMachine.WizzrobeColor c)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            this.spritesheet = spritesheet;
        }

        public void Update()
        {
            frame++;
            xLoc += (int)movement.X * GameConstants.SCALE;
            yLoc += (int)movement.Y * GameConstants.SCALE;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, GetProjectileLocation(), GetSource(), Color.White);
        }

        public Rectangle GetProjectileLocation()
        {
            return new Rectangle((int)xLoc, (int)yLoc, FireballConstants.WIDTH * GameConstants.SCALE, FireballConstants.HEIGHT * GameConstants.SCALE);
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
            return false;
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
