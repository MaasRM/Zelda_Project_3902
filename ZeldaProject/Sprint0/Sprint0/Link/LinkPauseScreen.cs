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

        public LinkPauseScreen(Texture2D background)
        {
            isPaused = false;
            inventoryBackground = background;
            currentYOffset = 0;
            pauseTopSourceRectangle = new Rectangle(1, 12, 255, 87);
            pauseBottomSourceRectangle = new Rectangle(258, 113, 255, 87);
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
        }

        public void setGamePaused(Boolean val)
        {
            isPaused = val;
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
