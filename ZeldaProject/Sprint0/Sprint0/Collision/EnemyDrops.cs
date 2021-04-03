using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    class EnemyDrops
    {
        public EnemyDrops()
        {

        }

        public static void DropItem(INPC npc, List<IItem> items, Texture2D itemSheet)
        {
            int determineDrop = RandomNumberGenerator.GetInt32(99);
            if (npc.DropsItem())
            {
                if(determineDrop < 10)
                {
                    items.Add(new YellowRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7*4, 15*4), new Rectangle(72, 0, 7, 15), itemSheet));
                }
                if (determineDrop >= 10 && determineDrop < 15)
                {
                    items.Add(new BlueRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7*4, 15*4), new Rectangle(72, 16, 7, 15), itemSheet));
                }
                if (determineDrop >= 15 && determineDrop < 25)
                {
                    items.Add(new HeartItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 6*4, 7*4), new Rectangle(0, 0, 7, 15), itemSheet));
                }
                if (determineDrop >= 25 && determineDrop < 30)
                {
                    items.Add(new BombItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7*4, 13*4), new Rectangle(136, 0, 7, 13), itemSheet));
                }
                if (determineDrop >= 30 && determineDrop < 33)
                {
                    items.Add(new ClockItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 10*4, 15*4), new Rectangle(58, 0, 10, 15), itemSheet));
                }
                if (determineDrop >= 33 && determineDrop < 35)
                {
                    items.Add(new FairyItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7*4, 15*4), new Rectangle(40, 0, 7, 15), itemSheet));
                }
            }
        }
    }
}
