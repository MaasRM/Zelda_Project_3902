using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class EnemyWallHandler
    {
        static INPC npc;
        static int maxX;
        static int maxY;

        public EnemyWallHandler(INPC enemy, int x, int y)
        {
            npc = enemy;
            maxX = x;
            maxY = y;
        }

        public static void HandleLeftWall()
        {
            if(npc is Trap)
            {
                ((Trap)npc).Return();
            }

            Rectangle newPosition = new Rectangle(120, npc.GetNPCLocation().Y, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleTopWall()
        {
            if (npc is Trap)
            {
                ((Trap)npc).Return();
            }

            Rectangle newPosition = new Rectangle(npc.GetNPCLocation().X, 117 + (64 * 4), npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleRightWall()
        {
            if (npc is Trap)
            {
                ((Trap)npc).Return();
            }

            Rectangle newPosition = new Rectangle(maxX - 175, npc.GetNPCLocation().Y, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleBottomWall()
        {
            if (npc is Trap)
            {
                ((Trap)npc).Return();
            }

            Rectangle newPosition = new Rectangle(npc.GetNPCLocation().X, maxY-175, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }
    }
}