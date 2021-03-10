using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class AllCollisionHandler
    {
        private int cameraWallMinX;
        private int cameraWallMinY;
        private int cameraWallMaxX;
        private int cameraWallMaxY;

        public AllCollisionHandler(int x1, int x2, int y1, int y2)
        {
            cameraWallMinX = x1;
            cameraWallMinY = y1;
            cameraWallMaxX = x2;
            cameraWallMaxY = y2;
        }

        public void HandleCollisions(IPlayer player, List<INPC> npcs, List<IItem> items, List<IBlock> blocks, List<IProjectile> projectiles)
        {
            CheckWalls(player, npcs, blocks);
            PlayerEnemyCollisions(player, npcs);
        }

        private void CheckWalls(IPlayer player, List<INPC> npcs, List<IBlock> blocks)
        {

        }

        private void PlayerEnemyCollisions(IPlayer player, List<INPC> npcs)
        {
            foreach(INPC nPC in npcs)
            {
                if(nPC is IEnemy)
                {
                    if(nPC is Trap)
                    {
                        EnemyProximityTrigger.CheckToTriggerTrap(player, (Trap)nPC);
                    }

                    if (nPC is Wallmaster)
                    {
                        EnemyProximityTrigger.CheckToTriggerWallmaster(player, (Wallmaster) nPC);
                    }

                    
                }
            }
        }

        private void PlayerItemCollisions(IPlayer player, List<IItem> items)
        {
            foreach (IItem item in items)
            {
                if (item.GetLocationRectangle().Intersects(player.LinkPosition()))
                {
                    LinkItemHandler(player, item);
                }
            }
        }
    }
}