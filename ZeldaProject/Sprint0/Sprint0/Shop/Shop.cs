using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class Shop
    {
        INPC OldMan;
        ShopText oldManText;
        LinkInventory linkInv;
        List<IItem> shopItems;
        List<ItemText> itemPrices;
        RoomManager roomManager;
        //sword upgrade, bombs, blue arrow/boomerang upgrade, armor/color upgrade

        public Shop(LinkInventory inv, Texture2D npcSheet, Texture2D dungeonSheet, RoomManager manager, Sprint4 game)
        {
            OldMan = new OldMan(45 * GameConstants.SCALE, 185 * GameConstants.SCALE, npcSheet);
            oldManText = new ShopText(dungeonSheet, game);
            linkInv = inv;
            shopItems = new List<IItem>();
            itemPrices = new List<ItemText>();
            roomManager = manager;
        }

        public void Update()
        {
            if (roomManager.getRoomIndex() == GameConstants.SHOPROOM)
            {
                UpdateItems();
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
                    //x.draw(spriteBatch);
                }
            }
            else oldManText.Reset();
        }

        public void UpdateItems()
        {

        }

    }
}
