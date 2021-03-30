using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkInventory
    {
        private int keyCount;
        private int bombCount;
        private int rupeeCount;
        private List<IItem> linkItems;
        private IItem currentItem;
        private Texture2D inventoryBackground;

        public LinkInventory(Texture2D background)
        {
            keyCount = 0;
            bombCount = 0;
            rupeeCount = 0;
            linkItems = new List<IItem>();
            currentItem = null;
            inventoryBackground = background;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle inventorySource = new Rectangle(258,12, 254, 54);
            Rectangle inventoryDestination = new Rectangle(0, 0, 256 * 4, 56 * 4);
            spriteBatch.Draw(inventoryBackground, inventoryDestination, inventorySource, Color.White);
        }

        public void addItem(IItem item)
        {
            if(linkItems.Count == 0)
            {
                currentItem = item;
            }
            linkItems.Add(item);
        }

        public void addKey()
        {
            keyCount++;
        }

        public void removeKey()
        {
            keyCount--;
        }

        public int getKeyCount()
        {
            return keyCount;
        }

        public void addBomb()
        {
            bombCount++;
        }

        public void removeBomb()
        {
            bombCount--;
        }

        public int getBombCount()
        {
            return bombCount;
        }

        public void addRupee(int num)
        {
            rupeeCount += num;
        }

        public void removeRupee(int num)
        {
            rupeeCount -= num;
        }

        public int getRupeeCount()
        {
            return rupeeCount;
        }
    }
}
