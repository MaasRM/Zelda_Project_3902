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
            if (npc is Stalfos || npc is Wallmaster || npc is Gibdo) {
                if (determineDrop < 60) items.Add(new YellowRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 0, 8, 16), itemSheet));
                if (determineDrop >= 60 && determineDrop < 80) items.Add(new BlueRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 16, 8, 16), itemSheet));
                if (determineDrop >= 80 && determineDrop < 90) items.Add(new HeartItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7 * GameConstants.SCALE, 8 * GameConstants.SCALE), new Rectangle(0, 0, 7, 8), itemSheet));
                if (determineDrop >= 90 && determineDrop < 95) items.Add(new ClockItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 11 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(58, 0, 11, 16), itemSheet));               
            }

            if (npc is Keese || npc is Zol || npc is Gel)
            {
                if (determineDrop < 60) items.Add(new YellowRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 0, 8, 16), itemSheet));
                if (determineDrop >= 60 && determineDrop < 80) items.Add(new BlueRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 16, 8, 16), itemSheet));
            }

            if (npc is Darknut)
            {
                if (determineDrop < 30) items.Add(new YellowRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 0, 8, 16), itemSheet));
                if (determineDrop >= 30 && determineDrop < 60) items.Add(new BlueRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 16, 8, 16), itemSheet));
                if (determineDrop >= 60 && determineDrop < 85) items.Add(new BombItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 14 * GameConstants.SCALE), new Rectangle(136, 0, 8, 14), itemSheet));
                if (determineDrop >= 85 && determineDrop < 100) items.Add(new HeartItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7 * GameConstants.SCALE, 8 * GameConstants.SCALE), new Rectangle(0, 0, 7, 8), itemSheet));
            }

            if (npc is Goriya) {
                if (determineDrop < 30) items.Add(new BlueRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 0, 8, 16), itemSheet));
                if (determineDrop >= 30 && determineDrop < 60) items.Add(new BombItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 14 * GameConstants.SCALE), new Rectangle(136, 0, 8, 14), itemSheet));
                if (determineDrop >= 60 && determineDrop < 70) items.Add(new HeartItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7 * GameConstants.SCALE, 8 * GameConstants.SCALE), new Rectangle(0, 0, 7, 8), itemSheet));
                if (determineDrop >= 70 && determineDrop < 80) items.Add(new ClockItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 11 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(58, 0, 11, 16), itemSheet));
            }

            if(npc is Aquamentus || npc is Gohma || npc is Dodongo) {
                if (determineDrop < 50) items.Add(new HeartItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 7 * GameConstants.SCALE, 8 * GameConstants.SCALE), new Rectangle(0, 0, 7, 8), itemSheet));
                if (determineDrop >= 50 && determineDrop < 80) items.Add(new YellowRupeeItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(72, 0, 8, 16), itemSheet));
                if (determineDrop >= 80 && determineDrop < 100) items.Add(new FairyItem(new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, 8 * GameConstants.SCALE, 16 * GameConstants.SCALE), new Rectangle(40, 0, 8, 16), itemSheet));
            }
        }
    }
}
