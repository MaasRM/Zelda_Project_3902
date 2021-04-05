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

        public LinkPauseScreen(Texture2D background)
        {
            isPaused = false;
            inventoryBackground = background;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public void setGamePaused(Boolean val)
        {
            isPaused = val;
        }

        public Boolean isGamePaused()
        {
            return isPaused;
        }
    }
}
