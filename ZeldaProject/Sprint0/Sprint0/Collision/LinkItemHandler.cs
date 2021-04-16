using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
namespace Sprint0
{
    public class LinkItemHandler
    {
        private const int BLUERUPEEVALUE = 5;
        private const int YELLOWRUPEEVLAUE = 1;

        public LinkItemHandler()
        {
        }

        public static void HandleCollision(IItem item, IPlayer player, List<INPC> npcs, List<SoundEffect> Collision_soundEffects, List<IItem> collidedItems)
        {
            if (!(item is Fire)) {
               if (item is KeyItem || item is SecretKey || item is EnemyKey) HandleKey(item, player, Collision_soundEffects, collidedItems);
               else if (item is HeartItem) HandleHeart(item, player, Collision_soundEffects, collidedItems);
               else if (item is HeartContainerItem) HandleHeartContainer(item, player, Collision_soundEffects, collidedItems);
               else if (item is BlueRupeeItem) HandleBlueRupee(item, player, Collision_soundEffects, collidedItems);
               else if (item is YellowRupeeItem) HandleYellowRupee(item, player, Collision_soundEffects, collidedItems);
               else if (item is ClockItem) HandleClock(item, npcs, collidedItems, Collision_soundEffects);
               else if (item is BombItem) HandleBomb(item, player, Collision_soundEffects, collidedItems);
               else if (item is MapItem)
               {
                    collidedItems.Add(item);
                    player.GetLinkInventory().linkMinimap.setMinimap(true);
                    player.GetLinkInventory().pauseScreen.setMap(true);
                    Collision_soundEffects[7].Play();
                }
               else if (item is CompassItem)
               {
                    collidedItems.Add(item);
                    player.GetLinkInventory().linkMinimap.setCompass(true);
                    player.GetLinkInventory().pauseScreen.setCompass(true);
                    Collision_soundEffects[7].Play();
                }
                else HandleOtherItems(item, player, Collision_soundEffects, collidedItems);
            }  
        }

        private static void HandleKey(IItem item, IPlayer player, List<SoundEffect> Collision_soundEffects, List<IItem> collidedItems)
        {
            Collision_soundEffects[6].Play();
            collidedItems.Add(item);
            player.GetLinkInventory().addKey();
        }

        private static void HandleHeart(IItem item, IPlayer player, List<SoundEffect> Collision_soundEffects, List<IItem> collidedItems)
        {
            Collision_soundEffects[6].Play();
            collidedItems.Add(item);
            player.GetLinkInventory().addItem(item);
            player.getLinkStateMachine().Heal(2);
        }

        private static void HandleHeartContainer(IItem item, IPlayer player, List<SoundEffect> Collision_soundEffects, List<IItem> collidedItems)
        {
            Collision_soundEffects[6].Play();
            collidedItems.Add(item);
            player.GetLinkInventory().addItem(item);
            player.getLinkStateMachine().SetMaxHealth(player.getLinkStateMachine().GetMaxHealth() + 2);
            player.getLinkStateMachine().Heal(player.getLinkStateMachine().GetMaxHealth());
        }

        private static void HandleBomb(IItem item, IPlayer player, List<SoundEffect> Collision_soundEffects, List<IItem> collidedItems)
        {
            collidedItems.Add(item);
            player.GetLinkInventory().addBomb();
        }

        private static void HandleBlueRupee(IItem item, IPlayer player, List<SoundEffect> Collision_soundEffects, List<IItem> collidedItems)
        {
            Collision_soundEffects[8].Play();
            collidedItems.Add(item);
            player.GetLinkInventory().addRupee(BLUERUPEEVALUE);
        }

        private static void HandleYellowRupee(IItem item, IPlayer player, List<SoundEffect> Collision_soundEffects, List<IItem> collidedItems)
        {
            Collision_soundEffects[8].Play();
            collidedItems.Add(item);
            player.GetLinkInventory().addRupee(YELLOWRUPEEVLAUE);
        }

        private static void HandleClock(IItem item, List<INPC> npcs, List<IItem> collidedItems, List<SoundEffect> Collision_soundEffects)
        {
            Collision_soundEffects[6].Play();
            collidedItems.Add(item);
            foreach (INPC nPC in npcs)
            {
                if (nPC is IEnemy)
                {
                    ((IEnemy)nPC).Stun();
                }
            }
        }

        private static void HandleOtherItems(IItem item, IPlayer player, List<SoundEffect> Collision_soundEffects, List<IItem> collidedItems)
        {
            player.getLinkStateMachine().setAnimation(Animation.PickUpItem);
            ((Link)player).GiveLinkItemPickup(item.GetSourceRectangle(), item.GetLocationRectangle(), item.GetSpriteSheet());
            if (item is BoomerangItem || item is BowItem || item is TriforceShardItem) Collision_soundEffects[5].Play();
            else if (item is FairyItem)
            {
                Collision_soundEffects[5].Play();
                player.Heal(5);
            }
            else Collision_soundEffects[7].Play();
            collidedItems.Add(item);
            player.GetLinkInventory().addItem(item);
        }
    }
}