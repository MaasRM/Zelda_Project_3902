using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Shop
    {
        Sprint4 game;
        INPC OldMan;
        ShopText oldManText;
        LinkInventory linkInv;
        List<IItem> shopItems;
        List<ItemText> itemPrices;
        RoomManager roomManager;
        Texture2D itemSheet;
        Texture2D dungeonSheet;

        public Shop(LinkInventory inv, Texture2D npcSheet, Texture2D dungeonSheet, Texture2D itemSheet, RoomManager manager, Sprint4 game)
        {
            this.game = game;
            OldMan = new OldMan(ShopConstants.OLDMANX * GameConstants.SCALE, ShopConstants.OLDMANY * GameConstants.SCALE, npcSheet);
            oldManText = new ShopText(dungeonSheet, game);
            linkInv = inv;
            shopItems = new List<IItem>();
            itemPrices = new List<ItemText>();
            roomManager = manager;
            this.dungeonSheet = dungeonSheet;
            this.itemSheet = itemSheet;
        }

        public void Update()
        {
            if (roomManager.getRoomIndex() == GameConstants.SHOPROOM)
            {
                oldManText.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (roomManager.getRoomIndex() == GameConstants.SHOPROOM)
            {
                OldMan.Draw(spriteBatch);
                oldManText.Draw(spriteBatch);
                foreach (ItemText x in itemPrices)
                {
                    x.Draw(spriteBatch);
                }
            }
            else oldManText.Reset();
        }

        public void SetUpShop()
        {
            UpdateItems();
            game.SetItems(shopItems);
        }

        public void TearDownShop()
        {
            game.SetItems(new List<IItem>());
        }

        public void UpdateItems()
        {
            //bombs, sword upgrade, blue arrow/boomerang upgrade, armor/color upgrade
            shopItems.Clear();
            BombItem bomb = new BombItem(new Rectangle(45 * GameConstants.SCALE, 110 * GameConstants.SCALE, 8 * GameConstants.SCALE, 14 * GameConstants.SCALE), new Rectangle(136, 0, 8, 14), itemSheet);
            shopItems.Add(bomb);

            itemPrices.Clear();
            itemPrices.Add(new ItemText(ShopConstants.BOMBCOST, dungeonSheet, bomb.GetLocationRectangle()));
        }

    }
}
