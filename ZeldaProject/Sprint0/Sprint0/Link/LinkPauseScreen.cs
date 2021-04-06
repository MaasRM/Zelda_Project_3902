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
        private Boolean isPaused;
        private int currentYOffset;
        private static int incrementYSize = 10;
        private Rectangle pauseTopSourceRectangle;
        private Rectangle pauseBottomSourceRectangle;
        private Boolean hasMap;
        private Boolean hasCompass;
        private int bossFrames;

        public LinkPauseScreen(Texture2D background)
        {
            isPaused = false;
            inventoryBackground = background;
            currentYOffset = 0;
            pauseTopSourceRectangle = new Rectangle(1, 12, 255, 87);
            pauseBottomSourceRectangle = new Rectangle(258, 113, 255, 87);
            hasMap = false;
            hasCompass = false;
            bossFrames = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle blackSpaceSource = new Rectangle(280, 30, 1, 1);
            Rectangle blackSpaceDestination = new Rectangle(0, -700 + currentYOffset, 256 * GameConstants.SCALE, 200 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, blackSpaceDestination, blackSpaceSource, Color.White);
            Rectangle pauseTopDestination = new Rectangle(0, -700 + currentYOffset, 256 * GameConstants.SCALE, 64 * GameConstants.SCALE);
            Rectangle pauseBottomDestination = new Rectangle(0, -352 + currentYOffset, 256 * GameConstants.SCALE, 64 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, pauseTopDestination, pauseTopSourceRectangle, Color.White);
            spriteBatch.Draw(inventoryBackground, pauseBottomDestination, pauseBottomSourceRectangle, Color.White);
            if (hasMap) { DrawPauseMap(spriteBatch); }
            if (hasCompass) { DrawPauseCompass(spriteBatch); }
            
        }

        public void DrawPauseMap(SpriteBatch spriteBatch)
        {
            Rectangle mapSource = new Rectangle(601, 156, 7, 16);
            Rectangle mapDestination = new Rectangle(190, -300 + currentYOffset, 7 * GameConstants.SCALE, 16 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, mapDestination, mapSource, Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(0), new Rectangle(528, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(1), new Rectangle(573, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(2), new Rectangle(627, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(3), new Rectangle(564, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(4), new Rectangle(537, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(5), new Rectangle(528, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(6), new Rectangle(582, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(7), new Rectangle(618, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(8), new Rectangle(546, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(9), new Rectangle(609, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(10), new Rectangle(600, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(11), new Rectangle(582, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(12), new Rectangle(537, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(13), new Rectangle(627, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(14), new Rectangle(528, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(15), new Rectangle(618, 108, 8, 8), Color.White);
            spriteBatch.Draw(inventoryBackground, getRoomDestination(16), new Rectangle(537, 108, 8, 8), Color.White);
        }

        public void DrawPauseCompass(SpriteBatch spriteBatch)
        {
            Rectangle compassSource = new Rectangle(612, 156, 14, 16);
            Rectangle compassDestination = new Rectangle(175, -180 + currentYOffset, 14 * GameConstants.SCALE, 16 * GameConstants.SCALE);
            spriteBatch.Draw(inventoryBackground, compassDestination, compassSource, Color.White);
            Rectangle bossRoomSourceRed = new Rectangle(537, 126, 2, 2);
            Rectangle bossRoomSourceBlue = new Rectangle(555, 127, 2, 2);
            Rectangle bossRoomDestination = new Rectangle(686, -287 + currentYOffset, 2 * GameConstants.SCALE, 2 * GameConstants.SCALE);
            if(bossFrames %2 == 0)
            {
                spriteBatch.Draw(inventoryBackground, bossRoomDestination, bossRoomSourceRed, Color.White);
            }
            else
            {
                spriteBatch.Draw(inventoryBackground, bossRoomDestination, bossRoomSourceBlue, Color.White);
            }
            bossFrames++;
        }

        public Rectangle getRoomDestination(int i)
        {
            Rectangle mapRoomDestination;
            if (i == 0) { mapRoomDestination = new Rectangle(578, -330 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 1) { mapRoomDestination = new Rectangle(610, -330 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 2) { mapRoomDestination = new Rectangle(610, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 3) { mapRoomDestination = new Rectangle(674, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 4) { mapRoomDestination = new Rectangle(706, -298 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 5) { mapRoomDestination = new Rectangle(546, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 6) { mapRoomDestination = new Rectangle(578, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 7) { mapRoomDestination = new Rectangle(610, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 8) { mapRoomDestination = new Rectangle(642, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 9) { mapRoomDestination = new Rectangle(674, -266 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 10) { mapRoomDestination = new Rectangle(578, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 11) { mapRoomDestination = new Rectangle(610, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 12) { mapRoomDestination = new Rectangle(642, -234 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 13) { mapRoomDestination = new Rectangle(610, -202 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 14) { mapRoomDestination = new Rectangle(578, -170 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else if (i == 15) { mapRoomDestination = new Rectangle(610, -170 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            else { mapRoomDestination = new Rectangle(642, -170 + currentYOffset, 8 * GameConstants.SCALE, 8 * GameConstants.SCALE); }
            return mapRoomDestination;
        }

        public void setGamePaused(Boolean val)
        {
            isPaused = val;
        }

        public void setMap(Boolean val)
        {
            hasMap = val;
        }

        public void setCompass(Boolean val)
        {
            hasCompass = val;
        }

        public void resetYOffset()
        {
            currentYOffset = 0;
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

        public Boolean isGamePaused()
        {
            return isPaused;
        }
    }
}
