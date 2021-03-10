using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class OldMan : INPC
    {
        private Texture2D oldManSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int> init;
        private const int SCALER = 2;

        public OldMan(int x, int y, Texture2D spriteSheet)
        {
            destination = new Rectangle(x, y, 16 * SCALER, 16 * SCALER);
            source = new Rectangle(1, 11, 16, 16);
            oldManSpriteSheet = spriteSheet;
            init = new Tuple<int, int>(x, y);
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(oldManSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            destination = new Rectangle(init.Item1, init.Item2, 16 * SCALER, 16 * SCALER);
            source = new Rectangle(1, 11, 16, 16);
        }

        public Rectangle GetNPCLocation()
        {
            return destination;
        }
    }
}
