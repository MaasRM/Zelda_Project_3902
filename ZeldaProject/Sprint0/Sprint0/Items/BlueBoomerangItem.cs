using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Sprint0
{
    public class BlueBoomerangItem : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private const int width = 7;
        private const int height = 15;
        private Texture2D sheet;


        public BlueBoomerangItem(Rectangle startPos, Rectangle source, Texture2D spriteSheet)
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
