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
        private List<bool> secrets;
        private Texture2D itemsSheet;

        public AllCollisionHandler(int x1, int x2, int y1, int y2, Texture2D items)
        {

            cameraWallMinX = x1;
            cameraWallMinY = y1;
            cameraWallMaxX = x2;
            cameraWallMaxY = y2;
            secrets = new List<bool>();
            secrets.Add(false);
            secrets.Add(false);
            itemsSheet = items;
        }

        public void CheckWalls(IPlayer player, List<INPC> npcs, RoomManager roomManager)
        {
            bool grabbed = false;
            foreach (INPC npc in npcs)
            {
                if (!(npc is Wallmaster))
                {
                    new EnemyWallHandler(npc, cameraWallMaxX, cameraWallMaxY);
                    if (npc.GetNPCLocation().X < 120) EnemyWallHandler.HandleLeftWall();
                    if (npc.GetNPCLocation().Y < (117 + (GameConstants.HUDSIZE * GameConstants.SCALE))) EnemyWallHandler.HandleTopWall();
                    if (npc.GetNPCLocation().X > cameraWallMaxX - 175) EnemyWallHandler.HandleRightWall();
                    if (npc.GetNPCLocation().Y > cameraWallMaxY - 175) EnemyWallHandler.HandleBottomWall();
                }
                else grabbed = grabbed || ((Wallmaster)npc).Grabbing();
            }

            HandleLinkAndWalls(player, roomManager, grabbed);
        }

        public void PlayerEnemyCollisions(IPlayer player, List<INPC> npcs, List<SoundEffect> Collision_soundEffects, List<IItem> items)
        {
            List<INPC> DeadEnemies = new List<INPC>();

            foreach (INPC nPC in npcs)
            {
                if (nPC is IEnemy)
                {

                    if (nPC.GetNPCLocation().Intersects(player.LinkPosition()))
                    {
                        LinkEnemyHandler.HandleCollision(player, nPC);

                        EnemyHitAndDeathSounds(nPC, DeadEnemies, Collision_soundEffects);
                    }
                }
            }

            foreach (INPC nPC in DeadEnemies)
            {
                EnemyDrops.DropItem(nPC, items, itemsSheet);
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
                    player.GetLinkInventory().addItem(item);
                }
            }

            foreach (IItem item in collidedItems)
            {
                items.Remove(item);
            }
        }

        public void BlockCollisions(IPlayer player, List<INPC> npcs, List<IBlock> blocks, RoomManager roomManager, List<SoundEffect> Collision_soundEffects)
        {
            foreach (IBlock block1 in blocks) {
                if (player.LinkPosition().Intersects(block1.GetBlockLocation())) {
                    Rectangle overlap = Rectangle.Intersect(block1.GetBlockLocation(), player.LinkPosition());

                    LinkBlockHandler.HandleCollision(player, block1, overlap, roomManager, Collision_soundEffects, secrets);
                }

                foreach (INPC nPC in npcs) {
                    if (block1.GetBlockLocation().Intersects(nPC.GetNPCLocation())) {
                        Rectangle overlap = Rectangle.Intersect(block1.GetBlockLocation(), nPC.GetNPCLocation());
                        BlockNPCHandler.HandleCollision(nPC, block1, overlap);
                    }
                }
            }
        }

        public void ProjectileCollisions(IPlayer player, List<INPC> npcs, List<IProjectile> projectiles, List<SoundEffect> Collision_soundEffects, List<IItem> items, RoomManager roomManager)
        {
            List<INPC> DeadEnemies = new List<INPC>();
            foreach (IProjectile projectile in projectiles)
            {
                if (projectile is IPlayerProjectile)
                {
                    EnemyProjectileCollision(projectile, npcs, DeadEnemies, Collision_soundEffects);
                }
                else
                {
                    if (projectile.GetProjectileLocation().Intersects(player.LinkPosition())) LinkProjectileHandler.HandleCollision(player, projectile, Collision_soundEffects[11].CreateInstance());
                }

                if (projectile.GetProjectileLocation().X < 120 || projectile.GetProjectileLocation().Y < 117 + (GameConstants.HUDSIZE * GameConstants.SCALE)
                        || projectile.GetProjectileLocation().X + projectile.GetProjectileLocation().Width > cameraWallMaxX - 130 || projectile.GetProjectileLocation().Y > cameraWallMaxY - 170)
                {

                    if (projectile is IBoomerang) ((IBoomerang)projectile).GoBack();
                    else if (projectile is BombProjectile) BombDoor.DetermineDoor(projectile, roomManager);
                    else projectile.Hit();
                }
                foreach (INPC nPC in DeadEnemies)
                {
                    EnemyDrops.DropItem(nPC, items, itemsSheet);
                    npcs.Remove(nPC);
                }
            }
        }

        private void EnemyProjectileCollision(IProjectile projectile, List<INPC> npcs, List<INPC> DeadEnemies, List<SoundEffect> Collision_soundEffects)
        {
            foreach (INPC nPC in npcs)
            {
                if (nPC is IEnemy)
                {
                    if (projectile.GetProjectileLocation().Intersects(nPC.GetNPCLocation()))
                    {

                        EnemyProjectileHandler.HandleCollision(nPC, projectile);

                        EnemyHitAndDeathSounds(nPC, DeadEnemies, Collision_soundEffects);
                    }
                }
            }
        }

        public void CheckTraps(List<INPC> npcs)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                for (int j = i + 1; j < npcs.Count; j++)
                {
                    if (npcs[i] is Trap && npcs[j] is Trap && npcs[i].GetNPCLocation().Intersects(npcs[j].GetNPCLocation()))
                    {
                        ((Trap)npcs[i]).Return();
                        ((Trap)npcs[j]).Return();
                    }
                }
            }
        }

        private void HandleLinkAndWalls(IPlayer player, RoomManager roomManager, bool grabbed)
        {
            new LinkWallHandler(player, roomManager, cameraWallMaxX, cameraWallMaxY);

            if (roomManager.getRoomIndex() != GameConstants.VERTICALROOM && !grabbed) {
                if (player.getLinkStateMachine().getXLoc() < 120) LinkWallHandler.HandleLeftWall();
                if (player.getLinkStateMachine().getYLoc() < (117 + (64 * GameConstants.SCALE))) LinkWallHandler.HandleTopWall();
                if (player.getLinkStateMachine().getXLoc() > cameraWallMaxX - 175) LinkWallHandler.HandleRightWall();
                if (player.getLinkStateMachine().getYLoc() > cameraWallMaxY - 185) LinkWallHandler.HandleBottomWall(); 
            } else if(grabbed) {
                if(player.getLinkStateMachine().getXLoc() < 120 || player.getLinkStateMachine().getYLoc() < (117 + (GameConstants.HUDSIZE * GameConstants.SCALE)) ||
                    player.getLinkStateMachine().getXLoc() > cameraWallMaxX - 175 || player.getLinkStateMachine().getYLoc() > cameraWallMaxY - 185)
                {
                    roomManager.ChangeRoom(15);
                }
            } else {
                if (player.getLinkStateMachine().getYLoc() < GameConstants.HUDSIZE * GameConstants.SCALE) {
                    roomManager.ChangeRoom(0);
                    player.SetPosition(new Rectangle((36 * GameConstants.SCALE) + 75 * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + (36 * GameConstants.SCALE) + 44 * GameConstants.SCALE, 0, 0));
                }
                if (player.getLinkStateMachine().getXLoc() < 120) LinkWallHandler.HandleLeftWall();
                if (player.getLinkStateMachine().getXLoc() > cameraWallMaxX - 175) LinkWallHandler.HandleRightWall();
                if (player.getLinkStateMachine().getYLoc() > cameraWallMaxY - 185) LinkWallHandler.HandleBottomWall();
            }
        }

        private void EnemyHitAndDeathSounds(INPC nPC, List<INPC> DeadEnemies, List<SoundEffect> Collision_soundEffects)
        {
            if (((IEnemy)nPC).StillAlive())
            {
                if (nPC is Aquamentus)
                {
                    Collision_soundEffects[1].Play();
                }
                else
                {
                    Collision_soundEffects[4].Play();
                }
            }
            else
            {
                if (nPC is Aquamentus)
                {
                    Collision_soundEffects[0].Play();
                }
                else if (nPC is Goriya)
                {
                    ((Goriya)nPC).StopThrowSound();
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