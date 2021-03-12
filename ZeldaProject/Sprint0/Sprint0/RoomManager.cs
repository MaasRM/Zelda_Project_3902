using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Sprint0
{
    public class RoomManager
    {
        private List<Room> roomList;
        private int roomIndex;
        private Room currentRoom;

        public RoomManager()
        {
            roomList = new List<Room>();
            roomIndex = 0;
        }

        public void SetUpRooms(XmlDocument xmlDoc)
        {
            XmlNode root = xmlDoc.FirstChild;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                XmlNode currentRoom = root.ChildNodes[i];
                List<IBlock> blocks = new List<IBlock>();
                for (int b = 0; b < currentRoom["Blocks"].ChildNodes.Count; b++)
                {
                    blocks.Add(CreateBlock(currentRoom["Blocks"].ChildNodes[b]));
                }
                List<IItem> items = new List<IItem>();
                for (int it = 0; it < currentRoom["Items"].ChildNodes.Count; it++)
                {
                    items.Add(CreateItem(currentRoom["Items"].ChildNodes[it]));
                }
                List<INPC> npcs = new List<INPC>();
                for (int n = 0; n < currentRoom["Enemies"].ChildNodes.Count; n++)
                {
                    npcs.Add(CreateNPC(currentRoom["Enemies"].ChildNodes[n]));
                }
                Rectangle floor = new Rectangle(int.Parse(currentRoom["Background"]["Xloc"].InnerText), int.Parse(currentRoom["Background"]["Yloc"].InnerText), 191, 111);
                Rectangle walls = new Rectangle(521, 11, 255, 175);
                Rectangle topDoor = GetDoorSource("top", currentRoom["Doors"]["UpDoor"]["DoorType"].InnerText);
                Rectangle bottomDoor = GetDoorSource("bottom", currentRoom["Doors"]["DownDoor"]["DoorType"].InnerText);
                Rectangle leftDoor = GetDoorSource("left", currentRoom["Doors"]["LeftDoor"]["DoorType"].InnerText);
                Rectangle rightDoor = GetDoorSource("right", currentRoom["Doors"]["RightDoor"]["DoorType"].InnerText);
                roomList.Add(new Room(blocks, items, npcs, floor, walls, topDoor, bottomDoor, leftDoor, rightDoor));
            }
            currentRoom = roomList[0];
        }

        private IBlock CreateBlock(XmlNode blockInfo)
        {

        }

        private IItem CreateItem(XmlNode itemInfo)
        {

        }

        private INPC CreateNPC(XmlNode npcInfo)
        {

        }

        private Rectangle GetDoorSource(String direction, String doorType)
        {
            int yOffset = 0;
            int xOffset = 0;
            switch (direction)
            {
                case "top":
                    yOffset = 0;
                    break;
                case "bottom":
                    yOffset = 33;
                    break;
                case "left":
                    yOffset = 66;
                    break;
                case "right":
                    yOffset = 99;
                    break;
                default:
                    break;
            }
            switch (doorType)
            {
                case "Wall":
                    xOffset = 0;
                    break;
                case "OpenDoor":
                    xOffset = 33;
                    break;
                case "LockedDoor":
                    xOffset = 66;
                    break;
                case "ClosedDoor":
                    xOffset = 99;
                    break;
                case "BlownDoor":
                    xOffset = 132;
                    break;
                default:
                    break;
            }
            return new Rectangle(815 + xOffset, 11 + yOffset, 32, 32);
        }

        public void Update()
        {
            //door changes eventually?
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the room
        }

        public void NextRoom()
        {
            roomIndex++;
            if (roomIndex >= roomList.Count) roomIndex = 0;
            currentRoom = roomList[roomIndex];
        }

        public void PreviousRoom()
        {
            roomIndex--;
            if (roomIndex < 0) roomIndex = roomList.Count - 1;
            currentRoom = roomList[roomIndex];
        }
    }
}