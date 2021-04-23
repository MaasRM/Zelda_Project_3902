using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace Sprint0
{
    class SwordProjectile : IProjectile, IPlayerProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Texture2D spritesheet;
        private Sprint5 game;
        private int damage;
        private int xLoc;
        private int yLoc;
        private int xSize;
        private int ySize;
        private int frame;
        private Direction projectileDirection;
        private SpriteEffects flip;

        public SwordProjectile(Texture2D spritesheet, LinkStateMachine stateMachine, LinkColor c, Sprint5 game)
        {
            this.spritesheet = spritesheet;
            this.game = game;
            projectileDirection = stateMachine.getDirection();

            InitializePos(stateMachine);

            if (projectileDirection == Direction.Up || projectileDirection == Direction.Down) sourceRectangle = new Rectangle(1, 154, 8, 15);
            else sourceRectangle = new Rectangle(10, 154, 15, 15);

            DamageSet(stateMachine, c);

            destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            frame = 0;
            game.Link_soundEffects[7].Play();
        }

        private void InitializePos(LinkStateMachine stateMachine)
        {
            if (projectileDirection == Direction.Up) {
                xSize = SwordProjectileConstants.SwordWidth;
                ySize = SwordProjectileConstants.SwordLength;
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() - ySize;
                flip = SpriteEffects.None;
            } else if (projectileDirection == Direction.Down) {
                xSize = SwordProjectileConstants.SwordWidth;
                ySize = SwordProjectileConstants.SwordLength;
                xLoc = stateMachine.getXLoc() + xSize / 2;
                yLoc = stateMachine.getYLoc() + ySize;
                flip = SpriteEffects.FlipVertically;
            } else if (projectileDirection == Direction.Left) {
                xSize = SwordProjectileConstants.SwordLength;
                ySize = SwordProjectileConstants.SwordLength;
                xLoc = stateMachine.getXLoc() - xSize;
                yLoc = stateMachine.getYLoc() + ySize / 8;
                flip = SpriteEffects.FlipHorizontally;
            } else {
                xSize = SwordProjectileConstants.SwordLength;
                ySize = SwordProjectileConstants.SwordLength;
                xLoc = stateMachine.getXLoc() + xSize;
                yLoc = stateMachine.getYLoc() + ySize / 4;
                flip = SpriteEffects.None;
            }
        }

        public void Update()
        {
            frame++;
            sourceRectangle.Offset(35 * (int)Math.Pow(-1, (frame % 2) + 1), 0);
            if (frame < SwordProjectileConstants.HITFRAME) {

                if (projectileDirection == Direction.Up) yLoc -= SwordProjectileConstants.SwordSpeed;
                else if (projectileDirection == Direction.Down) yLoc += SwordProjectileConstants.SwordSpeed;
                else if (projectileDirection == Direction.Left) xLoc -= SwordProjectileConstants.SwordSpeed;
                else xLoc += SwordProjectileConstants.SwordSpeed;
                destinationRectangle = new Rectangle(xLoc, yLoc, xSize, ySize);
            } else { 
                game.Link_soundEffects[1].Play();
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc - SwordProjectileConstants.XBLASTOFFSET, yLoc - SwordProjectileConstants.YBLASTOFFSET, Direction.Up, Direction.Left, SpriteEffects.None));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc, yLoc - SwordProjectileConstants.YBLASTOFFSET, Direction.Up, Direction.Right, SpriteEffects.FlipHorizontally));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc - SwordProjectileConstants.XBLASTOFFSET, yLoc + SwordProjectileConstants.YBLASTOFFSET, Direction.Down, Direction.Left, SpriteEffects.FlipVertically));
                game.AddProjectile(new SwordBlastProjectile(spritesheet, xLoc, yLoc + SwordProjectileConstants.YBLASTOFFSET, Direction.Down, Direction.Right, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally));
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

        public bool CheckForRemoval()
        {
            return frame >= SwordProjectileConstants.HITFRAME;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void Hit()
        {
            if (frame < SwordProjectileConstants.HITFRAME)
            {
                frame = SwordProjectileConstants.HITFRAME;
            }
        }

        private void DamageSet(LinkStateMachine stateMachine, LinkColor c)
        {
            double multiplier = 1.0;

            if (c == LinkColor.Red || c == LinkColor.Black)
            {
                multiplier *= 2;
            }
            if (c == LinkColor.Blue)
            {
                multiplier /= 2;
            }

            damage = (int)(stateMachine.healthAndDamage.DealDamage() * multiplier);

            if (damage == 0) damage = 1;
        }
    }
}
