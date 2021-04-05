using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class BombProjectile : IProjectile, IPlayerProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D spritesheet;
        private Vector2 loc;
        private int frame;
        private Direction projectileDirection;
        private List<SoundEffect> soundEffects;
        private bool placedDown;

        public BombProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, List<SoundEffect> Link_soundEffects)
        {
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.Up)
            {
                loc = new Vector2(stateMachine.getXLoc() + BombConstants.bombSizeX/2, stateMachine.getYLoc() - BombConstants.bombSizeY);
            }
            else if (projectileDirection == Direction.Down)
            {
                loc = new Vector2(stateMachine.getXLoc() + BombConstants.bombSizeX / 2, stateMachine.getYLoc() + BombConstants.bombSizeY);
            }
            else if (projectileDirection == Direction.Left)
            {
                loc = new Vector2(stateMachine.getXLoc() - BombConstants.bombSizeX, stateMachine.getYLoc());
            }
            else 
            {
                loc = new Vector2(stateMachine.getXLoc() + BombConstants.bombSizeX * 2, stateMachine.getYLoc());
            }
            sourceRectangle = new Rectangle(129, 185, 8, 15);
            destinationRectangle = new Rectangle((int)loc.X, (int)loc.Y, BombConstants.bombSizeX, BombConstants.bombSizeY);
            frame = 0;
            this.spritesheet = spritesheet;
            soundEffects = Link_soundEffects;
            placedDown = false;
        }

        public void Update()
        {
            if(frame == BombConstants.EXPLODEFRAME)
            {
                soundEffects[1].Play();
                placedDown = false;

                loc.X -= BombConstants.bombSizeX / 2;
                destinationRectangle = new Rectangle((int)loc.X, (int)loc.Y, BombConstants.bombSizeY, BombConstants.bombSizeY);
            }
            if (frame > BombConstants.EXPLODEFRAME)
            {
                sourceRectangle = new Rectangle(138 + (frame - 20)*17, 185, 15, 15);
            }
            frame++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!placedDown)
            {
                soundEffects[2].Play();
                placedDown = true;
            }
            spriteBatch.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetProjectileLocation()
        {
            return destinationRectangle;
        }

        public bool Exploding()
        {
            return frame > BombConstants.EXPLODEFRAME;
        }

        public bool CheckForRemoval()
        {
            return frame > BombConstants.REMOVEFRAME;
        }

        public int GetDamage()
        {
            return BombConstants.DAMAGE;
        }

        public void Hit()
        {
            //do nothing
        }
    }
}
