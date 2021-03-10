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

        public Room(List<IBlock> blocks, List<IItem> items, List<INPC> npcs)
        {
            this.blocks = blocks;
            this.items = items;
            this.npcs = npcs;
        }

    }
}
