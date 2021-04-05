using Microsoft.Xna.Framework;
using System;

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
            OverlapInRelationToBlock overlapBlock = GetOverlapDirectionBlock(player, block, overlap);
            Rectangle blockRect = block.GetBlockLocation();

            if (blockRect.Y <= block.startPos().Y + blockRect.Height - 3 && blockRect.Y >= block.startPos().Y - blockRect.Height + 5) {
                if (overlapBlock == OverlapInRelationToBlock.Up && notMoved(block.startPos().X, blockRect.X)) {
                    blockRect.Y = blockRect.Y + overlap.Height;
                    block.setPosition(blockRect);
                }
                else if (overlapBlock == OverlapInRelationToBlock.Down && notMoved(block.startPos().X, blockRect.X)){ 
                    blockRect.Y = blockRect.Y - overlap.Height;
                    block.setPosition(blockRect);
                }
                else LinkBlockHandler.HandleCollision(player, block, overlap);
            }
            
            if (blockRect.X >= block.startPos().X - blockRect.Width && blockRect.X <= block.startPos().X + blockRect.Width - 9) {
                if (overlapBlock == OverlapInRelationToBlock.Left && notMoved(block.startPos().Y, blockRect.Y)) {
                    blockRect.X = blockRect.X + overlap.Width;
                    block.setPosition(blockRect);
                }
                else if (overlapBlock == OverlapInRelationToBlock.Right && notMoved(block.startPos().Y, blockRect.Y)) {
                    blockRect.X = blockRect.X - overlap.Width;
                    block.setPosition(blockRect);
                }
                else LinkBlockHandler.HandleCollision(player, block, overlap);
            }
        }

        private static OverlapInRelationToBlock GetOverlapDirectionBlock(IPlayer player, IBlock block, Rectangle overlap)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle blockPos = block.GetBlockLocation();
            OverlapInRelationToBlock overlapX = OverlapInRelationToBlock.Right;
            OverlapInRelationToBlock overlapY = OverlapInRelationToBlock.Up;

            if (overlap.Y == blockPos.Y) overlapY = OverlapInRelationToBlock.Up;
            else if (overlap.Y == playerPos.Y) overlapY = OverlapInRelationToBlock.Down;

            if (overlap.X == playerPos.X) overlapX = OverlapInRelationToBlock.Right;
            else if (overlap.X == blockPos.X) overlapX = OverlapInRelationToBlock.Left;

            if (overlap.Height < overlap.Width) return overlapY;
            else return overlapX;
        }

        private static Boolean notMoved(int original, int newVal)
        {
            return original == newVal;
        }
    }
}
