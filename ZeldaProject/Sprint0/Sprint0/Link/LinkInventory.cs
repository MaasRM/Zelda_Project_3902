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

        public LinkInventory()
        {
            keyCount = 0;
            bombCount = 0;
            rupeeCount = 0;
            linkItems = new List<IItem>();
            currentItem = null;
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

        public void addRupee()
        {
            rupeeCount++;
        }

        public void removeRupee()
        {
            rupeeCount--;
        }

        public int getRupeeCount()
        {
            return rupeeCount;
        }
    }
}
