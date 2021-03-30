﻿using Microsoft.Xna.Framework;
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
            Rectangle inventorySource = new Rectangle(258, 12, 254, 54);
            Rectangle inventoryDestination = new Rectangle(0, 0, 256 * 4, 64 * 4);
            spriteBatch.Draw(inventoryBackground, inventoryDestination, inventorySource, Color.White);
            Rectangle swordSource = new Rectangle(555, 137, 7, 15);
            Rectangle swordDestination = new Rectangle(612, 106, 9 * 4, 20 * 4);
            spriteBatch.Draw(inventoryBackground, swordDestination, swordSource, Color.White);
            Rectangle counterSource = new Rectangle(519, 117, 7, 8);
            Rectangle rupeeCounterDestination = new Rectangle(388, 72, 8 * 4, 9 * 4);
            Rectangle keyCounterDestination = new Rectangle(388, 148, 8 * 4, 9 * 4);
            Rectangle bombCounterDestination = new Rectangle(388, 185, 8 * 4, 9 * 4);
            spriteBatch.Draw(inventoryBackground, rupeeCounterDestination, counterSource, Color.White);
            spriteBatch.Draw(inventoryBackground, keyCounterDestination, counterSource, Color.White);
            spriteBatch.Draw(inventoryBackground, bombCounterDestination, counterSource, Color.White);
            Rectangle baseMapSource = new Rectangle(519, 2, 63, 38);
            Rectangle baseMapDestination = new Rectangle(64, 34, 65 * 4, 47 * 4);
            spriteBatch.Draw(inventoryBackground, baseMapDestination, baseMapSource, Color.White);
            Rectangle levelSource = new Rectangle(584, 1, 63, 7);
            Rectangle levelDestination = new Rectangle(64, 34, 63 * 4, 8 * 4);
            spriteBatch.Draw(inventoryBackground, levelDestination, levelSource, Color.White);
            Rectangle levelNumberDestination = new Rectangle(256, 34, 8 * 4, 9 * 4);
            spriteBatch.Draw(inventoryBackground, levelNumberDestination, getNumberSourceRectangle(1), Color.White);
        }

        public Rectangle getNumberSourceRectangle(int n)
        {
            Rectangle source;
            if(n == 0)
            {
                source = new Rectangle(528, 117, 7, 8);
            }
            else if(n == 1)
            {
                source = new Rectangle(537, 117, 7, 8);
            }
            else if(n == 2)
            {
                source = new Rectangle(546, 117, 7, 8);
            }
            else if(n == 3)
            {
                source = new Rectangle(555, 117, 7, 8);
            }
            else if(n == 4)
            {
                source = new Rectangle(564, 117, 7, 8);
            }
            else if(n == 5)
            {
                source = new Rectangle(573, 117, 7, 8);
            }
            else if(n == 6)
            {
                source = new Rectangle(582, 117, 7, 8);
            }
            else if(n == 8)
            {
                source = new Rectangle(600, 117, 7, 8);
            }
            else
            {
                source = new Rectangle(609, 117, 7, 8);
            }
            return source;
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
