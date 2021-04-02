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
        private LinkMinimap minimap;
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
            minimap = new LinkMinimap(inventoryBackground);
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
            DrawItemCounts(spriteBatch);
            DrawSecondaryWeapon(spriteBatch);
            minimap.Draw(spriteBatch);
        }

        public void DrawItemCounts(SpriteBatch spriteBatch)
        {
            Rectangle rupeeCountDestination = new Rectangle(452, 72, 8 * 4, 9 * 4);
            Rectangle keyCountDestination = new Rectangle(452, 148, 8 * 4, 9 * 4);
            Rectangle bombCountDestination = new Rectangle(452, 185, 8 * 4, 9 * 4);

            if (rupeeCount >= 10)
            {
                spriteBatch.Draw(inventoryBackground, rupeeCountDestination, getNumberSourceRectangle(rupeeCount % 10), Color.White);
                rupeeCountDestination = new Rectangle(420, 72, 8 * 4, 9 * 4);
                spriteBatch.Draw(inventoryBackground, rupeeCountDestination, getNumberSourceRectangle(rupeeCount / 10), Color.White);
            }
            else
            {
                spriteBatch.Draw(inventoryBackground, rupeeCountDestination, getNumberSourceRectangle(rupeeCount), Color.White);
                rupeeCountDestination = new Rectangle(420, 72, 8 * 4, 9 * 4);
                spriteBatch.Draw(inventoryBackground, rupeeCountDestination, getNumberSourceRectangle(0), Color.White);
            }

            if (keyCount >= 10)
            {
                spriteBatch.Draw(inventoryBackground, keyCountDestination, getNumberSourceRectangle(keyCount % 10), Color.White);
                keyCountDestination = new Rectangle(420, 148, 8 * 4, 9 * 4);
                spriteBatch.Draw(inventoryBackground, keyCountDestination, getNumberSourceRectangle(keyCount / 10), Color.White);
            }
            else
            {
                spriteBatch.Draw(inventoryBackground, keyCountDestination, getNumberSourceRectangle(keyCount), Color.White);
                keyCountDestination = new Rectangle(420, 148, 8 * 4, 9 * 4);
                spriteBatch.Draw(inventoryBackground, keyCountDestination, getNumberSourceRectangle(0), Color.White);
            }

            if (bombCount >= 10)
            {
                spriteBatch.Draw(inventoryBackground, bombCountDestination, getNumberSourceRectangle(bombCount % 10), Color.White);
                bombCountDestination = new Rectangle(420, 185, 8 * 4, 9 * 4);
                spriteBatch.Draw(inventoryBackground, bombCountDestination, getNumberSourceRectangle(bombCount / 10), Color.White);
            }
            else
            {
                spriteBatch.Draw(inventoryBackground, bombCountDestination, getNumberSourceRectangle(bombCount), Color.White);
                bombCountDestination = new Rectangle(420, 185, 8 * 4, 9 * 4);
                spriteBatch.Draw(inventoryBackground, bombCountDestination, getNumberSourceRectangle(0), Color.White);
            }

        }

        public void DrawSecondaryWeapon(SpriteBatch spriteBatch)
        {
            Rectangle secondaryWeaponDestination = new Rectangle(514, 106, 9 * 4, 20 * 4);
            Rectangle itemSource = new Rectangle(545, 145, 1, 1);

            if (currentItem is BoomerangItem)
            {
                itemSource = new Rectangle(584, 137, 7, 15);
            }
            else if (currentItem is BowItem)
            {
                itemSource = new Rectangle(633, 137, 7, 15);
            }
            else if (currentItem is BombItem)
            {
                itemSource = new Rectangle(604, 137, 7, 15);
            }

            spriteBatch.Draw(inventoryBackground, secondaryWeaponDestination, itemSource, Color.White);
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
            if (item is BoomerangItem || item is BowItem || item is BombItem)
            {
                if (linkItems.Count == 0)
                {
                    currentItem = item;
                }
                linkItems.Add(item);
            }
        }

        public LinkMinimap GetLinkMinimap()
        {
            return minimap;
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
