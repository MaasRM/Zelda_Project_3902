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
            secrets.Add(false);
            secrets.Add(false);
            itemsSheet = items;
        }

        public void CheckWalls(IPlayer player, List<INPC> npcs, RoomManager roomManager, Shop shop)
        {
            bool grabbed = false;
            foreach (INPC npc in npcs)
            {
                if (!(npc is Wallmaster))
                {
                    new EnemyWallHandler(npc, cameraWallMinX, cameraWallMaxX, cameraWallMinY, cameraWallMaxY);
                    if (npc.GetNPCLocation().X < cameraWallMinX) EnemyWallHandler.HandleLeftWall();
                    if (npc.GetNPCLocation().Y < cameraWallMinY) EnemyWallHandler.HandleTopWall();
                    if (npc.GetNPCLocation().X > cameraWallMaxX) EnemyWallHandler.HandleRightWall();
                    if (npc.GetNPCLocation().Y > cameraWallMaxY) EnemyWallHandler.HandleBottomWall();
                }
                else grabbed = grabbed || ((Wallmaster)npc).Grabbing();
            }

            HandleLinkAndWalls(player, npcs, roomManager, grabbed, shop);
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

        public void PlayerItemCollisions(IPlayer player, List<IItem> items, List<INPC> npcs, List<SoundEffect> Collision_soundEffects, Shop shop)
        {
            List<IItem> collidedItems;
            collidedItems = new List<IItem>();
            foreach (IItem item in items)
            {
                if (item.GetLocationRectangle().Intersects(player.LinkPosition()) && (!shop.IsShopCurrent() || (shop.IsShopAvailable() && shop.TryBuyItem(item))))
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

                if (projectile.GetProjectileLocation().X < cameraWallMinX - WallConstants.PROJECTILEEXTRA || projectile.GetProjectileLocation().Y < cameraWallMinY - WallConstants.PROJECTILEEXTRA
                        || projectile.GetProjectileLocation().X + projectile.GetProjectileLocation().Width > cameraWallMaxX + WallConstants.PROJECTILEEXTRA || projectile.GetProjectileLocation().Y > cameraWallMaxY + WallConstants.PROJECTILEEXTRA)
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

                        if (!(projectile is SwordBlastProjectile))
                        {
                            if(!(projectile is BombProjectile) || ((projectile is BombProjectile) && ((BombProjectile)projectile).Exploding()))
                            {
                                EnemyHitAndDeathSounds(nPC, DeadEnemies, Collision_soundEffects);
                            }
                        }
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

        private void HandleLinkAndWalls(IPlayer player, List<INPC> npcs, RoomManager roomManager, bool grabbed, Shop shop)
        {
            new LinkWallHandler(player, roomManager, cameraWallMinX, cameraWallMaxX, cameraWallMinY, cameraWallMaxY);

            if(grabbed) {
                if(player.getLinkStateMachine().getXLoc() < cameraWallMinX || player.getLinkStateMachine().getYLoc() < cameraWallMinY ||
                    player.getLinkStateMachine().getXLoc() > cameraWallMaxX || player.getLinkStateMachine().getYLoc() > cameraWallMaxY)
                {
                    roomManager.ChangeRoom(GameConstants.STARTROOM);
                }
            } else if(roomManager.getRoomIndex() == GameConstants.VERTICALROOMTOP || roomManager.getRoomIndex() == GameConstants.VERTICALROOMBOTTOM) {
                VerticalRoomHandler(player, roomManager, npcs);
            } else if(roomManager.getRoomIndex() == GameConstants.OUTSIDEROOM) {
                if (player.getLinkStateMachine().getXLoc() > cameraWallMaxX + (WallConstants.WALLSIZE * GameConstants.SCALE))
                {
                    roomManager.ChangeRoom(GameConstants.SHOPROOM);
                    shop.SetUpShop();
                    player.SetPosition(new Rectangle(cameraWallMinX - (WallConstants.WALLSIZE * GameConstants.SCALE), player.getLinkStateMachine().getYLoc(), 0, 0));
                }
            } else if (roomManager.getRoomIndex() == GameConstants.SHOPROOM) {
                if (player.getLinkStateMachine().getXLoc() < cameraWallMinX - (WallConstants.WALLSIZE * GameConstants.SCALE))
                {
                    shop.TearDownShop();
                    roomManager.ChangeRoom(GameConstants.OUTSIDEROOM);
                    player.SetPosition(new Rectangle(cameraWallMaxX + (WallConstants.WALLSIZE * GameConstants.SCALE), player.getLinkStateMachine().getYLoc(), 0, 0));
                }
            } else {
                bool stopSound = false;
                if (player.getLinkStateMachine().getXLoc() < cameraWallMinX) stopSound = stopSound || LinkWallHandler.HandleLeftWall(npcs);
                if (player.getLinkStateMachine().getYLoc() < cameraWallMinY) stopSound = stopSound ||  LinkWallHandler.HandleTopWall(npcs);
                if (player.getLinkStateMachine().getXLoc() > cameraWallMaxX) stopSound = stopSound ||  LinkWallHandler.HandleRightWall(npcs);
                if (player.getLinkStateMachine().getYLoc() > cameraWallMaxY) stopSound = stopSound ||  LinkWallHandler.HandleBottomWall(npcs);
                if(stopSound) foreach (INPC npc in npcs) if (npc is Goriya) ((Goriya)npc).StopThrowSound();
            }
        }

        private void EnemyHitAndDeathSounds(INPC nPC, List<INPC> DeadEnemies, List<SoundEffect> Collision_soundEffects)
        {
            if (((IEnemy)nPC).StillAlive())
            {
                if (nPC is Aquamentus || nPC is Gohma || nPC is Dodongo)
                {
                    Collision_soundEffects[1].Play();
                }
                else if (!(nPC is Wallmaster) && !(nPC is Wizzrobe && ((Wizzrobe)nPC).IsTeleporting()))
                {
                    Collision_soundEffects[4].Play();
                }
            }
            else
            {
                if (nPC is Aquamentus) Collision_soundEffects[0].Play();
                else if (nPC is Gohma || nPC is Dodongo) Collision_soundEffects[12].Play();
                else if (nPC is Goriya)
                {
                    ((Goriya)nPC).StopThrowSound();
                    Collision_soundEffects[3].Play();
                }
                else
                {
                    Collision_soundEffects[3].Play();
                }
                DeadEnemies.Add(nPC);
            }
        }

        private void VerticalRoomHandler(IPlayer player, RoomManager roomManager, List<INPC> npcs)
        {
            if (player.getLinkStateMachine().getYLoc() < GameConstants.HUDSIZE * GameConstants.SCALE)
            {
                if (roomManager.getRoomIndex() == GameConstants.VERTICALROOMTOP)
                {
                    roomManager.ChangeRoom(0);
                    player.SetPosition(new Rectangle((WallConstants.WALLSIZE * GameConstants.SCALE) + GameConstants.STAIRROOMOFFSETX * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + (WallConstants.WALLSIZE * GameConstants.SCALE) + GameConstants.STAIRROOMOFFSETY * GameConstants.SCALE, 0, 0));
                }
                else if (player.getLinkStateMachine().getXLoc() < (cameraWallMaxX - cameraWallMinX) / 2)
                {
                    roomManager.ChangeRoom(25);
                    player.SetPosition(new Rectangle(192 * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) +  80 * GameConstants.SCALE, 0, 0));
                }
                else 
                {
                    roomManager.ChangeRoom(33);
                    player.SetPosition(new Rectangle(128 * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + 64 * GameConstants.SCALE, 0, 0));
                }
            }
            if (player.getLinkStateMachine().getXLoc() < cameraWallMinX) LinkWallHandler.HandleLeftWall(npcs);
            if (player.getLinkStateMachine().getXLoc() > cameraWallMaxX) LinkWallHandler.HandleRightWall(npcs);
            if (player.getLinkStateMachine().getYLoc() > cameraWallMaxY) LinkWallHandler.HandleBottomWall(npcs);
        }
    }
}