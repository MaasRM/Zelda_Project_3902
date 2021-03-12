﻿using Microsoft.Xna.Framework;
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
        private int scale = 4;

        public Block(int blockIndex, Texture2D spriteSheet, int x, int y)
        {
            blockSpriteSheet = spriteSheet;
            blockDestination = new Rectangle(x, y, 16 * scale, 16 * scale);
            if (blockIndex == 0)
            {
                blockSource = new Rectangle(984, 11, 16, 16);
            }
            else if (blockIndex == 1)
            {
                blockSource = new Rectangle(1001, 11, 16, 16);
            }
            else if (blockIndex == 2)
            {
                blockSource = new Rectangle(1018, 11, 16, 16);
            }
            else if (blockIndex == 3)
            {
                blockSource = new Rectangle(1035, 11, 16, 16);
            }
            else if (blockIndex == 4)
            {
                blockSource = new Rectangle(984, 28, 16, 16);
            }
            else if (blockIndex == 5)
            {
                blockSource = new Rectangle(1001, 28, 16, 16);
            }
            else if (blockIndex == 6)
            {
                blockSource = new Rectangle(1018, 28, 16, 16);
            }
            else if (blockIndex == 7)
            {
                blockSource = new Rectangle(1035, 28, 16, 16);
            }
            else if (blockIndex == 8)
            {
                blockSource = new Rectangle(984, 45, 16, 16);
            }
            else if (blockIndex == 9)
            {
                blockSource = new Rectangle(1001, 45, 16, 16);
            }
        }

        public void Update()
        {
            //moving block mechanics??
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockSpriteSheet, blockDestination, blockSource, Color.White);
        }

    }
}
