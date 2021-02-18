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

        public AquamentusFireballTriad(int x, int y, Texture2D spritesheet, Link link)
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
            angle = setAngle(link);
        }

        public void Update()
        {
            frame++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, new Rectangle((int)x1, (int)y1, width, height), GetSource(), Color.White);
            spriteBatch.Draw(spritesheet, new Rectangle((int)x2, (int)y2, width, height), GetSource(), Color.White);
            spriteBatch.Draw(spritesheet, new Rectangle((int)x3, (int)y3, width, height), GetSource(), Color.White);
        }

        public Rectangle GetSource()
        {
            return new Rectangle(101 + frame % 4 * (width + 1), 11, width, height);
        }

        private Angle setAngle(Link link)
        {
            return Angle.Above;
        }
    }
}
