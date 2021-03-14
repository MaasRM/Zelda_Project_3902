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
            Rectangle newPosition = new Rectangle (120, npc.GetNPCLocation().Y, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleTopWall()
        {
            Rectangle newPosition = new Rectangle(npc.GetNPCLocation().X, 117, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleRightWall()
        {
            Rectangle newPosition = new Rectangle(maxX - 175, npc.GetNPCLocation().Y, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }

        public static void HandleBottomWall()
        {
            Rectangle newPosition = new Rectangle(npc.GetNPCLocation().X, maxY-175, npc.GetNPCLocation().Width, npc.GetNPCLocation().Height);
            npc.SetPosition(newPosition);
        }
    }
}