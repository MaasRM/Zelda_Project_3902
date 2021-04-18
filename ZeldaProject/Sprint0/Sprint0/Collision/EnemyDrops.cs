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
            if (npc is Stalfos || npc is Wallmaster) {
                if (determineDrop < 25) items.Add(new YellowRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 0, 8, 16), itemSheet));
                if (determineDrop >= 25 && determineDrop < 35) items.Add(new BlueRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 16, 8, 16), itemSheet));
                if (determineDrop >= 35 && determineDrop < 45) items.Add(new HeartItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7 * GameConstants.SCALE, 8 * GameConstants.SCALE), new Rectangle(0, 0, 7, 8), itemSheet));
                if (determineDrop >= 45 && determineDrop < 50) items.Add(new ClockItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 11 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(58, 0, 11, 16), itemSheet));
                
            }

            if(npc is Goriya) {
                if (determineDrop < 15) items.Add(new YellowRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 0, 8, 16), itemSheet));
                if (determineDrop >= 15 && determineDrop < 30) items.Add(new BombItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 14 * GameConstants.SCALE), new Rectangle(136, 0, 8, 14), itemSheet));
                if (determineDrop >= 30 && determineDrop < 45) items.Add(new HeartItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7 * GameConstants.SCALE, 8 * GameConstants.SCALE), new Rectangle(0, 0, 7, 8), itemSheet));
                if (determineDrop >= 45 && determineDrop < 50) items.Add(new ClockItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 11 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(58, 0, 11, 16), itemSheet));
            }

            if(npc is Aquamentus) {
                if (determineDrop < 30) items.Add(new HeartItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7 * GameConstants.SCALE, 8 * GameConstants.SCALE), new Rectangle(0, 0, 7, 8), itemSheet));
                if (determineDrop >= 30 && determineDrop < 40) items.Add(new YellowRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 0, 8, 16), itemSheet));
                if (determineDrop >= 40 && determineDrop < 50) items.Add(new FairyItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(40, 0, 8, 16), itemSheet));
            }
        }
    }
}
