using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Room
    {
        private List<IBlock> blocks;
        private List<IItem> items;
        private List<INPC> npcs;
        private Rectangle floorSource;
        private Rectangle wallSource;
        private Rectangle topDoorSource;
        private Rectangle bottomDoorSource;
        private Rectangle leftDoorSource;
        private Rectangle rightDoorSource;
        private int roomNum;
        private int[] nextRoomNums;

        public Room(List<IBlock> blocks, List<IItem> items, List<INPC> npcs, Rectangle floor, Rectangle wall,
            Rectangle topDoor, Rectangle bottomDoor, Rectangle leftDoor, Rectangle rightDoor, int room, int[] nextRooms)
        {
            this.blocks = blocks;
            this.items = items;
            this.npcs = npcs;
            floorSource = floor;
            wallSource = wall;
            topDoorSource = topDoor;
            bottomDoorSource = bottomDoor;
            leftDoorSource = leftDoor;
            rightDoorSource = rightDoor;
            roomNum = room;
            nextRoomNums = nextRooms;
        }

        public List<IBlock> getBlocks()
        {
            return blocks;
        }

        public List<IItem> getItems()
        {
            return items;
        }

        public List<INPC> getNPCs()
        {
            return npcs;
        }

        public Rectangle getFloor()
        {
            return floorSource;
        }

        public Rectangle getWall()
        {
            return wallSource;
        }

        public int RoomNum()
        {
            return roomNum;
        }

        public Rectangle getDoorSource(Direction dir)
        {
            Rectangle door;
            switch (dir)
            {
                case Direction.Up:
                    door = topDoorSource;
                    break;
                case Direction.Down:
                    door = bottomDoorSource;
                    break;
                case Direction.Left:
                    door = leftDoorSource;
                    break;
                case Direction.Right:
                    door = rightDoorSource;
                    break;
                default:
                    door = new Rectangle(0, 0, 0, 0);
                    break;
            }
            return door;
        }

        public void setDoorSource(Direction dir, Rectangle newSource)
        {
            switch (dir)
            {
                case Direction.Up:
                    topDoorSource = newSource;
                    break;
                case Direction.Down:
                    bottomDoorSource = newSource;
                    break;
                case Direction.Left:
                    leftDoorSource = newSource;
                    break;
                case Direction.Right:
                    rightDoorSource = newSource;
                    break;
                default:
                    break;
            }
        }

        public int getAdjacentRoomIndex(Direction dir)
        {
            int room;
            switch (dir)
            {
                case Direction.Up:
                    room = nextRoomNums[0];
                    break;
                case Direction.Down:
                    room = nextRoomNums[1];
                    break;
                case Direction.Left:
                    room = nextRoomNums[2];
                    break;
                case Direction.Right:
                    room = nextRoomNums[3];
                    break;
                default:
                    room = -1;
                    break;
            }
            return room;
        }

    }
}
