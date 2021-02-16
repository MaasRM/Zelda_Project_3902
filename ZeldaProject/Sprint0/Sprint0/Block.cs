using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Block : IBlock
    {
        private Texture2D blockSpriteSheet;
        private Rectangle blockSource;
        private Rectangle destination;

        public Block(Texture2D spriteSheet)
        {
            blockSpriteSheet = spriteSheet;
            blockSource = new Rectangle(0, 0, 0, 0); //Origional Block position
            destination = new Rectangle(0, 0, 0, 0); // Need to change
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockSpriteSheet, destination, blockSource, Color.White);
        }

    }
}
