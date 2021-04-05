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

        private const int WIDTH = 8;
        private const int HEIGHT = 16;
        private const int xMoveDist = 5;
        private const int PIXELSCALER = 4;
        private const int DAMAGE = 1;
        private const double RADTODEGREE = 180 / Math.PI;
        private const double DEGREE36 = 36;
        private const double DEGREE30 = 30;
        private const double DEGREE22 = 22;
        private const double DEGREE20 = 20;
        private const double DEGREE5 = 5;

        public AquamentusFireball(int x, int y, Position pos, Texture2D spritesheet, Sprint3 game)
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
            x -= xMoveDist * PIXELSCALER;

            if (angle == Angle.Above)
            {
                if (pos == Position.Top) y -= xMoveDist * Math.Tan(DEGREE36 / RADTODEGREE) * PIXELSCALER;
                else if(pos == Position.Center) y -= xMoveDist * Math.Tan(DEGREE22 / RADTODEGREE) * PIXELSCALER;
                else y -= xMoveDist * Math.Tan(DEGREE5 / RADTODEGREE) * PIXELSCALER;
            }
            else if (angle == Angle.Middle)
            {
                if (pos == Position.Top) y -= xMoveDist * Math.Tan(DEGREE20 / RADTODEGREE) * PIXELSCALER;
                else if (pos == Position.Bottom) y += xMoveDist * Math.Tan(DEGREE20 / RADTODEGREE) * PIXELSCALER;
            }
            else
            {
                if (pos == Position.Top) y += xMoveDist * Math.Tan(DEGREE5 / RADTODEGREE) * PIXELSCALER;
                else if (pos == Position.Center) y += xMoveDist * Math.Tan(DEGREE22 / RADTODEGREE) * PIXELSCALER;
                else y += xMoveDist * Math.Tan(DEGREE36 / RADTODEGREE) * PIXELSCALER;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, GetProjectileLocation(), GetSource(), Color.White);
        }

        public Rectangle GetProjectileLocation()
        {
            return new Rectangle((int)x, (int)y, WIDTH * PIXELSCALER, HEIGHT * PIXELSCALER);
        }

        private Rectangle GetSource()
        {
            if (frame % 4 == 0)
            {
                return new Rectangle(101, 11, WIDTH, HEIGHT);
            }
            else if (frame % 4 == 1)
            {
                return new Rectangle(110, 11, WIDTH, HEIGHT);
            }
            else if (frame % 4 == 2)
            {
                return new Rectangle(119, 11, WIDTH, HEIGHT);
            }
            else
            {
                return new Rectangle(128, 11, WIDTH, HEIGHT);
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
                linkAngle = Math.Atan(yDiff / xDiff) * RADTODEGREE;

                if (linkAngle > DEGREE30) angle = Angle.Above;
                else if (linkAngle < -1 * DEGREE30) angle = Angle.Below;
                else angle = Angle.Middle;
            }
            else angle = Angle.Middle;
        }

        public bool CheckForRemoval()
        {
            double xCenter = x + WIDTH * PIXELSCALER / 2;
            double yCenter = y + HEIGHT * PIXELSCALER / 2;
            return (xCenter < 0 || xCenter >= gameMaxX) && (yCenter < 0 || yCenter >= gameMaxY);
        }

        public int GetDamage()
        {
            return DAMAGE;
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
