using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Shop
{
    class Shop
    {
        INPC OldMan;
        ShopText oldManText;
        LinkInventory linkInv;
        List<IItem> shopItems;
        List<ItemText> itemPrices;
        //sword upgrade, bombs, blue arrow/boomerang upgrade, armor/color upgrade

        public Shop(LinkInventory inv, Texture2D npcSheet)
        {
            OldMan = new OldMan(100, 100, npcSheet);
            oldManText = new ShopText();
            linkInv = inv;
            shopItems = new List<IItem>();
            itemPrices = new List<ItemText>();
        }

        public void setUpShop()
        {

        }

        public void Update()
        {
             
        }

        public void Draw()
        {

        }

    }
}
