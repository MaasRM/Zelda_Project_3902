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

        public Room(List<IBlock> blocks, List<IItem> items, List<INPC> npcs, Rectangle floor, Rectangle wall, 
            Rectangle topDoor, Rectangle bottomDoor, Rectangle leftDoor, Rectangle rightDoor)
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

        public Rectangle getTopDoor()
        {
            return topDoorSource;
        }

        public Rectangle getBottomDoor()
        {
            return bottomDoorSource;
        }

        public Rectangle getLeftDoor()
        {
            return leftDoorSource;
        }

        public Rectangle getRightDoor()
        {
            return rightDoorSource;
        }

    }
}
