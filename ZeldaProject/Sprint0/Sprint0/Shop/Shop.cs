using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Shop
    {
        Sprint5 game;
        INPC OldMan;
        ShopText oldManText;
        LinkInventory linkInv;
        Dictionary<IItem, ItemText> shopItems;
        RoomManager roomManager;
        Texture2D itemSheet;
        Texture2D dungeonSheet;

        public Shop(LinkInventory inv, Texture2D npcSheet, Texture2D dungeonSheet, Texture2D itemSheet, RoomManager manager, Sprint5 game)
        {
            this.game = game;
            OldMan = new OldMan(ShopConstants.OLDMANX * GameConstants.SCALE, ShopConstants.OLDMANY * GameConstants.SCALE, npcSheet);
            oldManText = new ShopText(dungeonSheet, game);
            linkInv = inv;
            shopItems = new Dictionary<IItem, ItemText>();
            roomManager = manager;
            this.dungeonSheet = dungeonSheet;
            this.itemSheet = itemSheet;
        }

        public void Update()
        {
            if (roomManager.getRoomIndex() == GameConstants.SHOPROOM)
            {
                oldManText.Update();
                Dictionary<IItem, ItemText> newShopItems = new Dictionary<IItem, ItemText>();
                foreach (IItem item in game.GetItems())
                {
                    ItemText current;
                    shopItems.TryGetValue(item, out current);
                    newShopItems.Add(item, current);
                }
                shopItems = newShopItems;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (roomManager.getRoomIndex() == GameConstants.SHOPROOM)
            {
                OldMan.Draw(spriteBatch);
                oldManText.Draw(spriteBatch);
                foreach (KeyValuePair<IItem, ItemText> x in shopItems)
                {
                    x.Value.Draw(spriteBatch);
                }
            }
            else oldManText.Reset();
        }

        public void SetUpShop()
        {
            UpdateItems();
            List<IItem> itemList = new List<IItem>();
            foreach (KeyValuePair<IItem, ItemText> x in shopItems)
            {
                itemList.Add(x.Key);
            }
            game.SetItems(itemList);
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
            ItemText bombText = new ItemText(ShopConstants.BOMBCOST, dungeonSheet, bomb.GetLocationRectangle());
            shopItems.Add(bomb, bombText);

            foreach(IItem item in linkInv.getLinkItems())
            {
                if(item is BoomerangItem)
                {
                    BlueBoomerangItem blueBoomerang = new BlueBoomerangItem(new Rectangle(75 * GameConstants.SCALE, 110 * GameConstants.SCALE, 7 * GameConstants.SCALE, 15 * GameConstants.SCALE), new Rectangle(128, 16, 7, 15), itemSheet);
                    ItemText blueBoomerangText = new ItemText(ShopConstants.BLUEBOOMERANGCOST, dungeonSheet, blueBoomerang.GetLocationRectangle());
                    shopItems.Add(blueBoomerang, blueBoomerangText);
                }
                if (item is BowItem)
                {
                    BlueArrowItem blueArrow = new BlueArrowItem(new Rectangle(105 * GameConstants.SCALE, 110 * GameConstants.SCALE, 7 * GameConstants.SCALE, 15 * GameConstants.SCALE), new Rectangle(153, 16, 7, 15), itemSheet);
                    ItemText blueArrowText = new ItemText(ShopConstants.BLUEARROWCOST, dungeonSheet, blueArrow.GetLocationRectangle());
                    shopItems.Add(blueArrow, blueArrowText);
                }
            }
        }

        public Boolean IsShopAvailable()
        {
            return oldManText.isDone();
        }

        public Boolean IsShopCurrent()
        {
            return roomManager.getRoomIndex() == GameConstants.SHOPROOM;
        }

        public Boolean TryBuyItem(IItem item)
        {
            ItemText text;
            shopItems.TryGetValue(item, out text);
            Boolean ret = text.GetPrice() <= linkInv.getRupeeCount();
            if (ret)
            {
                linkInv.removeRupee(text.GetPrice());
                oldManText.ChangeText(2);
            } else
            {
                oldManText.ChangeText(3);
            }
            return ret;
        }

    }
}
