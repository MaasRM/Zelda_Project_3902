using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class EnemyWallHandler
    {
        static INPC npc;
        static int minX;
        static int minY;
        static int maxX;
        static int maxY;

        public EnemyWallHandler(INPC enemy, int x1, int x2, int y1, int y2)
        {
            npc = enemy;
            minX = x1;
            minY = y1;
            maxX = x2;
            maxY = y2;
        }

        public static void HandleLeftWall()
        {
            if(npc is Trap)
            {
                ((Trap)npc).Return();
            }

            Rectangle newPosition = new Rectangle(minX, npc.GetNPCLocation().Y, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleTopWall()
        {
            if (npc is Trap)
            {
                ((Trap)npc).Return();
            }

            Rectangle newPosition = new Rectangle(npc.GetNPCLocation().X, minY, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleRightWall()
        {
            if (npc is Trap)
            {
                ((Trap)npc).Return();
            }

            Rectangle newPosition = new Rectangle(maxX, npc.GetNPCLocation().Y, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleBottomWall()
        {
            if (npc is Trap)
            {
                ((Trap)npc).Return();
            }

            Rectangle newPosition = new Rectangle(npc.GetNPCLocation().X, maxY, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }
    }
}