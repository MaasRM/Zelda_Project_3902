﻿using System;
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
            //the idea is that if the player is trying to go through a block to just set the 
            //position of Link to where the collision first occured so that it won't look like Link is going through the block

            OverlapInRelationToPlayer overlapSide = GetOverlapDirection(player, block, overlap);
            Rectangle playerRect = player.LinkPosition();

            //overlapSide = OverlapInRelationToPlayer.Left;

            if ((overlapSide == OverlapInRelationToPlayer.Up) && (player.getLinkStateMachine().getDirection() == Direction.MoveUp))
            {
                //return down;
                player.getLinkStateMachine().disableUp();
                playerRect.Y = playerRect.Y + overlap.Height;
                player.getLinkStateMachine().SetPositions(playerRect);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Down) && (player.getLinkStateMachine().getDirection() == Direction.MoveDown))
            {
                //return up;  
                player.getLinkStateMachine().disableDown();
                playerRect.Y = playerRect.Y - overlap.Height;
                player.getLinkStateMachine().SetPositions(playerRect);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Left) && (player.getLinkStateMachine().getDirection() == Direction.MoveLeft))
            {
                //return right;
                player.getLinkStateMachine().disableLeft();
                playerRect.X = playerRect.X + overlap.Width;
                player.getLinkStateMachine().SetPositions(playerRect);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Right) && (player.getLinkStateMachine().getDirection() == Direction.MoveRight))
            {
                //return left;
                player.getLinkStateMachine().disableRight();
                playerRect.X = playerRect.X - overlap.Width;
                player.getLinkStateMachine().SetPositions(playerRect);
            }
        }

        private static OverlapInRelationToPlayer GetOverlapDirection(IPlayer player, IBlock block, Rectangle overlap)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle blockPos = block.GetBlockLocation();
            OverlapInRelationToPlayer overlapX = OverlapInRelationToPlayer.Right;
            OverlapInRelationToPlayer overlapY = OverlapInRelationToPlayer.Down;

            if (overlap.Y < playerPos.Y)
            {
                overlapY = OverlapInRelationToPlayer.Up;
            }
            else
            {
                overlapY = OverlapInRelationToPlayer.Down;
            }

            if (overlap.X < playerPos.X)
            {
                overlapX = OverlapInRelationToPlayer.Right;
            }
            else
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