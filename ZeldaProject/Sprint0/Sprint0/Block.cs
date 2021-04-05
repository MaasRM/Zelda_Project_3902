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
        private Rectangle startingPosition;
        private int blockIndex;

        public Block(int blockNum, Texture2D spriteSheet, int x, int y)
        {
            blockSpriteSheet = spriteSheet;
            blockIndex = blockNum;
            blockDestination = new Rectangle(x, y, BlockConstants.WIDTHANDHEIGHT * GameConstants.SCALE, BlockConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
            startingPosition = blockDestination;

            blockSource = new Rectangle(BlockConstants.XSources[blockIndex % 4], BlockConstants.YSources[blockIndex / 4 % 3], BlockConstants.WIDTHANDHEIGHT, BlockConstants.WIDTHANDHEIGHT);

            if (blockIndex == BlockConstants.MoveBlockIndex) blockSource = new Rectangle(BlockConstants.XSources[1], BlockConstants.YSources[0], BlockConstants.WIDTHANDHEIGHT, BlockConstants.WIDTHANDHEIGHT);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockSpriteSheet, blockDestination, blockSource, Color.White);
        }

        public Rectangle GetBlockLocation()
        {
            return blockDestination;
        }

        public int getIndex()
        {
            return blockIndex;
        }

        public void setPosition(Rectangle newRect)
        {
            blockDestination = newRect;
        }

        public Rectangle startPos()
        {
            return startingPosition;
        }
        public void setBlockIndex(int num)
        {
            blockIndex = num;
        }

        public bool notMovedX()
        {
            return startingPosition.X == blockDestination.X;
        }

        public bool notMovedY()
        {
            return startingPosition.Y == blockDestination.Y;
        }

        public void ResetBlock()
        {
            blockDestination = startingPosition;
        }
    }
}
