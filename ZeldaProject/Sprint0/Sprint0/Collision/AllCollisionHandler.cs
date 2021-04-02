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

        public void CheckWalls(IPlayer player, List<INPC> npcs, RoomManager roomManager)
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

        public void PlayerEnemyCollisions(IPlayer player, List<INPC> npcs, List<SoundEffect> Collision_soundEffects)
        {
            List<INPC> DeadEnemies = new List<INPC>();

            foreach (INPC nPC in npcs) {
                if(nPC is IEnemy) {

                    if (nPC.GetNPCLocation().Intersects(player.LinkPosition())) {
                        
                        LinkEnemyHandler.HandleCollision(player, nPC);

                        EnemyHitAndDeathSounds(nPC, DeadEnemies, Collision_soundEffects);
                    }
                }
            }

            foreach(INPC nPC in DeadEnemies) {
                npcs.Remove(nPC);
            }
        }

        public void PlayerItemCollisions(IPlayer player, List<IItem> items, List<INPC> npcs, List<SoundEffect> Collision_soundEffects)
        {
            List<IItem> collidedItems;
            collidedItems = new List<IItem>();
            foreach (IItem item in items)
            {
                if (item.GetLocationRectangle().Intersects(player.LinkPosition()))
                {
                    LinkItemHandler.HandleCollision(item, player, npcs, Collision_soundEffects, collidedItems);
                }
            }

            foreach (IItem item in collidedItems)
            {
                items.Remove(item);
            }
        }

        public void BlockCollisions(IPlayer player, List<INPC> npcs, List<IBlock> blocks, RoomManager roomManager, List<SoundEffect> Collision_soundEffects)
        {

            foreach (IBlock block1 in blocks)
            {
                if (player.LinkPosition().Intersects(block1.GetBlockLocation()) && (block1.getIndex() != 5) && (block1.getIndex() != 0))
                {
                    Rectangle overlap = Rectangle.Intersect(block1.GetBlockLocation(), player.LinkPosition());

                    LinkBlockHandler.HandleCollision(player, block1, overlap);
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

        public void ProjectileCollisions(IPlayer player, List<INPC> npcs, List<IProjectile> projectiles, List<SoundEffect> Collision_soundEffects)
        {
            List<INPC> DeadEnemies = new List<INPC>();
            foreach (IProjectile projectile in projectiles) {

                if (projectile is IPlayerProjectile) {
                    EnemyProjectileCollision(projectile, npcs, DeadEnemies, Collision_soundEffects);
                }
                else {
                    if (projectile.GetProjectileLocation().Intersects(player.LinkPosition())) {
                        LinkProjectileHandler.HandleCollision(player, projectile);
                    }
                }

                if (projectile.GetProjectileLocation().X < 120 || projectile.GetProjectileLocation().Y < 117 + (64 * 4)
                        || projectile.GetProjectileLocation().X + projectile.GetProjectileLocation().Width > cameraWallMaxX - 130 || projectile.GetProjectileLocation().Y > cameraWallMaxY - 170) {

                    if (projectile is IBoomerang) {
                        ((IBoomerang)projectile).GoBack();
                    }
                    else {
                        projectile.Hit();
                    }
                }

                foreach (INPC nPC in DeadEnemies) {
                    npcs.Remove(nPC);
                }
            }
        }

        private void EnemyProjectileCollision(IProjectile projectile, List<INPC> npcs, List<INPC> DeadEnemies, List<SoundEffect> Collision_soundEffects)
        {
            foreach (INPC nPC in npcs) {
                if (nPC is IEnemy) {
                    if (projectile.GetProjectileLocation().Intersects(nPC.GetNPCLocation())) {

                        EnemyProjectileHandler.HandleCollision(nPC, projectile);

                        EnemyHitAndDeathSounds(nPC, DeadEnemies, Collision_soundEffects);
                    }
                }
            }
        }

        public void CheckTraps(List<INPC> npcs)
        {
            for (int i = 0; i < npcs.Count; i++) {
                for (int j = i + 1; j < npcs.Count; j++) {
                    if(npcs[i] is Trap && npcs[j] is Trap && npcs[i].GetNPCLocation().Intersects(npcs[j].GetNPCLocation())) {
                        TrapCollisionHandler.HandleCollision((Trap)npcs[i], (Trap)npcs[j]);
                    }
                }
            }
        }

        public void CheckLink(IPlayer player, RoomManager roomManager)
        {
            if(!player.IsAlive()) {
                roomManager.FirstRoom();
                player.Reset();
            }
        }

        private void EnemyHitAndDeathSounds(INPC nPC, List<INPC> DeadEnemies, List<SoundEffect> Collision_soundEffects)
        {
            if(((IEnemy)nPC).StillAlive()) {
                if (nPC is Aquamentus) {
                    Collision_soundEffects[1].Play();
                }
                else {
                    Collision_soundEffects[4].Play();
                }
            }
            else {
                if (nPC is Aquamentus) {
                    Collision_soundEffects[0].Play();
                }
                else {
                    Collision_soundEffects[3].Play();
                }

                DeadEnemies.Add(nPC);
            }
        }
    }
}