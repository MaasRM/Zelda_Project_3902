using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class AquamentusFireballTriad : IProjectile
    {
        private enum Angle
        {
            Above,
            Middle,
            Below
        }

        private Texture2D spritesheet;
        private double x1, x2, x3, y1, y2, y3;
        private int width, height, frame;
        private Angle angle;
        private const int xMoveDist = 5;
        private const int PIXELSCALER = 2;

        public AquamentusFireballTriad(int x, int y, Texture2D spritesheet, IPlayer link)
        {
            x1 = x;
            x2 = x;
            x3 = x;
            y1 = y;
            y2 = y;
            y3 = y;
            width = 8;
            height = 16;
            frame = -1;
            this.spritesheet = spritesheet;
            SetAngle(link);
        }

        public void Update()
        {
            frame++;

            x1 -= xMoveDist * PIXELSCALER;
            x2 -= xMoveDist * PIXELSCALER;
            x3 -= xMoveDist * PIXELSCALER;

            if (angle == Angle.Above)
            {
                y1 -= xMoveDist * Math.Tan(40 * Math.PI / 180) * PIXELSCALER;
                y2 -= xMoveDist * Math.Tan(22 * Math.PI / 180) * PIXELSCALER;
                y3 -= xMoveDist * Math.Tan(5 * Math.PI / 180) * PIXELSCALER;
            }
            else if (angle == Angle.Middle)
            {
                y1 -= xMoveDist * Math.Tan(20 * Math.PI / 180) * PIXELSCALER;
                y3 += xMoveDist * Math.Tan(20 * Math.PI / 180) * PIXELSCALER;
            }
            else
            {
                y1 += xMoveDist * Math.Tan(40 * Math.PI / 180) * PIXELSCALER;
                y2 += xMoveDist * Math.Tan(22 * Math.PI / 180) * PIXELSCALER;
                y3 += xMoveDist * Math.Tan(5 * Math.PI / 180) * PIXELSCALER;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(x1 >= 0 && x1 < 800 && y1 >=0 && y1 < 480)
            {
                spriteBatch.Draw(spritesheet, new Rectangle((int)x1, (int)y1, width * PIXELSCALER, height * PIXELSCALER), GetSource(), Color.White);
            }
            if(x2 >= 0 && x2 < 800 && y2 >= 0 && y2 < 480)
            {
                spriteBatch.Draw(spritesheet, new Rectangle((int)x2, (int)y2, width * PIXELSCALER, height * PIXELSCALER), GetSource(), Color.White);
            }
            if(x3 >= 0 && x3 < 800 && y3 >= 0 && y3 < 480)
            {
                spriteBatch.Draw(spritesheet, new Rectangle((int)x3, (int)y3, width * PIXELSCALER, height * PIXELSCALER), GetSource(), Color.White);
            }
        }

        public Rectangle GetSource()
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

            double xDiff = xLink - x1;
            double yDiff = yLink - y1;

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
