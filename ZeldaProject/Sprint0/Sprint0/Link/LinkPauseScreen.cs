using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkPauseScreen
    {
        private Texture2D inventoryBackground;
        private bool isPaused;
        private int currentYOffset;
        private static int incrementYSize = 10;
        private Rectangle pauseTopSourceRectangle;
        private Rectangle pauseBottomSourceRectangle;
        private bool hasMap;
        private bool hasCompass;
        private int bossFrames;
        private List<IItem> linkItems;

        public LinkPauseScreen(Texture2D background, List<IItem> items)
        {
            isPaused = false;
            inventoryBackground = background;
            currentYOffset = 0;
            pauseTopSourceRectangle = new Rectangle(1, 12, 255, 87);
            pauseBottomSourceRectangle = new Rectangle(258, 113, 255, 87);
            hasMap = false;
            hasCompass = false;
            bossFrames = 0;
            linkItems = items;
        }

        public void Draw(SpriteBatch spriteBatch, int currentItemIndex, DungeonMap theMap)
        {
            Rectangle blackSpaceSource = new Rectangle(280, 30, 1, 1);
            Rectangle blackSpaceDestination = new Rectangle(0, -700 + currentYOffset, 256 * GameConstants.SCALE, 200 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, blackSpaceDestination, blackSpaceSource, Color.White);
            Rectangle pauseTopDestination = new Rectangle(0, -700 + currentYOffset, 256 * GameConstants.SCALE, 64 * GameConstants.SCALE);
            Rectangle pauseBottomDestination = new Rectangle(0, -352 + currentYOffset, 256 * GameConstants.SCALE, 64 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, pauseTopDestination, pauseTopSourceRectangle, Color.White);
            spriteBatch.Draw(inventoryBackground, pauseBottomDestination, pauseBottomSourceRectangle, Color.White);
            if (hasMap) { DrawPauseMap(spriteBatch, theMap); }
            if (hasCompass) { DrawPauseCompass(spriteBatch, theMap); }
            DrawInventoryItems(spriteBatch, currentItemIndex);
        }

        public void DrawInventoryItems(SpriteBatch spriteBatch, int currentItemIndex)
        {
            int currentX = 530;
            int currentY = -560 + currentYOffset;
            int displacement = 1;
            //700 - 188
            foreach (IItem item in linkItems)
            {
                Rectangle inventoryDestination = new Rectangle(currentX, currentY, 7 * GameConstants.SCALE, 45);
                spriteBatch.Draw(inventoryBackground, inventoryDestination, getInventoryItemSource(item), Color.White);
                if (currentItemIndex == linkItems.IndexOf(item))
                {
                    Rectangle currentWeaponSelectorDestination = new Rectangle(currentX - 16, currentY - 8, 14 * GameConstants.SCALE, 14 * GameConstants.SCALE);
                    Rectangle selectorSource = new Rectangle(519, 137, 16, 16);
                    spriteBatch.Draw(inventoryBackground, currentWeaponSelectorDestination, selectorSource, Color.White);
                }
                currentX += 24 * GameConstants.SCALE;
                if (displacement % 4 == 0)
                {
                    currentY += 46;
                    currentX = 530;
                    displacement = 1;
                }
                displacement++;
            }
        }

        public void DrawSecondaryWeapon(SpriteBatch spriteBatch, Rectangle itemSource)
        {
            Rectangle secondaryInventoryDestination = new Rectangle(280, -570 + currentYOffset, 7 * GameConstants.SCALE, 16 * GameConstants.SCALE);
            //700 - 130
            spriteBatch.Draw(inventoryBackground, secondaryInventoryDestination, itemSource, Color.White);
        }

        public Rectangle getInventoryItemSource(IItem item)
        {
            Rectangle itemSource = new Rectangle(23, 70, 1, 1);

            if (item is BoomerangItem)
            {
                itemSource = new Rectangle(584, 137, 8, 16);
            }
            else if (item is BowItem || item is BlueArrowItem)
            {
                itemSource = new Rectangle(633, 137, 8, 16);
            }
            else if (item is BombItem)
            {
                itemSource = new Rectangle(604, 137, 8, 16);
            }
            else if (item is BlueBoomerangItem)
            {
                itemSource = new Rectangle(593, 137, 8, 16);
            }
            else if (item is CandleItem)
            {
                itemSource = new Rectangle(653, 137, 8, 16);
            }
            else if (item is RecorderItem)
            {
                itemSource = new Rectangle(664, 137, 8, 16);
            }

            return itemSource;
        }

        public void DrawPauseMap(SpriteBatch spriteBatch, DungeonMap theMap)
        {
            Rectangle mapSource = new Rectangle(601, 156, 7, 16);
            Rectangle mapDestination = new Rectangle(190, -300 + currentYOffset, 7 * GameConstants.SCALE, 16 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, mapDestination, mapSource, Color.White);
            if (theMap == DungeonMap.Top) {
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(0), new Rectangle(528, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(1), new Rectangle(573, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(2), new Rectangle(627, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(3), new Rectangle(564, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(4), new Rectangle(537, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(5), new Rectangle(528, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(6), new Rectangle(582, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(7), new Rectangle(618, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(8), new Rectangle(546, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(9), new Rectangle(609, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(10), new Rectangle(600, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(11), new Rectangle(582, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(12), new Rectangle(537, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(13), new Rectangle(627, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(14), new Rectangle(564, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(15), new Rectangle(618, 108, 8, 8), Color.White);
                spriteBatch.Draw(inventoryBackground, getTopRoomDestination(16), new Rectangle(573, 108, 8, 8), Color.White);
            }
            else if (theMap == DungeonMap.Left) {
                DrawLeftPauseMap(spriteBatch);
            }
            else if (theMap == DungeonMap.Right) {
                DrawRightPauseMap(spriteBatch);
            }
        }

        public void DrawLeftPauseMap(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(0), new Rectangle(555, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(1), new Rectangle(564, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(2), new Rectangle(645, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(3), new Rectangle(627, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(4), new Rectangle(636, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(5), new Rectangle(645, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(6), new Rectangle(600, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(7), new Rectangle(546, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(8), new Rectangle(654, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(9), new Rectangle(609, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getLeftRoomDestination(10), new Rectangle(591, 108, 8, 8), Color.White);
        }

        public void DrawRightPauseMap(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(0), new Rectangle(636, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(1), new Rectangle(573, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(2), new Rectangle(600, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(3), new Rectangle(645, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(4), new Rectangle(555, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(5), new Rectangle(627, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(6), new Rectangle(618, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(7), new Rectangle(528, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(8), new Rectangle(618, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(9), new Rectangle(546, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRightRoomDestination(10), new Rectangle(609, 108, 8, 8), Color.White);
        }

        public void DrawPauseCompass(SpriteBatch spriteBatch, DungeonMap theMap)
        {
            Rectangle compassSource = new Rectangle(612, 156, 14, 16);
            Rectangle compassDestination = new Rectangle(175, -180 + currentYOffset, 14 * GameConstants.SCALE, 16 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, compassDestination, compassSource, Color.White);
            Rectangle bossRoomSourceRed = new Rectangle(537, 126, 2, 2);
            Rectangle bossRoomSourceBlue = new Rectangle(555, 127, 2, 2);
            Rectangle bossRoomDestination = new Rectangle(684, -287 + currentYOffset, 2 * GameConstants.SCALE, 2 * GameConstants.SCALE);
            if (theMap == DungeonMap.Left) { bossRoomDestination = new Rectangle(590, -257 + currentYOffset, 2 * GameConstants.SCALE, 2 * GameConstants.SCALE); }
            else if (theMap == DungeonMap.Right) { bossRoomDestination = new Rectangle(684, -223 + currentYOffset, 2 * GameConstants.SCALE, 2 * GameConstants.SCALE); }
            if (bossFrames %2 == 0)
            {
                spriteBatch.Draw(inventoryBackground, bossRoomDestination, bossRoomSourceRed, Color.White);
            }
            else
            {
                spriteBatch.Draw(inventoryBackground, bossRoomDestination, bossRoomSourceBlue, Color.White);
            }
            bossFrames++;
        }

        public Rectangle getTopRoomDestination(int i)
        {
            Rectangle mapRoomDestination;
            if (i == 0) { mapRoomDestination = new Rectangle(578, -330 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 1) { mapRoomDestination = new Rectangle(610, -330 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 2) { mapRoomDestination = new Rectangle(610, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 3) { mapRoomDestination = new Rectangle(672, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 4) { mapRoomDestination = new Rectangle(706, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 5) { mapRoomDestination = new Rectangle(546, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 6) { mapRoomDestination = new Rectangle(578, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 7) { mapRoomDestination = new Rectangle(610, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 8) { mapRoomDestination = new Rectangle(642, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 9) { mapRoomDestination = new Rectangle(672, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 10) { mapRoomDestination = new Rectangle(578, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 11) { mapRoomDestination = new Rectangle(610, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 12) { mapRoomDestination = new Rectangle(642, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 13) { mapRoomDestination = new Rectangle(610, -202 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 14) { mapRoomDestination = new Rectangle(578, -170 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 15) { mapRoomDestination = new Rectangle(610, -170 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else { mapRoomDestination = new Rectangle(642, -170 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            return mapRoomDestination;
        }

        public Rectangle getLeftRoomDestination(int i)
        {
            Rectangle mapRoomDestination;
            if (i == 0) { mapRoomDestination = new Rectangle(578, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 1) { mapRoomDestination = new Rectangle(640, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 2) { mapRoomDestination = new Rectangle(672, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 3) { mapRoomDestination = new Rectangle(578, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 4) { mapRoomDestination = new Rectangle(640, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 5) { mapRoomDestination = new Rectangle(672, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 6) { mapRoomDestination = new Rectangle(578, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 7) { mapRoomDestination = new Rectangle(610, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 8) { mapRoomDestination = new Rectangle(640, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 9) { mapRoomDestination = new Rectangle(672, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else { mapRoomDestination = new Rectangle(640, -202 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            return mapRoomDestination;
        }

        public Rectangle getRightRoomDestination(int i)
        {
            Rectangle mapRoomDestination;
            if (i == 0) { mapRoomDestination = new Rectangle(578, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 1) { mapRoomDestination = new Rectangle(610, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 2) { mapRoomDestination = new Rectangle(578, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 3) { mapRoomDestination = new Rectangle(610, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 4) { mapRoomDestination = new Rectangle(672, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 5) { mapRoomDestination = new Rectangle(610, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 6) { mapRoomDestination = new Rectangle(672, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 7) { mapRoomDestination = new Rectangle(578, -202 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 8) { mapRoomDestination = new Rectangle(610, -202 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 9) { mapRoomDestination = new Rectangle(640, -202 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else { mapRoomDestination = new Rectangle(672, -202 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            return mapRoomDestination;
        }

        public void setGamePaused(bool val)
        {
            isPaused = val;
        }

        public void setMap(bool val)
        {
            hasMap = val;
        }

        public void setCompass(bool val)
        {
            hasCompass = val;
        }

        public void updateLinkItemList(List<IItem> items)
        {
            linkItems = items;
        }

        public int getCurrentYOffset()
        {
            return currentYOffset;
        }

        public void incrementOffset()
        {
            currentYOffset += incrementYSize;
        }

        public void decrementOffset()
        {
            currentYOffset -= incrementYSize;
        }

        public bool isGamePaused()
        {
            return isPaused;
        }
    }
}
