using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class BrownBoomerangProjectile : IProjectile, IPlayerProjectile, IBoomerang
    {
        private LinkStateMachine stateMachine;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D spritesheet;
        private int xLoc;
        private int yLoc;
        private int boomerangSpeed = 20; //x4 specs
        private const int DAMAGE = 1;
        private int xSize = 30;
        private int ySize = 60;
        private int frame;
        private bool goBack;
        private bool remove;
        private Direction projectileDirection;
        private SpriteEffects flip;
        private SoundEffectInstance flyingBoomerang;

        public BrownBoomerangProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, List<SoundEffect> Link_soundEffects)
        {
            this.spritesheet = spritesheet;
            this.stateMachine = stateMachine;
            remove = false;
            projectileDirection = stateMachine.getDirection();
            if (projectileDirection == Direction.MoveUp) {
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() - ySize;
            } else if (projectileDirection == Direction.MoveDown) {
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() + ySize;
            } else if (projectileDirection == Direction.MoveLeft) {
                xLoc = stateMachine.getXLoc() - xSize;
                yLoc = stateMachine.getYLoc();
            } else {
                xLoc = stateMachine.getXLoc() + xSize * 2;
                yLoc = stateMachine.getYLoc();
            }
            goBack = false;
            flip = SpriteEffects.None;
            sourceRectangle = new Rectangle(64, 185, 8, 15);
            destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            frame = 0;
            flyingBoomerang = Link_soundEffects[0].CreateInstance();
            flyingBoomerang.IsLooped = true;
            flyingBoomerang.Play();
        }

        public void Update()
        {
            if (boomerangSpeed > 0 && !goBack) {
                if (projectileDirection == Direction.MoveUp) yLoc -= boomerangSpeed;
                else if (projectileDirection == Direction.MoveDown) yLoc += boomerangSpeed;
                else if (projectileDirection == Direction.MoveLeft) xLoc -= boomerangSpeed;
                else xLoc += boomerangSpeed;
                boomerangSpeed -= 1;
            }
            else {
                goBack = true;
                boomerangSpeed += 1;
                if(xLoc - stateMachine.getXLoc() >= boomerangSpeed) xLoc -= boomerangSpeed;
                else if(xLoc - stateMachine.getXLoc() <= boomerangSpeed * -1) xLoc += boomerangSpeed;
                if (yLoc - stateMachine.getYLoc() >= boomerangSpeed) yLoc -= boomerangSpeed;
                else if (yLoc - stateMachine.getYLoc() <= boomerangSpeed * -1) yLoc += boomerangSpeed;
                if (Math.Abs(xLoc - stateMachine.getXLoc()) <= boomerangSpeed && Math.Abs(yLoc - stateMachine.getYLoc()) <= boomerangSpeed) remove = true;
            }
            destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            SetSourceAndEffects();

            if (remove) flyingBoomerang.Stop();
            frame++;
        }

        private  void SetSourceAndEffects()
        {
            if (frame % 4 == 0)
            {
                sourceRectangle = new Rectangle(64, 185, 8, 15);
            }
            else if (frame % 4 == 1 || frame % 4 == 3)
            {
                sourceRectangle = new Rectangle(73, 185, 8, 15);
            }
            else if (frame % 4 == 2)
            {
                sourceRectangle = new Rectangle(82, 185, 8, 15);
            }
            if (frame % 8 == 0 || frame % 8 == 1 || frame % 8 == 2)
            {
                flip = SpriteEffects.None;
            }
            else if (frame % 8 == 3 || frame % 8 == 4)
            {
                flip = SpriteEffects.FlipHorizontally;
            }
            else if (frame % 8 == 5)
            {
                flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
            }
            else if (frame % 8 == 6 || frame % 8 == 7)
            {
                flip = SpriteEffects.FlipVertically;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), flip, 0f);
        }

        public Rectangle GetProjectileLocation()
        {
            return destinationRectangle;
        }

        public void GoBack()
        {
            goBack = true;
        }

        public bool CheckForRemoval()
        {
            return remove;
        }

        public int GetDamage()
        {
            return DAMAGE;
        }

        public void Hit()
        {
            GoBack();
        }
    }
}
