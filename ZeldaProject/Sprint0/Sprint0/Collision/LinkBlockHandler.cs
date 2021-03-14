using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            Rectangle playerRect = player.LinkPosition();

            if ((overlapSide == OverlapInRelationToPlayer.Up) && (player.getLinkStateMachine().getDirection() == Direction.MoveUp))
            {
                //return down;
                //player.getLinkStateMachine().disableUp();
                playerRect.Y = playerRect.Y + overlap.Height;
                player.getLinkStateMachine().SetPositions(playerRect);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Down) && (player.getLinkStateMachine().getDirection() == Direction.MoveDown))
            {
                //return up;  
                //player.getLinkStateMachine().disableDown();
                playerRect.Y = playerRect.Y - overlap.Height;
                player.getLinkStateMachine().SetPositions(playerRect);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Left) && (player.getLinkStateMachine().getDirection() == Direction.MoveLeft))
            {
                //return right;
                //player.getLinkStateMachine().disableLeft();
                playerRect.X = playerRect.X + overlap.Width;
                player.getLinkStateMachine().SetPositions(playerRect);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Right) && (player.getLinkStateMachine().getDirection() == Direction.MoveRight))
            {
                //return left;
                //player.getLinkStateMachine().disableRight();
                playerRect.X = playerRect.X - overlap.Width;
                player.getLinkStateMachine().SetPositions(playerRect);
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
    }
}