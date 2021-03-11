using Microsoft.Xna.Framework;
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

        public void SetUpRooms(XmlReader xmlReader)
        {
            //read in data to make list
            SetCurrentRoom(0);
        }

        public void NextRoom()
        {
            roomIndex++;
            if (roomIndex >= roomList.Count) roomIndex = 0;
            SetCurrentRoom(roomIndex);
        }

        public void PreviousRoom()
        {
            roomIndex--;
            if (roomIndex < 0) roomIndex = roomList.Count - 1;
            SetCurrentRoom(roomIndex);
        }

        private void SetCurrentRoom(int index)
        {
            List<IBlock> blocks = roomList[roomIndex].getBlocks();
            List<IItem> items = roomList[roomIndex].getItems();
            List<INPC> npcs = roomList[roomIndex].getNPCs();
            Rectangle floor = roomList[roomIndex].getFloor();
            Rectangle wall = roomList[roomIndex].getWall();
            Rectangle topDoor = roomList[roomIndex].getTopDoor();
            Rectangle bottomDoor = roomList[roomIndex].getBottomDoor();
            Rectangle leftDoor = roomList[roomIndex].getLeftDoor();
            Rectangle rightDoor = roomList[roomIndex].getRightDoor();
            currentRoom = new Room(blocks, items, npcs, floor, wall, topDoor, bottomDoor, leftDoor, rightDoor);
        }
    }
}