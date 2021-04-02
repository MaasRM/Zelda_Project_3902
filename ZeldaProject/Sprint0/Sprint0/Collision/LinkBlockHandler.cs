using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class LinkBlockHandler
    {
        private enum OverlapInRelationToPlayer
        {
            Up,
            Right,
            Down,
            Left
        };

        public LinkBlockHandler()
        {
        }

        public static void HandleCollision(IPlayer player, IBlock block, Rectangle overlap)
        {
            OverlapInRelationToPlayer overlapSide = GetOverlapDirection(player, block, overlap);
            Rectangle blockRect = block.GetBlockLocation();
            bool blockMoved = false;

            if (block.getIndex() != 5 && block.getIndex() != 0)
            {
                if(block.getIndex() == 10)
                {
                    blockMoved = MobileBlcokCollision(block, overlap, blockRect, overlapSide);
                }
                if(block.getIndex() != 10 || blockMoved)
                {
                    NonMobileBlockCollision(player, overlap, overlapSide);
                }
            }

            
        }

        private static OverlapInRelationToPlayer GetOverlapDirection(IPlayer player, IBlock block, Rectangle overlap)
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

        private static void NonMobileBlockCollision(IPlayer player, Rectangle overlap, OverlapInRelationToPlayer overlapSide)
        {
            if ((overlapSide == OverlapInRelationToPlayer.Up) && (player.getLinkStateMachine().getDirection() == Direction.MoveUp))
            {
                //return down;
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), player.getLinkStateMachine().getYLoc() + overlap.Height, player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Down) && (player.getLinkStateMachine().getDirection() == Direction.MoveDown))
            {
                //return up;  
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), player.getLinkStateMachine().getYLoc() - overlap.Height, player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Left) && (player.getLinkStateMachine().getDirection() == Direction.MoveLeft))
            {
                //return right;
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc() + overlap.Width, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Right) && (player.getLinkStateMachine().getDirection() == Direction.MoveRight))
            {
                //return left;
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc() - overlap.Width, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }

        private static bool MobileBlcokCollision(IBlock block, Rectangle overlap, Rectangle blockRect, OverlapInRelationToPlayer overlapSide)
        {
            bool blockMoved = false;
            if (blockRect.Y <= block.startPos().Y + blockRect.Height - 3 && blockRect.Y >= block.startPos().Y - blockRect.Height + 5) {
                if (overlapSide == OverlapInRelationToPlayer.Down && block.notMovedX()) {
                    //move down;
                    blockRect.Y = blockRect.Y + overlap.Height;
                    block.setPosition(blockRect);
                }
                else if (overlapSide == OverlapInRelationToPlayer.Up && block.notMovedX()) {
                    //move up;  
                    blockRect.Y = blockRect.Y - overlap.Height;
                    block.setPosition(blockRect);
                }
                else {
                    blockMoved = true;
                }
            }

            if (blockRect.X >= block.startPos().X - blockRect.Width && blockRect.X <= block.startPos().X + blockRect.Width - 9) {
                if (overlapSide == OverlapInRelationToPlayer.Right && block.notMovedY()) {
                    //move right;
                    blockRect.X = blockRect.X + overlap.Width;
                    block.setPosition(blockRect);
                }
                else if (overlapSide == OverlapInRelationToPlayer.Left && block.notMovedY()) {
                    //move left;
                    blockRect.X = blockRect.X - overlap.Width;
                    block.setPosition(blockRect);
                }
                else {
                    blockMoved = true;
                }
            }

            return blockMoved;
        }
    }
}