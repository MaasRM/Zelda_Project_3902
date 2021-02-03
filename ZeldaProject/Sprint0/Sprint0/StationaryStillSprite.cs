//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class StationaryStillSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Texture2D sheet;


        public StationaryStillSprite(Rectangle startPos, Rectangle source, Texture2D spriteSheet)
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
            spriteBatch.Begin();

            spriteBatch.Draw(sheet, destination, spriteSource, Color.White);

            spriteBatch.End();
        }
    }
}
