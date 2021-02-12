using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class block : IBlock
    {
        private Texture2D blockSpriteSheet;
        private Rectangle source;
        private Rectangle destination;

        public Block(Texture2D spriteSheet)
        {
            blockSpriteSheet = spriteSheet;
            //source of first block
            //destination of first block
        }

        public void Update()
        {
            source = stateMachine.getSource();
            destination = stateMachine.getDestination();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockSpriteSheet, destination, source, Color.White);
        }

    }
}
