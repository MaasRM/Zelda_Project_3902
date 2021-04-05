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

        private const int bombSizeX = 30; //x4 specs
        private const int bombSizeY = 60;
        private const int DAMAGE = 4;
        private const int EXPLODEFRAME = 20;
        private const int REMOVEFRAME = 22;

        public BombProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, List<SoundEffect> Link_soundEffects)
        {
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp)
            {
                loc = new Vector2(stateMachine.getXLoc() + bombSizeX/2, stateMachine.getYLoc() - bombSizeY);
            }
            else if (projectileDirection == Direction.MoveDown)
            {
                loc = new Vector2(stateMachine.getXLoc() + bombSizeX / 2, stateMachine.getYLoc() + bombSizeY);
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                loc = new Vector2(stateMachine.getXLoc() - bombSizeX, stateMachine.getYLoc());
            }
            else 
            {
                loc = new Vector2(stateMachine.getXLoc() + bombSizeX * 2, stateMachine.getYLoc());
            }
            sourceRectangle = new Rectangle(129, 185, 8, 15);
            destinationRectangle = new Rectangle((int)loc.X, (int)loc.Y, bombSizeX, bombSizeY);
            frame = 0;
            this.spritesheet = spritesheet;
            soundEffects = Link_soundEffects;
            placedDown = false;
        }

        public void Update()
        {
            if(frame == EXPLODEFRAME)
            {
                soundEffects[1].Play();
                placedDown = false;

                loc.X -= bombSizeX/2;
                destinationRectangle = new Rectangle((int)loc.X, (int)loc.Y, bombSizeY, bombSizeY);
            }
            if (frame > EXPLODEFRAME)
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
            return frame > EXPLODEFRAME;
        }

        public bool CheckForRemoval()
        {
            return frame > REMOVEFRAME;
        }

        public int GetDamage()
        {
            return DAMAGE;
        }

        public void Hit()
        {
            //do nothing
        }
    }
}
