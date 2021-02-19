using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class Fire : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private int frameIndex;
        private Texture2D sheet;
        private SpriteEffects flip;

        public Fire(Rectangle startPos, Rectangle source, Texture2D spriteSheet)
        {
            destination = startPos;
            spriteSource = source;
            frameIndex = 0;
            sheet = spriteSheet;
            flip = SpriteEffects.FlipHorizontally;

        }

        public void Update()
        {
            frameIndex++;

            if(frameIndex >= 40)
            {
                frameIndex = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if(frameIndex % 2  == 0)
            {
                spriteBatch.Draw(sheet, destination, spriteSource, Color.White);
            }
            else
            {
                spriteBatch.Draw(sheet, destination, spriteSource, Color.White, 0, new Vector2(0, 0), flip, 0f)
            }
            

        }
    }
}