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
        private enum OverlapInRelationToPlayer
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
            OverlapInRelationToPlayer overlapLink = GetOverlapDirectionLink(player, block, overlap);
            Rectangle blockRect = block.GetBlockLocation();
            Rectangle playerRect = player.LinkPosition();

            if (blockRect.Y <= block.startPos().Y + blockRect.Height - 3 && blockRect.Y >= block.startPos().Y - blockRect.Height + 5 && notMoved(block.startPos().X, blockRect.X))
            {
                if (overlapBlock == OverlapInRelationToBlock.Up)
                {
                    //move down;
                    block.setBlockIndex(10);
                    blockRect.Y = blockRect.Y + overlap.Height;
                    block.setPosition(blockRect);
                }
                else if (overlapBlock == OverlapInRelationToBlock.Down)
                {
                    //move up;  
                    block.setBlockIndex(10);
                    blockRect.Y = blockRect.Y - overlap.Height;
                    block.setPosition(blockRect);
                }
                else if (overlapLink == OverlapInRelationToPlayer.Left)
                {
                    //move right;
                    LinkBlockHandler.HandleCollision(player, block, overlap);
                }
                else if (overlapLink == OverlapInRelationToPlayer.Right)
                {
                    //move left;
                    LinkBlockHandler.HandleCollision(player, block, overlap);
                }
            }
            else if (blockRect.X >= block.startPos().X - blockRect.Width && blockRect.X <= block.startPos().X + blockRect.Width - 9 && notMoved(block.startPos().Y, blockRect.Y))
            {

                if (overlapLink == OverlapInRelationToPlayer.Up)
                {
                    //move down;
                    LinkBlockHandler.HandleCollision(player, block, overlap);
                }
                else if (overlapLink == OverlapInRelationToPlayer.Down)
                {
                    //move up;  
                    LinkBlockHandler.HandleCollision(player, block, overlap);
                }
                else if (overlapBlock == OverlapInRelationToBlock.Left)
                {
                    //move right;
                    block.setBlockIndex(10);
                    blockRect.X = blockRect.X + overlap.Width;
                    block.setPosition(blockRect);
                }
                else if (overlapBlock == OverlapInRelationToBlock.Right)
                {
                    //move left;
                    block.setBlockIndex(10);
                    blockRect.X = blockRect.X - overlap.Width;
                    block.setPosition(blockRect);
                }
            }
            else
            {
                block.setBlockIndex(1);
            }
        }

        private static OverlapInRelationToBlock GetOverlapDirectionBlock(IPlayer player, IBlock block, Rectangle overlap)
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
        private static OverlapInRelationToPlayer GetOverlapDirectionLink(IPlayer player, IBlock block, Rectangle overlap)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle blockPos = block.GetBlockLocation();
            OverlapInRelationToPlayer overlapX = OverlapInRelationToPlayer.Right;
            OverlapInRelationToPlayer overlapY = OverlapInRelationToPlayer.Up;

            if (overlap.Y == playerPos.Y)
            {
                overlapY = OverlapInRelationToPlayer.Up;
            }
            else if (overlap.Y == blockPos.Y)
            {
                overlapY = OverlapInRelationToPlayer.Down;
            }

            if (overlap.X == blockPos.X)
            {
                overlapX = OverlapInRelationToPlayer.Right;
            }
            else if (overlap.X == playerPos.X)
            {
                overlapX = OverlapInRelationToPlayer.Left;
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

        private static Boolean notMoved(int original, int newVal)
        {
            return original == newVal;
        }
    }
}
