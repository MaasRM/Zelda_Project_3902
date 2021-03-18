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

        public void HandleCollisions(IPlayer player, List<INPC> npcs, List<IItem> items, List<IBlock> blocks, List<IProjectile> projectiles, RoomManager roomManager)
        {
            PlayerItemCollisions(player, items, npcs);
            BlockCollisions(player, npcs, blocks);
            ProjectileCollisions(player, npcs, projectiles);
            CheckTraps(npcs);
            PlayerEnemyCollisions(player, npcs);
            CheckWalls(player, npcs, blocks, roomManager);
            CheckLink(player, roomManager);
        }

        private void CheckWalls(IPlayer player, List<INPC> npcs, List<IBlock> blocks, RoomManager roomManager)
        {
            bool grabbed = false;

            foreach(INPC npc in npcs)
            {
                if(!(npc is Wallmaster))
                {
                    new EnemyWallHandler(npc, cameraWallMaxX, cameraWallMaxY);

                    if (npc.GetNPCLocation().X < 120)
                    {
                        EnemyWallHandler.HandleLeftWall();
                    }
                    if (npc.GetNPCLocation().Y < 117)
                    {
                        EnemyWallHandler.HandleTopWall();
                    }
                    if (npc.GetNPCLocation().X > cameraWallMaxX - 175)
                    {
                        EnemyWallHandler.HandleRightWall();
                    }
                    if (npc.GetNPCLocation().Y > cameraWallMaxY - 175)
                    {
                        EnemyWallHandler.HandleBottomWall();
                    }
                }
                else
                {
                    grabbed = grabbed || ((Wallmaster)npc).Grabbing();
                }

            }

            new LinkWallHandler(player, cameraWallMaxX, cameraWallMaxY);

            if(!grabbed)
            {
                if (player.getLinkStateMachine().getXLoc() < 120)
                {
                    LinkWallHandler.HandleLeftWall();
                }
                if (player.getLinkStateMachine().getYLoc() < 117)
                {
                    LinkWallHandler.HandleTopWall();
                }
                if (player.getLinkStateMachine().getXLoc() > cameraWallMaxX - 175)
                {
                    LinkWallHandler.HandleRightWall();
                }
                if (player.getLinkStateMachine().getYLoc() > cameraWallMaxY - 185)
                {
                    LinkWallHandler.HandleBottomWall();
                }
            }
            else
            {
                roomManager.FirstRoom();
            }
        }

        private void PlayerEnemyCollisions(IPlayer player, List<INPC> npcs)
        {
            List<INPC> DeadEnemies = new List<INPC>();

            foreach (INPC nPC in npcs)
            {
                if(nPC is IEnemy)
                {
                    if(nPC is Trap)
                    {
                        EnemyProximityTrigger.CheckToTriggerTrap(player, (Trap) nPC);
                    }

                    if (nPC is Wallmaster)
                    {
                        EnemyProximityTrigger.CheckToTriggerWallmaster(player, (Wallmaster) nPC);
                    }

                    if (nPC.GetNPCLocation().Intersects(player.LinkPosition()))
                    {
                        LinkEnemyHandler.HandleCollision(player, nPC);

                        if(!((IEnemy)nPC).StillAlive())
                        {
                            DeadEnemies.Add(nPC);
                        }
                    }
                }
            }

            foreach(INPC nPC in DeadEnemies)
            {
                npcs.Remove(nPC);
            }
        }

        private void PlayerItemCollisions(IPlayer player, List<IItem> items, List<INPC> npcs)
        {
            List<IItem> collidedItems;
            collidedItems = new List<IItem>();
            foreach (IItem item in items)
            {
                if (item.GetLocationRectangle().Intersects(player.LinkPosition()))
                {
                    if(!(item is Fire))
                    {
                        collidedItems.Add(item);
                    }

                    if(item is ClockItem)
                    {
                        foreach (INPC nPC in npcs)
                        {
                            if(nPC is IEnemy)
                            {
                                ((IEnemy)nPC).Stun();
                            }
                        }
                    }
                }
            }

            foreach (IItem item in collidedItems)
            {
                items.Remove(item);
            }
        }

        private void BlockCollisions(IPlayer player, List<INPC> npcs, List<IBlock> blocks)
        {
            foreach (IBlock block1 in blocks)
            {
                if (player.LinkPosition().Intersects(block1.GetBlockLocation()) && (block1.getIndex() != 10))
                {
                    Rectangle overlap = Rectangle.Intersect(block1.GetBlockLocation(), player.LinkPosition());

                    LinkBlockHandler.HandleCollision(player, block1, overlap);
                }
                else if (player.LinkPosition().Intersects(block1.GetBlockLocation()) && (block1.getIndex() == 10))
                {
                    Rectangle overlap = Rectangle.Intersect(block1.GetBlockLocation(), player.LinkPosition());

                    LinkMoveBlockHandler.HandleCollision(player, block1, overlap);

                    /*foreach (IBlock block2 in blocks)
                    {
                        if (block1.GetBlockLocation().Intersects(block2.GetBlockLocation()) && (block1.getIndex() == 10))
                        {
                            Rectangle overlap2 = Rectangle.Intersect(block1.GetBlockLocation(), block2.GetBlockLocation());

                            BlockBlockHandler.HandleCollision(block1, block2, overlap2);
                        }
                    }*/
                }

                foreach (INPC nPC in npcs)
                {
                    if (block1.GetBlockLocation().Intersects(nPC.GetNPCLocation()))
                    {
                        Rectangle overlap = Rectangle.Intersect(block1.GetBlockLocation(), nPC.GetNPCLocation());

                        BlockNPCHandler.HandleCollision(nPC, block1, overlap);
                    }
                }
            }
        }

        private void ProjectileCollisions(IPlayer player, List<INPC> npcs, List<IProjectile> projectiles)
        {
            List<INPC> DeadEnemies = new List<INPC>();
            foreach (IProjectile projectile in projectiles)
            {
                if(projectile is IPlayerProjectile)
                {
                    foreach(INPC nPC in npcs)
                    {
                        if(nPC is IEnemy)
                        {
                            if (projectile.GetProjectileLocation().Intersects(nPC.GetNPCLocation()))
                            {
                                EnemyProjectileHandler.HandleCollision(nPC, projectile);

                                if (!((IEnemy)nPC).StillAlive())
                                {
                                    DeadEnemies.Add(nPC);
                                }
                            }
                        }
                    }

                    foreach(INPC nPC in DeadEnemies)
                    {
                        npcs.Remove(nPC);
                    }

                    if (projectile.GetProjectileLocation().X < 120 || projectile.GetProjectileLocation().Y < 117 
                        || projectile.GetProjectileLocation().X > cameraWallMaxX - 175 || projectile.GetProjectileLocation().Y > cameraWallMaxY - 175)
                    {
                        if (projectile is IBoomerang)
                        {
                            ((IBoomerang)projectile).GoBack();
                        } else
                        {
                            projectile.Hit();
                        }
                    }                    
                }
                else
                {
                    if(projectile.GetProjectileLocation().Intersects(player.LinkPosition()))
                    {
                        LinkProjectileHandler.HandleCollision(player, projectile);
                    }
                }
            }
        }

        private void CheckTraps(List<INPC> npcs)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                for (int j = i + 1; j < npcs.Count; j++)
                {
                    if(npcs[i] is Trap && npcs[j] is Trap && npcs[i].GetNPCLocation().Intersects(npcs[j].GetNPCLocation()))
                    {
                        TrapCollisionHandler.HandleCollision((Trap)npcs[i], (Trap)npcs[j]);
                    }
                }
            }
        }

        private void CheckLink(IPlayer player, RoomManager roomManager)
        {
            if(!player.IsAlive())
            {
                roomManager.FirstRoom();
                player.Reset();
            }
        }
    }
}