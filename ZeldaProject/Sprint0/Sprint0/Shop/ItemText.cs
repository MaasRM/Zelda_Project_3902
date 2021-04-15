using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class ItemText
    {
        private String price;
        private int length;
        private int xStartLoc;
        private int yStartLoc;
        private Texture2D letterSheet;

        public ItemText(int cost, Texture2D dungeonSheet, Rectangle itemloc)
        {
            price = "" + cost;
            letterSheet = dungeonSheet;
            length = 0;
            for (int i = cost; i != 0; i /= 10) length++;
            xStartLoc = itemloc.X - (ShopConstants.LETTERSIZE * GameConstants.SCALE * (length + 1))/2 + itemloc.Width/2;
            yStartLoc = itemloc.Y + itemloc.Height + (ShopConstants.LETTERSIZE * GameConstants.SCALE);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle(xStartLoc, yStartLoc, ShopConstants.LETTERSIZE * GameConstants.SCALE, ShopConstants.LETTERSIZE * GameConstants.SCALE);
            Rectangle source = new Rectangle(ShopConstants.DOLLARSIGNX, ShopConstants.DOLLARSIGNY, ShopConstants.LETTERSIZE, ShopConstants.LETTERSIZE);
            spriteBatch.Draw(letterSheet, destination, source, Color.White);
            for (int i = 0; i < length; i++)
            {
                destination = new Rectangle((xStartLoc + (ShopConstants.LETTERSIZE * GameConstants.SCALE * (i + 1))), yStartLoc, ShopConstants.LETTERSIZE * GameConstants.SCALE, ShopConstants.LETTERSIZE * GameConstants.SCALE);
                int digit = int.Parse(price[i] + "");
                source = new Rectangle(ShopConstants.numberSource[2 * digit], ShopConstants.numberSource[2 * digit + 1], ShopConstants.LETTERSIZE, ShopConstants.LETTERSIZE);
                spriteBatch.Draw(letterSheet, destination, source, Color.White);
            }
        }

        public int GetPrice()
        {
            return int.Parse(price);
        }
    }
}
