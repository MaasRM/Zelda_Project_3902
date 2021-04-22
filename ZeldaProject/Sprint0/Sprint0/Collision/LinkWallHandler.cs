using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class LinkWallHandler
    {
        static IPlayer player;
        static RoomManager room;
        static int minX;
        static int maxX;
        static int minY;
        static int maxY;

        public LinkWallHandler(IPlayer link, RoomManager currentRoom, int x1, int x2, int y1, int y2)
        {
            player = link;
            room = currentRoom;
            minX = x1;
            maxX = x2;
            minY = y1;
            maxY = y2;
        }

        public static bool HandleLeftWall(List<INPC> npcs)
        {
            bool isSwapped = false;
            if (player.getLinkStateMachine().getYLoc() > DoorLocations.HORIDOORYMIN && player.getLinkStateMachine().getYLoc() + player.LinkPosition().Height < DoorLocations.HORIDOORYMAX) {
                isSwapped = room.SwapRoom(Direction.Left);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0) {
                    if (room.UseKeyOnDoor(Direction.Left)) {
                        isSwapped = room.SwapRoom(Direction.Left);
                        room.UseKeyOnDoor(Direction.Right);
                        player.GetLinkInventory().removeKey();
                    }
                }
                if (isSwapped) {
                    Rectangle newPosition = new Rectangle(maxX, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else {
                    Rectangle newPosition = new Rectangle(minX, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else {
                Rectangle newPosition = new Rectangle(minX, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            return isSwapped;
        }

        public static bool HandleTopWall(List<INPC> npcs)
        {
            bool isSwapped = false;
            if (player.getLinkStateMachine().getXLoc() > DoorLocations.VERTDOORXMIN && player.getLinkStateMachine().getXLoc() + player.LinkPosition().Width < DoorLocations.VERTDOORXMAX) {
                isSwapped = room.SwapRoom(Direction.Up);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0) {
                    if (room.UseKeyOnDoor(Direction.Up)) {
                        isSwapped = room.SwapRoom(Direction.Up);
                        room.UseKeyOnDoor(Direction.Down);
                        player.GetLinkInventory().removeKey();
                    }
                }
                if (isSwapped) {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY, player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), minY, player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), minY, player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            return isSwapped;
        }

        public static bool HandleRightWall(List<INPC> npcs)
        {
            bool isSwapped = false;
            if (player.getLinkStateMachine().getYLoc() > DoorLocations.HORIDOORYMIN && player.getLinkStateMachine().getYLoc() + player.LinkPosition().Height < DoorLocations.HORIDOORYMAX) {
                isSwapped = room.SwapRoom(Direction.Right);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0) {
                    if (room.UseKeyOnDoor(Direction.Right)) {
                        isSwapped = room.SwapRoom(Direction.Right);
                        room.UseKeyOnDoor(Direction.Left);
                        player.GetLinkInventory().removeKey();
                    }
                }
                if (isSwapped) {
                    Rectangle newPosition = new Rectangle(minX, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else {
                    Rectangle newPosition = new Rectangle(maxX, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else {
                Rectangle newPosition = new Rectangle(maxX, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            return isSwapped;
        }

        public static bool HandleBottomWall(List<INPC> npcs)
        {
            bool isSwapped = false;
            if (player.getLinkStateMachine().getXLoc() > DoorLocations.VERTDOORXMIN && player.getLinkStateMachine().getXLoc() + player.LinkPosition().Width < DoorLocations.VERTDOORXMAX) {
                isSwapped = room.SwapRoom(Direction.Down);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0) {
                    if (room.UseKeyOnDoor(Direction.Down)) {
                        isSwapped = room.SwapRoom(Direction.Down);
                        room.UseKeyOnDoor(Direction.Up);
                        player.GetLinkInventory().removeKey();
                    }
                }
                if (isSwapped) {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), minY, player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY, player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY, player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
            return isSwapped;
        }
    }
}