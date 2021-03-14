using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class LinkMoveBlockHandler
    {
        private enum OverlapInRelationToBlock
        {
            Up,
            Right,
            Down,
            Left
        };

        public LinkMoveBlockHandler()
        {
        }

        public static void HandleCollision(IPlayer player, IBlock block, Rectangle overlap)
        {
            OverlapInRelationToBlock overlapSide = GetOverlapDirection(player, block, overlap);
            Rectangle blockRect = block.GetBlockLocation();

            //block moved up
            //blockRect.Y >= block.startPos().Y - blockRect.Height

            //block moved down
            //blockRect.Y <= block.startPos().Y + blockRect.Height - 3 (magic number because it doesn't move the right way)

            //block moved right
            //blockRect.X <= block.startPos().X + blockRect.Width - 9

            //block moved left
            //blockRect.X >= block.startPos().X - blockRect.Width

            if (blockRect.X >= block.startPos().X - blockRect.Width && blockRect.X <= block.startPos().X + blockRect.Width - 9
                && blockRect.Y <= block.startPos().Y + blockRect.Height - 3 && blockRect.Y >= block.startPos().Y - blockRect.Height + 5)
            {
                if (overlapSide == OverlapInRelationToBlock.Up)
                {
                    //return down;
                    blockRect.Y = blockRect.Y + overlap.Height;
                    block.setPosition(blockRect);
                }
                else if (overlapSide == OverlapInRelationToBlock.Down)
                {
                    //return up;  
                    blockRect.Y = blockRect.Y - overlap.Height;
                    block.setPosition(blockRect);
                }
                else if (overlapSide == OverlapInRelationToBlock.Left)
                {
                    //return right;
                    blockRect.X = blockRect.X + overlap.Width;
                    block.setPosition(blockRect);
                }
                else if (overlapSide == OverlapInRelationToBlock.Right)
                {
                    //return left;
                    blockRect.X = blockRect.X - overlap.Width;
                    block.setPosition(blockRect);
                }
            }
            else
            {
                block.setBlockIndex(1);
            }
        }

        private static OverlapInRelationToBlock GetOverlapDirection(IPlayer player, IBlock block, Rectangle overlap)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle blockPos = block.GetBlockLocation();
            OverlapInRelationToBlock overlapX = OverlapInRelationToBlock.Right;
            OverlapInRelationToBlock overlapY = OverlapInRelationToBlock.Up;

            if (overlap.Y == blockPos.Y)
            {
                overlapY = OverlapInRelationToBlock.Up;
            }
            else if (overlap.Y == playerPos.Y)
            {
                overlapY = OverlapInRelationToBlock.Down;
            }

            if (overlap.X == playerPos.X)
            {
                overlapX = OverlapInRelationToBlock.Right;
            }
            else if (overlap.X == blockPos.X)
            {
                overlapX = OverlapInRelationToBlock.Left;
            }

            if (overlap.Height < overlap.Width)
            {
                return overlapY;
            }
            else
            {
                return overlapX;
            }
        }
    }
}
