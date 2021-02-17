using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class OldMan : INPC
    {
        private StalfosStateMachine stateMachine;
        private Texture2D oldManSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private const int SCALER = 2;

        public OldMan(int x, int y, Texture2D spriteSheet)
        {
            destination = new Rectangle(x, y, 1 * SCALER, 1 * SCALER);
            source = new Rectangle(1, 1, 1, 1);
            oldManSpriteSheet = spriteSheet;
        }

        public void Update()
        {
            //doesn't move so do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(oldManSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            //Doesn't move so do nothing
        }
    }
}
