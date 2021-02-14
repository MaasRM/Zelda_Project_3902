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

        public Block(Rectangle startPos, Rectangle source, Texture2D spriteSheet)
        {
            blockSpriteSheet = spriteSheet;
            blockSource = source;
            destination = startPos;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockSpriteSheet, destination, source, Color.White);
        }

    }
}
