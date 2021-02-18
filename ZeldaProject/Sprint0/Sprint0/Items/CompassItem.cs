using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class CompassItem : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Texture2D sheet;


        public CompassItem(Rectangle startPos, Rectangle source, Texture2D spriteSheet)
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
    }
}