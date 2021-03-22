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

        public Rectangle getDoorSource(Direction dir)
        {
            Rectangle door;
            switch (dir)
            {
                case Direction.MoveUp:
                    door = topDoorSource;
                    break;
                case Direction.MoveDown:
                    door = bottomDoorSource;
                    break;
                case Direction.MoveLeft:
                    door = leftDoorSource;
                    break;
                case Direction.MoveRight:
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
                case Direction.MoveUp:
                    topDoorSource = newSource;
                    break;
                case Direction.MoveDown:
                    bottomDoorSource = newSource;
                    break;
                case Direction.MoveLeft:
                    leftDoorSource = newSource;
                    break;
                case Direction.MoveRight:
                    rightDoorSource =  = newSource;
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
                case Direction.MoveUp:
                    room = nextRoomNums[0];
                    break;
                case Direction.MoveDown:
                    room = nextRoomNums[1];
                    break;
                case Direction.MoveLeft:
                    room = nextRoomNums[2];
                    break;
                case Direction.MoveRight:
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
