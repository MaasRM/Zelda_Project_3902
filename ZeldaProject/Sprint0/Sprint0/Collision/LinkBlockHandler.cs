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
            //the idea is that if the player is trying to go through a block to just set the 
            //position of Link to where the collision first occured so that it won't look like Link is going through the block

            OverlapInRelationToPlayer overlapSide = GetOverlapDirection(player, block);
            Rectangle playerRect = player.LinkPosition();

            if ((overlapSide == OverlapInRelationToPlayer.Up) && (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)))
            {
                //return down;
                player.getLinkStateMachine().disableUp();
                playerRect.Y = playerRect.Y - overlap.Height;
                player.SetPosition(playerRect);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Down) && (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)))
            {
                //return up;
                player.getLinkStateMachine().disableDown();
                playerRect.Y = playerRect.Y + overlap.Height;
                player.SetPosition(playerRect);
            }
            else if ((overlapSide == OverlapInRelationToPlayer.Left) && (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left)))
            {
                //return right;
                player.getLinkStateMachine().disableLeft();
                playerRect.X = playerRect.X + playerRect.Width + overlap.Width;
                player.SetPosition(playerRect);
            }
            else 
            {
                //return left;
                player.getLinkStateMachine().disableRight();
                playerRect.X = playerRect.X - overlap.Width;
                player.SetPosition(playerRect);
            }
        }

        private static OverlapInRelationToPlayer GetOverlapDirection(IPlayer player, IBlock block)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle blockPos = block.GetBlockLocation();
            OverlapInRelationToPlayer overlapX = OverlapInRelationToPlayer.Right;
            OverlapInRelationToPlayer overlapY = OverlapInRelationToPlayer.Down;

            int yOverDist = 0, xOverDist = 0;

            if (playerPos.Y < blockPos.Y + blockPos.Height && playerPos.Y >= blockPos.Y)
            {
                yOverDist = blockPos.Y + blockPos.Height - playerPos.Y;
                overlapY = OverlapInRelationToPlayer.Up;
            }else if (blockPos.Y < playerPos.Y + playerPos.Height && blockPos.Y >= playerPos.Y)
            {
                yOverDist = playerPos.Y + playerPos.Height - blockPos.Y;
                overlapY = OverlapInRelationToPlayer.Down;
            }

            if (playerPos.X < blockPos.X + blockPos.Width && playerPos.X >= blockPos.X)
            {
                xOverDist = blockPos.X + blockPos.Width - playerPos.X;
                overlapY = OverlapInRelationToPlayer.Right;
            }else if (blockPos.X < playerPos.X + playerPos.Width && blockPos.X >= playerPos.X)
            {
                xOverDist = playerPos.X + playerPos.Width - blockPos.X;
                overlapY = OverlapInRelationToPlayer.Left;
            }

            if (yOverDist > xOverDist)
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