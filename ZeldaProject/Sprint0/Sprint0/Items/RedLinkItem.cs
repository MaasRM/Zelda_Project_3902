using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class RedLinkItem : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Texture2D sheet;


        public RedLinkItem(Rectangle startPos, Rectangle source, Texture2D spriteSheet)
        {
            destination = startPos;
            spriteSource = source;
            sheet = spriteSheet;
        }

        public void Update()
        {

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
