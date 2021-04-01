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
            Boolean isSwapped;
            if (player.getLinkStateMachine().getYLoc() > (288 + (64 * 4)) && player.getLinkStateMachine().getYLoc() + player.LinkPosition().Height < (416 + (64 * 4)))
            {
                isSwapped = room.SwapRoom(Direction.MoveLeft);
                if(!isSwapped && player.GetLinkInventory().getKeyCount() > 0)
                {
                    room.UnlockDoor(Direction.MoveLeft);
                    isSwapped = room.SwapRoom(Direction.MoveLeft);
                    room.UnlockDoor(Direction.MoveRight);
                }
                if (isSwapped)
                {
                    Rectangle newPosition = new Rectangle(maxX - 175, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else
                {
                    Rectangle newPosition = new Rectangle(120, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else
            {
                Rectangle newPosition = new Rectangle(120, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }

        public static void HandleTopWall()
        {
            Boolean isSwapped;
            if (player.getLinkStateMachine().getXLoc() > 448 && player.getLinkStateMachine().getXLoc() + player.LinkPosition().Width < 576)
            {
                isSwapped = room.SwapRoom(Direction.MoveUp);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0)
                {
                    room.UnlockDoor(Direction.MoveUp);
                    isSwapped = room.SwapRoom(Direction.MoveUp);
                    room.UnlockDoor(Direction.MoveDown);
                }
                if (isSwapped)
                {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY - 185, player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else
                {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), 117 + (64 * 4), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else
            {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), 117 + (64 * 4), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }

        public static void HandleRightWall()
        {
            Boolean isSwapped;
            if (player.getLinkStateMachine().getYLoc() > (288 + (64 * 4)) && player.getLinkStateMachine().getYLoc() + player.LinkPosition().Height < (416 + (64 * 4)))
            {
                isSwapped = room.SwapRoom(Direction.MoveRight);
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0)
                {
                    room.UnlockDoor(Direction.MoveRight);
                    isSwapped = room.SwapRoom(Direction.MoveRight);
                    room.UnlockDoor(Direction.MoveLeft);
                }
                if (isSwapped)
                {
                    Rectangle newPosition = new Rectangle(120, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else
                {
                    Rectangle newPosition = new Rectangle(maxX - 175, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else
            {
                Rectangle newPosition = new Rectangle(maxX - 175, player.getLinkStateMachine().getYLoc(), player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }

        public static void HandleBottomWall()
        {
            Boolean isSwapped;
            if (player.getLinkStateMachine().getXLoc() > 448 && player.getLinkStateMachine().getXLoc() + player.LinkPosition().Width < 576)
            {
                isSwapped = room.SwapRoom(Direction.MoveDown);                
                if (!isSwapped && player.GetLinkInventory().getKeyCount() > 0)
                {
                    room.UnlockDoor(Direction.MoveDown);
                    isSwapped = room.SwapRoom(Direction.MoveDown);
                    room.UnlockDoor(Direction.MoveUp);
                }
                if (isSwapped)
                {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), 117 + (64 * 4), player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
                else
                {
                    Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY - 185, player.LinkPosition().Width, player.LinkPosition().Height);
                    player.getLinkStateMachine().SetPositions(newPosition);
                }
            }
            else
            {
                Rectangle newPosition = new Rectangle(player.getLinkStateMachine().getXLoc(), maxY - 185, player.LinkPosition().Width, player.LinkPosition().Height);
                player.getLinkStateMachine().SetPositions(newPosition);
            }
        }
    }
}