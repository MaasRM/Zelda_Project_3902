//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class TextSprite : ISprite
    {
        private Vector2 destination;
        private SpriteFont font;
        private string text;

        public TextSprite(Vector2 startPos, SpriteFont spriteFont, string message)
        {
            destination = startPos;
            font = spriteFont;
            text = message;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, text, destination, Color.Black);

            spriteBatch.End();
        }
    }
}
