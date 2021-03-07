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
        private Rectangle blockDestination;
        private int scale = 3;
        public int blockIndex = 0;

        public Block(Rectangle destination, Rectangle source, Texture2D spriteSheet)
        {
            blockSpriteSheet = spriteSheet;
            blockSource = source; 
            blockDestination = destination;

        }

        public void incrementIndex()
        {
            blockIndex++;
        }

        public void decrementIndex()
        {
            blockIndex--;
        }

        public void Update()
        {
            if (blockIndex < 0 || blockIndex == 10)
            {
                if(blockIndex < 0)
                {
                    blockIndex += 10;
                }
                else if(blockIndex == 10)
                {
                    blockIndex -= 10;
                }
            }

            if (blockIndex == 0)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(984, 11, 16, 16);
            }
            else if (blockIndex == 1)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(1001, 11, 16, 16);
            }
            else if (blockIndex == 2)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(1018, 11, 16, 16);
            }
            else if (blockIndex == 3)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(1035, 11, 16, 16);
            }
            else if (blockIndex == 4)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(984, 28, 16, 16);
            }
            else if (blockIndex == 5)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(1001, 28, 16, 16);
            }
            else if (blockIndex == 6)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(1018, 28, 16, 16);
            }
            else if (blockIndex == 7)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(1035, 28, 16, 16);
            }
            else if (blockIndex == 8)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(984, 45, 16, 16);
            }
            else if (blockIndex == 9)
            {
                blockDestination = new Rectangle(200, 200, 16 * scale, 16 * scale);
                blockSource = new Rectangle(1001, 45, 16, 16);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockSpriteSheet, blockDestination, blockSource, Color.White);
        }

    }
}
