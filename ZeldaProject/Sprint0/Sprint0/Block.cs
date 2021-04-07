using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Block : IBlock
    {
        private Texture2D DungeonBlockSheet;
        private Texture2D OverworldBlockSheet;
        private Rectangle blockSource;
        private Rectangle blockDestination;
        private Rectangle startingPosition;
        private int blockIndex;

        public Block(int blockNum, Texture2D dungeon, Texture2D overworld, int x, int y)
        {
            DungeonBlockSheet = dungeon;
            OverworldBlockSheet = overworld;
            blockIndex = blockNum;
            blockDestination = new Rectangle(x, y, BlockConstants.WIDTHANDHEIGHT * GameConstants.SCALE, BlockConstants.WIDTHANDHEIGHT * GameConstants.SCALE);
            startingPosition = blockDestination;

            if (blockIndex < 11)
            {
                blockSource = new Rectangle(BlockConstants.DXSources[blockIndex % 4], BlockConstants.DYSources[blockIndex / 4 % 3], BlockConstants.WIDTHANDHEIGHT, BlockConstants.WIDTHANDHEIGHT);
            }
            else
            {
                blockSource = new Rectangle(BlockConstants.OXSources[blockIndex % 4], BlockConstants.OYSources[blockIndex / 4 % 3], BlockConstants.WIDTHANDHEIGHT, BlockConstants.WIDTHANDHEIGHT);
            }

            if (blockIndex == BlockConstants.MoveBlockIndex) blockSource = new Rectangle(BlockConstants.DXSources[1], BlockConstants.DYSources[0], BlockConstants.WIDTHANDHEIGHT, BlockConstants.WIDTHANDHEIGHT);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (blockIndex < 11)
            {
                spriteBatch.Draw(DungeonBlockSheet, blockDestination, blockSource, Color.White);
            }
            else
            {
                spriteBatch.Draw(OverworldBlockSheet, blockDestination, blockSource, Color.White);
            }
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
