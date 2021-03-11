﻿using System;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class EnemyProximityTrigger
    {
        public const int PIXELSCALER = 2;

        public EnemyProximityTrigger()
        {
        }

        public static void CheckToTriggerWallmaster(IPlayer player, Wallmaster wallmaster)
        {
            Rectangle linkPos = player.LinkPosition();
            Rectangle wallPos = wallmaster.GetNPCLocation();

            int linkX = linkPos.X + linkPos.Width / 2;
            int linkY = linkPos.Y + linkPos.Height / 2;
            int xLoc = wallPos.X + wallPos.Width / 2;
            int yLoc = wallPos.Y + wallPos.Height / 2;

            if (Math.Abs(linkX - xLoc) < 20 * PIXELSCALER && Math.Abs(linkY - yLoc) < 20 * PIXELSCALER)
            {
                wallmaster.TriggerWallmaster();
            }
        }

        public static void CheckToTriggerTrap(IPlayer player, Trap trap)
        {
            Rectangle linkPos = player.LinkPosition();
            Rectangle trapPos = trap.GetNPCLocation();

            int linkX = linkPos.X + linkPos.Width / 2;
            int linkY = linkPos.Y + linkPos.Height / 2;

            if (trap.IsStill() && (linkX >= trapPos.X && linkX < trapPos.X + trapPos.Width) || (linkY >= trapPos.Y && linkY < trapPos.Y + trapPos.Height))
            {
                trap.SetCharge(linkPos);
            }
        }
    }
}