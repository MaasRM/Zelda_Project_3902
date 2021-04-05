using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class AquamentusFireball : IProjectile, IEnemyProjectile
    {
        private enum Angle
        {
            Above,
            Middle,
            Below
        }

        public enum Position
        {
            Top,
            Center,
            Bottom
        }

        private Texture2D spritesheet;
        private double x, y;
        private int frame;
        private int gameMaxX, gameMaxY;
        private Angle angle;
        private Position pos;

        public AquamentusFireball(int x, int y, Position pos, Texture2D spritesheet, Sprint4 game)
        {
            this.x = x;
            this.y = y;
            frame = -1;
            this.spritesheet = spritesheet;
            this.pos = pos;
            gameMaxX = game.GraphicsDevice.Viewport.Width;
            gameMaxY = game.GraphicsDevice.Viewport.Height;
            SetAngle(game.GetPlayer());
        }

        public void Update()
        {
            frame++;
            x -= FireballConstants.xMoveDist * GameConstants.SCALE;

            if (angle == Angle.Above)
            {
                if (pos == Position.Top) y -= FireballConstants.xMoveDist * Math.Tan(FireballConstants.DEGREE36 / FireballConstants.RADTODEGREE) * GameConstants.SCALE;
                else if(pos == Position.Center) y -= FireballConstants.xMoveDist * Math.Tan(FireballConstants.DEGREE22 / FireballConstants.RADTODEGREE) * GameConstants.SCALE;
                else y -= FireballConstants.xMoveDist * Math.Tan(FireballConstants.DEGREE5 / FireballConstants.RADTODEGREE) * GameConstants.SCALE;
            }
            else if (angle == Angle.Middle)
            {
                if (pos == Position.Top) y -= FireballConstants.xMoveDist * Math.Tan(FireballConstants.DEGREE20 / FireballConstants.RADTODEGREE) * GameConstants.SCALE;
                else if (pos == Position.Bottom) y += FireballConstants.xMoveDist * Math.Tan(FireballConstants.DEGREE20 / FireballConstants.RADTODEGREE) * GameConstants.SCALE;
            }
            else
            {
                if (pos == Position.Top) y += FireballConstants.xMoveDist * Math.Tan(FireballConstants.DEGREE5 / FireballConstants.RADTODEGREE) * GameConstants.SCALE;
                else if (pos == Position.Center) y += FireballConstants.xMoveDist * Math.Tan(FireballConstants.DEGREE22 / FireballConstants.RADTODEGREE) * GameConstants.SCALE;
                else y += FireballConstants.xMoveDist * Math.Tan(FireballConstants.DEGREE36 / FireballConstants.RADTODEGREE) * GameConstants.SCALE;
            }
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

        private void SetAngle(IPlayer link)
        {
            Rectangle linkPos = link.LinkPosition();
            int xLink = linkPos.X + linkPos.Width / 2;
            int yLink = linkPos.Y + linkPos.Height / 2;
            double xDiff = xLink - x;
            double yDiff = yLink - y;
            double linkAngle;

            if(xDiff != 0) {
                linkAngle = Math.Atan(yDiff / xDiff) * FireballConstants.RADTODEGREE;

                if (linkAngle > FireballConstants.DEGREE30) angle = Angle.Above;
                else if (linkAngle < -1 * FireballConstants.DEGREE30) angle = Angle.Below;
                else angle = Angle.Middle;
            }
            else angle = Angle.Middle;
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
