﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public enum DungeonMap
    {
        Left,
        Right,
        Top
    }
    public enum RupeeKeyBomb
    {
        RupeeOnes,
        RupeeTens,
        KeyOnes,
        KeyTens,
        BombOnes,
        BombTens
    }

    public class LinkInventory
    {
        private int keyCount;
        private int bombCount;
        private int rupeeCount;
        private int currentItemIndex;
        private DungeonMap theMap;
        
        private List<IItem> linkItems;
        private Texture2D inventoryBackground;
        public LinkMinimap linkMinimap { get; set; }
        public LinkPauseScreen pauseScreen { get; set; }
        public LinkHealthBar healthBar { get; set; }
        public IItem currentItem { get; set; }
        public LinkSword sword { get; set; }
        public LinkTriForceShards shards { get; set; }
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public LinkInventory(Texture2D background)
        {
            keyCount = 0;
            bombCount = 0;
            rupeeCount = 0;
            linkItems = new List<IItem>();
            sword = new LinkSword(new BrownSwordItem(new Rectangle(), new Rectangle(555, 137, 7, 16), background));
            shards = new LinkTriForceShards();
            currentItem = null;
            currentItemIndex = 0;
            inventoryBackground = background;
            linkMinimap = new LinkMinimap(inventoryBackground);
            healthBar = new LinkHealthBar(inventoryBackground);
            pauseScreen = new LinkPauseScreen(inventoryBackground, linkItems);
            theMap = DungeonMap.Top;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            theMap = linkMinimap.getDungeonMap();
            if (pauseScreen.isGamePaused() == false) {
                int offset = pauseScreen.getCurrentYOffset();
                if (offset > 0) {
                    pauseScreen.decrementOffset();
                    pauseScreen.Draw(spriteBatch, currentItemIndex, theMap);
                }
                Rectangle inventorySource = new Rectangle(258, 12, 254, 54);
                Rectangle inventoryDestination = new Rectangle(0, 0 + offset, 256 * GameConstants.SCALE, 64 * GameConstants.SCALE);
                spriteBatch.Draw(inventoryBackground, inventoryDestination, inventorySource, Color.White);
                Rectangle swordDestination = new Rectangle(612, 106 + offset, 9 * GameConstants.SCALE, 20 * GameConstants.SCALE);
                sword.Draw(spriteBatch, swordDestination);
                Rectangle counterSource = new Rectangle(519, 117, 7, 8);
                Rectangle rupeeCounterDestination = new Rectangle(388, 72 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE);
                Rectangle keyCounterDestination = new Rectangle(388, 148 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE);
                Rectangle bombCounterDestination = new Rectangle(388, 185 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE);
                spriteBatch.Draw(inventoryBackground, rupeeCounterDestination, counterSource, Color.White);
                spriteBatch.Draw(inventoryBackground, keyCounterDestination, counterSource, Color.White);
                spriteBatch.Draw(inventoryBackground, bombCounterDestination, counterSource, Color.White);
                Rectangle baseMapSource = new Rectangle(519, 2, 63, 38);
                Rectangle baseMapDestination = new Rectangle(64, 34 + offset, 65 * GameConstants.SCALE, 47 * GameConstants.SCALE);
                spriteBatch.Draw(inventoryBackground, baseMapDestination, baseMapSource, Color.White);
                Rectangle levelSource = new Rectangle(584, 1, 63, 7);
                Rectangle levelDestination = new Rectangle(64, 34 + offset, 63 * GameConstants.SCALE, 8 * GameConstants.SCALE);
                spriteBatch.Draw(inventoryBackground, levelDestination, levelSource, Color.White);
                Rectangle levelNumberDestination = new Rectangle(256, 34 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE);
                if (theMap == DungeonMap.Top) { spriteBatch.Draw(inventoryBackground, levelNumberDestination, getNumberSourceRectangle(1), Color.White); }
                else if (theMap == DungeonMap.Left) { spriteBatch.Draw(inventoryBackground, levelNumberDestination, getNumberSourceRectangle(2), Color.White); }
                else if (theMap == DungeonMap.Right) { spriteBatch.Draw(inventoryBackground, levelNumberDestination, getNumberSourceRectangle(3), Color.White); }
                DrawItemCounts(spriteBatch);
                DrawSecondaryWeapon(spriteBatch, new Rectangle(514, 106 + offset, 9 * GameConstants.SCALE, 20 * GameConstants.SCALE));
                linkMinimap.Draw(spriteBatch, offset);
                healthBar.Draw(spriteBatch, offset);
            } else DrawPause(spriteBatch);
        }

        public void DrawPause(SpriteBatch spriteBatch)
        {
            theMap = linkMinimap.getDungeonMap();
            int offset = pauseScreen.getCurrentYOffset();
            pauseScreen.Draw(spriteBatch, currentItemIndex, theMap);
            Rectangle inventorySource = new Rectangle(258, 12, 254, 54);
            Rectangle inventoryDestination = new Rectangle(0, 0 + offset, 256 * GameConstants.SCALE, 64 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, inventoryDestination, inventorySource, Color.White);
            Rectangle swordDestination = new Rectangle(612, 106 + offset, 9 * GameConstants.SCALE, 20 * GameConstants.SCALE);
            sword.Draw(spriteBatch, swordDestination);
            Rectangle counterSource = new Rectangle(519, 117, 7, 8);
            Rectangle rupeeCounterDestination = new Rectangle(388, 72 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE);
            Rectangle keyCounterDestination = new Rectangle(388, 148 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE);
            Rectangle bombCounterDestination = new Rectangle(388, 185 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, rupeeCounterDestination, counterSource, Color.White);
            spriteBatch.Draw(inventoryBackground, keyCounterDestination, counterSource, Color.White);
            spriteBatch.Draw(inventoryBackground, bombCounterDestination, counterSource, Color.White);
            Rectangle baseMapSource = new Rectangle(519, 2, 63, 38);
            Rectangle baseMapDestination = new Rectangle(64, 34 + offset, 65 * GameConstants.SCALE, 47 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, baseMapDestination, baseMapSource, Color.White);
            Rectangle levelSource = new Rectangle(584, 1, 63, 7);
            Rectangle levelDestination = new Rectangle(64, 34 + offset, 63 * GameConstants.SCALE, 8 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, levelDestination, levelSource, Color.White);
            Rectangle levelNumberDestination = new Rectangle(256, 34 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE);
            if (theMap == DungeonMap.Top) { spriteBatch.Draw(inventoryBackground, levelNumberDestination, getNumberSourceRectangle(1), Color.White); }
            else if (theMap == DungeonMap.Left) { spriteBatch.Draw(inventoryBackground, levelNumberDestination, getNumberSourceRectangle(2), Color.White); }
            else if (theMap == DungeonMap.Right) { spriteBatch.Draw(inventoryBackground, levelNumberDestination, getNumberSourceRectangle(3), Color.White); }
            DrawItemCounts(spriteBatch);
            DrawSecondaryWeapon(spriteBatch, new Rectangle(514, 106 + offset, 9 * GameConstants.SCALE, 20 * GameConstants.SCALE));
            linkMinimap.Draw(spriteBatch, offset);
            healthBar.Draw(spriteBatch, offset);
            if (pauseScreen.getCurrentYOffset() < 700) {
                pauseScreen.incrementOffset();
            }

        }

        public void DrawItemCounts(SpriteBatch spriteBatch)
        {
            int offset = pauseScreen.getCurrentYOffset();
            if (rupeeCount >= 10)
            {
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.RupeeOnes, offset), getNumberSourceRectangle(rupeeCount % 10), Color.White);
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.RupeeTens, offset), getNumberSourceRectangle(rupeeCount / 10), Color.White);
            }
            else
            {
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.RupeeOnes, offset), getNumberSourceRectangle(rupeeCount), Color.White);
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.RupeeTens, offset), getNumberSourceRectangle(0), Color.White);
            }
            if (keyCount >= 10)
            {
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.KeyOnes, offset), getNumberSourceRectangle(keyCount % 10), Color.White);
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.KeyTens, offset), getNumberSourceRectangle(keyCount / 10), Color.White);
            }
            else
            {
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.KeyOnes, offset), getNumberSourceRectangle(keyCount), Color.White);
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.KeyTens, offset), getNumberSourceRectangle(0), Color.White);
            }
            if (bombCount >= 10)
            {
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.BombOnes, offset), getNumberSourceRectangle(bombCount % 10), Color.White);
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.BombTens, offset), getNumberSourceRectangle(bombCount / 10), Color.White);
            }
            else
            {
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.BombOnes, offset), getNumberSourceRectangle(bombCount), Color.White);
                spriteBatch.Draw(inventoryBackground, getTheItemCountDestination(RupeeKeyBomb.BombTens, offset), getNumberSourceRectangle(0), Color.White);
            }
        }

        public Rectangle getTheItemCountDestination(RupeeKeyBomb theCount, int offset)
        {
            Rectangle retRectangle = new Rectangle(0, 0, 0, 0);
            if (theCount == RupeeKeyBomb.RupeeOnes) { retRectangle = new Rectangle(452, 72 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE); }
            else if (theCount == RupeeKeyBomb.RupeeTens) { retRectangle = new Rectangle(420, 72 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE); }
            else if (theCount == RupeeKeyBomb.KeyOnes) { retRectangle = new Rectangle(452, 148 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE); }
            else if (theCount == RupeeKeyBomb.KeyTens) { retRectangle = new Rectangle(420, 148 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE); }
            else if (theCount == RupeeKeyBomb.BombOnes) { retRectangle = new Rectangle(452, 185 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE); }
            else if (theCount == RupeeKeyBomb.BombTens) { retRectangle = new Rectangle(420, 185 + offset, 8 * GameConstants.SCALE, 9 * GameConstants.SCALE); }
            return retRectangle;
        }

        public void changeCurrentItem(Direction direction)
        {
            if (direction == Direction.Left)
            {
                incrementCurrentItem(-1);
            }
            else if (direction == Direction.Right)
            {
                incrementCurrentItem(1);
            }
            else if (direction == Direction.Up)
            {
                incrementCurrentItem(-4);
            }
            else if (direction == Direction.Down)
            {
                incrementCurrentItem(4);
            }
        }

        public void incrementCurrentItem(int num)
        {
            int size = linkItems.Count;
            if (num < 0 && currentItemIndex == 0) { }
            else if (num < 0 && currentItemIndex > 0)
            {
                if (num == -4)
                {
                    if (size <= currentItemIndex + num)
                    {
                        currentItem = linkItems[currentItemIndex - 4];
                        currentItemIndex -= 4;
                    }
                }
                else
                {
                    currentItemIndex--;
                    currentItem = linkItems[currentItemIndex];
                }
            }
            else if (num > 0 && size > 0 && currentItemIndex < size)
            {
                if (num == 4)
                {
                    if (size > currentItemIndex + num)
                    {
                        currentItem = linkItems[currentItemIndex + 4];
                        currentItemIndex += 4;
                    }
                }
                else
                {
                    if (size > currentItemIndex + num)
                    {
                        currentItemIndex++;
                        currentItem = linkItems[currentItemIndex];
                    }
                }
            }
        }

        public void DrawSecondaryWeapon(SpriteBatch spriteBatch, Rectangle secondaryWeapon)
        {
            Rectangle itemSource = new Rectangle(530, 16, 1, 1);

            if (currentItem is BoomerangItem)
            {
                itemSource = new Rectangle(584, 137, 8, 16);
            }
            else if (currentItem is BowItem || currentItem is BlueArrowItem)
            {
                itemSource = new Rectangle(633, 137, 8, 16);
            }
            else if (currentItem is BombItem)
            {
                itemSource = new Rectangle(604, 137, 8, 16);
            }
            else if (currentItem is CandleItem)
            {
                itemSource = new Rectangle(653, 137, 8, 16);
            }
            else if (currentItem is BlueBoomerangItem)
            {
                itemSource = new Rectangle(593, 137, 8, 16);
            }

            pauseScreen.DrawSecondaryWeapon(spriteBatch, itemSource);
            spriteBatch.Draw(inventoryBackground, secondaryWeapon, itemSource, Color.White);
        }

        public Rectangle getNumberSourceRectangle(int n)
        {
            Rectangle source;
            if(n == 0) { source = new Rectangle(528, 117, 7, 8); }
            else if(n == 1) { source = new Rectangle(537, 117, 7, 8); }
            else if(n == 2) { source = new Rectangle(546, 117, 7, 8); }
            else if(n == 3) { source = new Rectangle(555, 117, 7, 8); }
            else if(n == 4) { source = new Rectangle(564, 117, 7, 8); }
            else if(n == 5) { source = new Rectangle(573, 117, 7, 8); }
            else if(n == 6) { source = new Rectangle(582, 117, 7, 8); }
            else if(n == 8) { source = new Rectangle(600, 117, 7, 8); }
            else { source = new Rectangle(609, 117, 7, 8); }
            return source;
        }

        public void addItem(IItem item)
        {
            int check = 0;
            if (item is BoomerangItem || item is BowItem || item is BlueArrowItem || item is BombItem || item is BlueBoomerangItem || item is CandleItem)
            {
                if (linkItems.Count == 0)
                {
                    currentItem = item;
                    currentItemIndex = 0;
                    linkItems.Add(item);
                }
                else
                {
                    foreach (IItem checkItem in linkItems) { if (checkItem.GetType() == item.GetType()) { check++; } }
                    if (check == 0) { linkItems.Add(item); }
                }
            }
            else if (item is BlueSwordItem || item is MagicSwordItem) sword.setSword(item);
            else if (item is TriforceShardItem) shards.addShard(item);
            pauseScreen.updateLinkItemList(linkItems);
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

        public int getRupeeCount()
        {
            return rupeeCount;
        }

        public void ChangeRupee(int num)
        {
            rupeeCount += num;
            if (rupeeCount > LinkConstants.MAXRUPEECOUNT) rupeeCount = LinkConstants.MAXRUPEECOUNT;
        }

        public void addBomb()
        {
            bombCount++;
        }

        public void removeBomb()
        {
            int check = -1;
            bombCount--;
            foreach (IItem item in linkItems)
            {
                if (item is BombItem)
                {
                    check = linkItems.IndexOf(item);
                }
            }
            if (check >= 0)
            {
                linkItems.RemoveAt(check);
            }
        }

        public bool hasBombs()
        {
            return bombCount > 0;
        }

        public List<IItem> getLinkItems()
        {
            return linkItems;
        }

        public LinkSword getLinkSword()
        {
            return sword;
        }

        public void removeLinkItem(IItem itemToRemove)
        {
            int check = -1;
            foreach (IItem item in linkItems)
            {
                if (item.GetType() == itemToRemove.GetType())
                {
                    check = linkItems.IndexOf(item);
                }
            }
            if (check >= 0)
            {
                linkItems.RemoveAt(check);
            }
        }
    }
}
