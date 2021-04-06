using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class TriforceShardItem : IItem
    {
        private Rectangle destination;
        private Rectangle frame1;
        private Rectangle frame2;
        private Rectangle spriteSource;
        private int frameIndex;
        private Texture2D sheet;


        public TriforceShardItem(Rectangle startPos, Rectangle source, Texture2D spriteSheet)
        {
            destination = startPos;
            spriteSource = source;
            frameIndex = 0;
            sheet = spriteSheet;
            frame1 = source;
            frame2 = new Rectangle(source.X, source.Y + 16, source.Width, source.Height);
        }

        public void Update()
        {
            frameIndex++;
            if (frameIndex % 4 == 0)
            {
                spriteSource = frame1;
            }
            else if (frameIndex % 2 == 0)
            {
                spriteSource = frame2;
            }

            if (frameIndex > 40)
            {
                frameIndex = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(sheet, destination, spriteSource, Color.White);

        }

        public Rectangle GetLocationRectangle()
        {
            return destination;
        }

        public Rectangle GetSourceRectangle()
        {
            return spriteSource;
        }

        public Texture2D GetSpriteSheet()
        {
            return sheet;
        }
    }
}