using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Sprint0
{
    public class AllCollisionHandler
    {
        
        private int cameraWallMinX;
        private int cameraWallMinY;
        private int cameraWallMaxX;
        private int cameraWallMaxY;
        private bool playedSecret1;
        private bool playedSecret2;

        public AllCollisionHandler(int x1, int x2, int y1, int y2)
        {
            
            cameraWallMinX = x1;
            cameraWallMinY = y1;
            cameraWallMaxX = x2;
            cameraWallMaxY = y2;
            playedSecret1 = false;
            playedSecret2 = false;
        }

        public void HandleCollisions(IPlayer player, List<INPC> npcs, List<IItem> items, List<IBlock> blocks, List<IProjectile> projectiles, RoomManager roomManager, List<SoundEffect> Collision_soundEffects)
        {
            PlayerItemCollisions(player, items, npcs, Collision_soundEffects);
            BlockCollisions(player, npcs, blocks, roomManager, Collision_soundEffects);
            ProjectileCollisions(player, npcs, projectiles, Collision_soundEffects);
            CheckTraps(npcs);
            PlayerEnemyCollisions(player, npcs, Collision_soundEffects);
            CheckWalls(player, npcs, blocks, roomManager);
            CheckLink(player, roomManager);
        }

        private void CheckWalls(IPlayer player, List<INPC> npcs, List<IBlock> blocks, RoomManager roomManager)
        {
            bool grabbed = false;

            foreach (INPC npc in npcs)
            {
                if (!(npc is Wallmaster))
                {
                    new EnemyWallHandler(npc, cameraWallMaxX, cameraWallMaxY);

                    if (npc.GetNPCLocation().X < 120)
                    {
                        EnemyWallHandler.HandleLeftWall();
                    }
                    if (npc.GetNPCLocation().Y < (117 + (64 * 4)))
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

            new LinkWallHandler(player, roomManager, cameraWallMaxX, cameraWallMaxY);

            if (!grabbed)
            {
                if (player.getLinkStateMachine().getXLoc() < 120)
                {
                    LinkWallHandler.HandleLeftWall();
                }
                if (player.getLinkStateMachine().getYLoc() < (117 + (64 * 4)))
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

        private void PlayerEnemyCollisions(IPlayer player, List<INPC> npcs, List<SoundEffect> Collision_soundEffects)
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
                        if (nPC is Aquamentus)
                        {
                            Collision_soundEffects[1].Play();
                        }
                        else
                        {
                            Collision_soundEffects[4].Play();
                        }

                        LinkEnemyHandler.HandleCollision(player, nPC);

                        if(!((IEnemy)nPC).StillAlive())
                        {
                            if (nPC is Aquamentus)
                            {
                                Collision_soundEffects[0].Play();
                            }
                            else
                            {
                                Collision_soundEffects[3].Play();
                            }

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

        private void PlayerItemCollisions(IPlayer player, List<IItem> items, List<INPC> npcs, List<SoundEffect> Collision_soundEffects)
        {
            List<IItem> collidedItems;
            collidedItems = new List<IItem>();
            foreach (IItem item in items)
            {
                if (item.GetLocationRectangle().Intersects(player.LinkPosition()))
                {
                    if(!(item is Fire))
                    {
                        if(item is KeyItem || item is HeartItem)
                        {
                            Collision_soundEffects[6].Play();
                            collidedItems.Add(item);
                        }
                        else if(item is BlueRupeeItem || item is YellowRupeeItem)
                        {
                            Collision_soundEffects[8].Play();
                            collidedItems.Add(item);
                        }
                        else
                        {
                            Collision_soundEffects[7].Play();
                            collidedItems.Add(item);
                        }
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

        private void BlockCollisions(IPlayer player, List<INPC> npcs, List<IBlock> blocks, RoomManager roomManager, List<SoundEffect> Collision_soundEffects)
        {

            foreach (IBlock block1 in blocks)
            {
                if (player.LinkPosition().Intersects(block1.GetBlockLocation()) && (block1.getIndex() != 10) && (block1.getIndex() != 5) && (block1.getIndex() != 0))
                {
                    Rectangle overlap = Rectangle.Intersect(block1.GetBlockLocation(), player.LinkPosition());

                    LinkBlockHandler.HandleCollision(player, block1, overlap);
                }
                else if (player.LinkPosition().Intersects(block1.GetBlockLocation()) && (block1.getIndex() == 10) && (block1.getIndex() != 5) && (block1.getIndex() != 0))
                {
                    Rectangle overlap = Rectangle.Intersect(block1.GetBlockLocation(), player.LinkPosition());

                    LinkMoveBlockHandler.HandleCollision(player, block1, overlap);
                } 
                else if (player.LinkPosition().Intersects(block1.GetBlockLocation()) && block1.getIndex() == 0)
                {
                    if(!playedSecret1 && roomManager.Room().RoomNum() == 0)
                    {
                        Collision_soundEffects[9].Play();
                        playedSecret1 = true;
                    }
                    else if(!playedSecret2 && roomManager.Room().RoomNum() == 6)
                    {
                        Collision_soundEffects[9].Play();
                        playedSecret2 = true;
                        roomManager.UnlockDoor(Direction.MoveLeft);
                    }
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

        private void ProjectileCollisions(IPlayer player, List<INPC> npcs, List<IProjectile> projectiles, List<SoundEffect> Collision_soundEffects)
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
                                if(nPC is Aquamentus)
                                {
                                    Collision_soundEffects[1].Play();
                                }
                                else
                                {
                                    Collision_soundEffects[4].Play();
                                }

                                EnemyProjectileHandler.HandleCollision(nPC, projectile);

                                if (!((IEnemy)nPC).StillAlive())
                                {
                                    if (nPC is Aquamentus)
                                    {
                                        Collision_soundEffects[0].Play();
                                    }
                                    else
                                    {
                                        Collision_soundEffects[3].Play();
                                    }

                                    DeadEnemies.Add(nPC);
                                }
                            }
                        }
                    }

                    foreach(INPC nPC in DeadEnemies)
                    {
                        npcs.Remove(nPC);
                    }

                    if (projectile.GetProjectileLocation().X < 120 || projectile.GetProjectileLocation().Y < 117 + (64 * 4) 
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