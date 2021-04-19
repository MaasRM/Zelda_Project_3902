using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

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

        public static void HandleCollision(IPlayer player, IBlock block, Rectangle overlap, RoomManager roomManager, List<SoundEffect> Collision_soundEffects, List<bool> secrets)
        {
            OverlapInRelationToPlayer overlapSide = GetOverlapDirection(player, block, overlap);
            Rectangle blockRect = block.GetBlockLocation();
            bool blockMoved = false;

            if (block.getIndex() != 5 && block.getIndex() != 9 && block.getIndex() != 11 && block.getIndex() != 18 && block.getIndex() != 19 && block.getIndex() != 27 && block.getIndex() != 28 && block.getIndex() != 39 && player.getLinkStateMachine().getAnimation() != Animation.Attack) {
                if(block.getIndex() == 10 && !blockMoved) {
                    blockMoved = MobileBlcokCollision(block, overlap, blockRect, overlapSide);
                }

                if (block.getIndex() == 0) {
                    if (roomManager.Room().RoomNum() == 0 && !secrets[0]) SecretOneHandler(Collision_soundEffects, secrets);
                    else if (roomManager.Room().RoomNum() == 6 && !secrets[1]) SecretTwoHandler(roomManager, Collision_soundEffects, secrets);
                    else if (roomManager.Room().RoomNum() == 28 && !secrets[2]) SecretThreeHandler(Collision_soundEffects, secrets);
                    else if (roomManager.Room().RoomNum() == 41 && !secrets[3]) SecretFourHandler(Collision_soundEffects, secrets);
                }
                else if (block.getIndex() == 7) StairCaseCollision(roomManager, Collision_soundEffects);
                else if (block.getIndex() == 41) EnterDungeonCollision(player, roomManager, Collision_soundEffects);
                else if (block.getIndex() != 10 || blockMoved) NonMobileBlockCollision(player, overlap, blockRect, overlapSide); 
            } 
        }

        private static OverlapInRelationToPlayer GetOverlapDirection(IPlayer player, IBlock block, Rectangle overlap)
        {
            Rectangle playerPos = player.LinkPosition();
            Rectangle blockPos = block.GetBlockLocation();
            OverlapInRelationToPlayer overlapX = OverlapInRelationToPlayer.Right;
            OverlapInRelationToPlayer overlapY = OverlapInRelationToPlayer.Up;

            if (overlap.Y == playerPos.Y) overlapY = OverlapInRelationToPlayer.Up;
            else if (overlap.Y == blockPos.Y) overlapY = OverlapInRelationToPlayer.Down;

            if (overlap.X == blockPos.X) overlapX = OverlapInRelationToPlayer.Right;
            else if (overlap.X == playerPos.X) overlapX = OverlapInRelationToPlayer.Left;

            if (overlap.Height < overlap.Width) return overlapY;
            else return overlapX;
        }

        private static void NonMobileBlockCollision(IPlayer player, Rectangle overlap, Rectangle blockRect, OverlapInRelationToPlayer overlapSide)
        {
            if (player.getLinkStateMachine().damageVector.Y < 0 || (overlapSide == OverlapInRelationToPlayer.Up) && (player.getLinkStateMachine().getDirection() == Direction.Up))
            {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), player.getLinkStateMachine().getYLoc() + overlap.Height, player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            else if (player.getLinkStateMachine().damageVector.Y > 0 || (overlapSide == OverlapInRelationToPlayer.Down) && (player.getLinkStateMachine().getDirection() == Direction.Down))
            {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), player.getLinkStateMachine().getYLoc() - overlap.Height, player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            else if (player.getLinkStateMachine().damageVector.X < 0 || (overlapSide == OverlapInRelationToPlayer.Left) && (player.getLinkStateMachine().getDirection() == Direction.Left))
            {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc() + overlap.Width, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            else if (player.getLinkStateMachine().damageVector.X > 0 || (overlapSide == OverlapInRelationToPlayer.Right) && (player.getLinkStateMachine().getDirection() == Direction.Right))
            {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc() - overlap.Width, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }

        private static bool MobileBlcokCollision(IBlock block, Rectangle overlap, Rectangle blockRect, OverlapInRelationToPlayer overlapSide)
        {
            bool blockMoved = false;
            if (blockRect.Y <= block.startPos().Y + blockRect.Height - 3 && blockRect.Y >= block.startPos().Y - blockRect.Height + 5) {
                if (overlapSide == OverlapInRelationToPlayer.Down && block.notMovedX()) {
                    blockRect.Y = blockRect.Y + overlap.Height;
                    block.setPosition(blockRect);
                }
                else if (overlapSide == OverlapInRelationToPlayer.Up && block.notMovedX()) {
                    blockRect.Y = blockRect.Y - overlap.Height;
                    block.setPosition(blockRect);
                }
                else blockMoved = true;
            }

            if (blockRect.X >= block.startPos().X - blockRect.Width && blockRect.X <= block.startPos().X + blockRect.Width - 9) {
                if (overlapSide == OverlapInRelationToPlayer.Right && block.notMovedY()) {
                    blockRect.X = blockRect.X + overlap.Width;
                    block.setPosition(blockRect);
                }
                else if (overlapSide == OverlapInRelationToPlayer.Left && block.notMovedY()) {
                    blockRect.X = blockRect.X - overlap.Width;
                    block.setPosition(blockRect);
                }
                else blockMoved = true;
            }

            return blockMoved;
        }

        private static void SecretOneHandler(List<SoundEffect> Collision_soundEffects, List<bool> secrets)
        {
            Collision_soundEffects[9].Play();
            secrets[0] = true;
        }

        private static void SecretTwoHandler(RoomManager roomManager, List<SoundEffect> Collision_soundEffects, List<bool> secrets)
        {
            Collision_soundEffects[9].Play();
            secrets[1] = true;
            roomManager.UnlockDoor(Direction.Left);
        }

        private static void SecretThreeHandler(List<SoundEffect> Collision_soundEffects, List<bool> secrets)
        {
            Collision_soundEffects[9].Play();
            secrets[2] = true;
        }

        private static void SecretFourHandler(List<SoundEffect> Collision_soundEffects, List<bool> secrets)
        {
            Collision_soundEffects[9].Play();
            secrets[3] = true;
        }

        private static void StairCaseCollision(RoomManager roomManager, List<SoundEffect> Collision_soundEffects)
        {
            Collision_soundEffects[10].Play();
            if(roomManager.getRoomIndex() < GameConstants.TOPBOTTOMSPLIT)
            {
                roomManager.ChangeRoom(GameConstants.VERTICALROOMTOP);
            }
            else
            {
                roomManager.ChangeRoom(GameConstants.VERTICALROOMBOTTOM);
            }
        }

        private static void EnterDungeonCollision(IPlayer link, RoomManager roomManager, List<SoundEffect> Collision_soundEffects)
        {
            Collision_soundEffects[10].Play();
            roomManager.ChangeRoom(GameConstants.STARTROOM);
            link.SetPosition(new Rectangle(LinkConstants.XINIT * GameConstants.SCALE, LinkConstants.YINIT * GameConstants.SCALE, LinkConstants.LINKSIZENORMAL, LinkConstants.LINKSIZENORMAL));
        }
    }
}