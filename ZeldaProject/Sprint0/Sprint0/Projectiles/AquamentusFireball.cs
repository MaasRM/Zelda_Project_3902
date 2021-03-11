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
        private int width, height, frame;
        private Angle angle;
        private Position pos;
        private const int xMoveDist = 5;
        private const int PIXELSCALER = 2;

        public AquamentusFireball(int x, int y, Position pos, Texture2D spritesheet, IPlayer link)
        {
            this.x = x;
            this.y = y;
            width = 8;
            height = 16;
            frame = -1;
            this.spritesheet = spritesheet;
            this.pos = pos;
            SetAngle(link);
        }

        public void Update()
        {
            frame++;

            x -= xMoveDist * PIXELSCALER;

            if (angle == Angle.Above)
            {
                if (pos == Position.Top)
                {
                    y -= xMoveDist * Math.Tan(36 * Math.PI / 180) * PIXELSCALER;
                }
                else if(pos == Position.Center)
                {
                    y -= xMoveDist * Math.Tan(22 * Math.PI / 180) * PIXELSCALER;
                }
                else
                {
                    y -= xMoveDist * Math.Tan(5 * Math.PI / 180) * PIXELSCALER;
                }
            }
            else if (angle == Angle.Middle)
            {
                if (pos == Position.Top)
                {
                    y -= xMoveDist * Math.Tan(20 * Math.PI / 180) * PIXELSCALER;
                }
                else
                {
                    y += xMoveDist * Math.Tan(20 * Math.PI / 180) * PIXELSCALER;
                }
            }
            else
            {
                if (pos == Position.Top)
                {
                    y += xMoveDist * Math.Tan(36 * Math.PI / 180) * PIXELSCALER;
                }
                else if (pos == Position.Center)
                {
                    y += xMoveDist * Math.Tan(22 * Math.PI / 180) * PIXELSCALER;
                }
                else
                {
                    y += xMoveDist * Math.Tan(5 * Math.PI / 180) * PIXELSCALER;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, GetProjectileLocation(), GetSource(), Color.White);
        }

        public Rectangle GetProjectileLocation()
        {
            return new Rectangle((int)x, (int)y, width * PIXELSCALER, height * PIXELSCALER);
        }

        private Rectangle GetSource()
        {
            if(frame % 4 == 0)
            {
                return new Rectangle(101, 11, width, height);
            }
            else if (frame % 4 == 1)
            {
                return new Rectangle(110, 11, width, height);
            }
            else if (frame % 4 == 2)
            {
                return new Rectangle(119, 11, width, height);
            }
            else
            {
                return new Rectangle(128, 11, width, height);
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

            if(xDiff != 0)
            {
                linkAngle = Math.Atan(yDiff / xDiff) * (180 / Math.PI);

                if (linkAngle > 30)
                {
                    angle = Angle.Above;
                }
                else if (linkAngle < -30)
                {
                    angle = Angle.Below;
                }
                else
                {
                    angle = Angle.Middle;
                }
            }
            else
            {
                angle = Angle.Middle;
            }
        }
    }
}
