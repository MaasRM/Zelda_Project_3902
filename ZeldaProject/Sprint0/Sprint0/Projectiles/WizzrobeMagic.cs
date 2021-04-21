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
        Direction direction;
        private int xLoc, yLoc, damage, frame;
        private const int LASTFRAME = 18;
        private WizzrobeStateMachine.WizzrobeColor color;
        private SpriteEffects flip;
        private Texture2D spritesheet;

        public WizzrobeMagic(int x, int y, Texture2D spritesheet, Direction dir, WizzrobeStateMachine.WizzrobeColor c)
        {
            xLoc = x;
            yLoc = y;
            frame = -1;
            this.spritesheet = spritesheet;
            direction = dir;
            color = c;

            SetUpMovement();

            if (c == WizzrobeStateMachine.WizzrobeColor.Red) damage = WizzrobeConstants.REDDAMAGE;
            else damage = WizzrobeConstants.BLUEDAMAGE;
        }

        public void Update()
        {
            frame++;
            xLoc += (int)movement.X * GameConstants.SCALE;
            yLoc += (int)movement.Y * GameConstants.SCALE;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, GetProjectileLocation(), GetSource(), Color.White, 0, new Vector2(0, 0), flip, 0f);
        }

        public Rectangle GetProjectileLocation()
        {
            return new Rectangle(xLoc, yLoc, WizzrobeConstants.WIDTHANDHEIGHT * GameConstants.SCALE, WizzrobeConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
        }

        private Rectangle GetSource()
        {
            if (direction == Direction.Up || direction == Direction.Down)
            {
                if (direction == Direction.Down) flip = SpriteEffects.FlipVertically;
                else flip = SpriteEffects.None;
                return new Rectangle(393, 146 + 17 * (int)color, WizzrobeConstants.WIDTHANDHEIGHT, WizzrobeConstants.WIDTHANDHEIGHT);
            }
            else
            {
                if (direction == Direction.Left) flip = SpriteEffects.FlipHorizontally;
                else flip = SpriteEffects.None;
                return new Rectangle(410, 146 + 17 * (int)color, WizzrobeConstants.WIDTHANDHEIGHT, WizzrobeConstants.WIDTHANDHEIGHT);
            }
        }

        public bool CheckForRemoval()
        {
            return frame > LASTFRAME ;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void Deflect(Vector2 deflectVector)
        {
            //Doesn't deflect
        }

        public void Hit()
        {
            //Doesn't hit
        }

        private void SetUpMovement()
        {
            if(direction == Direction.Up)
            {
                movement = new Vector2(0, -1);
                xLoc -= WizzrobeConstants.WIDTHANDHEIGHT;
            }
            if (direction == Direction.Down)
            {
                movement = new Vector2(0, 1);
                xLoc += WizzrobeConstants.WIDTHANDHEIGHT;
            }
            if (direction == Direction.Left)
            {
                movement = new Vector2(-1, 0);
                yLoc -= WizzrobeConstants.WIDTHANDHEIGHT;
            }
            if (direction == Direction.Right)
            {
                movement = new Vector2(1, 0);
                yLoc += WizzrobeConstants.WIDTHANDHEIGHT;
            }
        }
    }
}
