using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private int xLoc;
        private int yLoc;
        private const int bombSizeX = 30; //x4 specs
        private const int bombSizeY = 60;
        private const int DAMAGE = 4;
        private int frame;
        private Direction projectileDirection;
        public BombProjectile(Texture2D spritesheet, LinkStateMachine stateMachine)
        {
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp)
            {
                xLoc = stateMachine.getXLoc() + bombSizeX/2;
                yLoc = stateMachine.getYLoc() - bombSizeY;
            }
            else if (projectileDirection == Direction.MoveDown)
            {
                xLoc = stateMachine.getXLoc() + bombSizeX / 2;
                yLoc = stateMachine.getYLoc() + bombSizeY;
            }
            else if (projectileDirection == Direction.MoveLeft)
            {
                xLoc = stateMachine.getXLoc() - bombSizeX;
                yLoc = stateMachine.getYLoc();
            }
            else //MoveRight
            {
                xLoc = stateMachine.getXLoc() + bombSizeX * 2;
                yLoc = stateMachine.getYLoc();
            }
            sourceRectangle = new Rectangle(129, 185, 8, 15);
            destinationRectangle = new Rectangle(xLoc, yLoc, bombSizeX, bombSizeY);
            frame = 0;
            this.spritesheet = spritesheet;
        }

        public void Update()
        {
            if(frame == 20)
            {
                xLoc -= bombSizeX/2;
                destinationRectangle = new Rectangle(xLoc, yLoc, bombSizeY, bombSizeY);
            }
            if (frame > 20)
            {
                sourceRectangle = new Rectangle(138 + (frame - 20)*17, 185, 15, 15);
            }
            frame++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetProjectileLocation()
        {
            return destinationRectangle;
        }

        public bool Exploding()
        {
            return frame > 20;
        }

        public bool CheckForRemoval()
        {
            return frame > 22;
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
