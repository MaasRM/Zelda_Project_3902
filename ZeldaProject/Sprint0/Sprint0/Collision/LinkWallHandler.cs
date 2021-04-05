using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class LinkWallHandler
    {
        static IPlayer player;
        static RoomManager room;
        static int maxX;
        static int maxY;

        public LinkWallHandler(IPlayer link, RoomManager currentRoom, int x, int y)
        {
            player = link;
            room = currentRoom;
            maxX = x;
            maxY = y;
        }

        public static void HandleLeftWall()
        {
            bool isSwapped;
            if (player.getLinkStateMachine().getYLoc() > (288 + (64 * 4)) && player.getLinkStateMachine().getYLoc() + player.LinkPosition().Height < (416 + (64 * 4))) {
                isSwapped = room.SwapRoom(Direction.Left);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0) {
                    if (room.UnlockDoor(Direction.Left)) {
                        isSwapped = room.SwapRoom(Direction.Left);
                        room.UnlockDoor(Direction.Right);
                        player.GetLinkInventory().removeKey();
                    }
                }
                if (isSwapped) {
                    Rectangle newPosition = new Rectangle(maxX - 175, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else {
                    Rectangle newPosition = new Rectangle(120, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else {
                Rectangle newPosition = new Rectangle(120, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }

        public static void HandleTopWall()
        {
            bool isSwapped;
            if (player.getLinkStateMachine().getXLoc() > 448 && player.getLinkStateMachine().getXLoc() + player.LinkPosition().Width < 576) {
                isSwapped = room.SwapRoom(Direction.Up);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0) {
                    if (room.UnlockDoor(Direction.Up)) {
                        isSwapped = room.SwapRoom(Direction.Up);
                        room.UnlockDoor(Direction.Down);
                        player.GetLinkInventory().removeKey();
                    }
                }
                if (isSwapped) {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY - 185, player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), 117 + (64 * 4), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), 117 + (64 * 4), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }

        public static void HandleRightWall()
        {
            bool isSwapped;
            if (player.getLinkStateMachine().getYLoc() > (288 + (64 * 4)) && player.getLinkStateMachine().getYLoc() + player.LinkPosition().Height < (416 + (64 * 4))) {
                isSwapped = room.SwapRoom(Direction.Right);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0) {
                    if (room.UnlockDoor(Direction.Right)) {
                        isSwapped = room.SwapRoom(Direction.Right);
                        room.UnlockDoor(Direction.Left);
                        player.GetLinkInventory().removeKey();
                    }
                }
                if (isSwapped) {
                    Rectangle newPosition = new Rectangle(120, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else {
                    Rectangle newPosition = new Rectangle(maxX - 175, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else {
                Rectangle newPosition = new Rectangle(maxX - 175, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }

        public static void HandleBottomWall()
        {
            bool isSwapped;
            if (player.getLinkStateMachine().getXLoc() > 448 && player.getLinkStateMachine().getXLoc() + player.LinkPosition().Width < 576) {
                isSwapped = room.SwapRoom(Direction.Down);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0) {
                    if (room.UnlockDoor(Direction.Down)) {
                        isSwapped = room.SwapRoom(Direction.Down);
                        room.UnlockDoor(Direction.Up);
                        player.GetLinkInventory().removeKey();
                    }
                }
                if (isSwapped) {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), 117 + (64 * 4), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY - 185, player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY - 185, player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }
    }
}