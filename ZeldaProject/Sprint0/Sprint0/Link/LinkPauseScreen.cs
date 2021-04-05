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

        public LinkPauseScreen(Texture2D background)
        {
            isPaused = false;
            inventoryBackground = background;
            currentYOffset = 0;
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

        public Boolean isGamePaused()
        {
            return isPaused;
        }
    }
}
