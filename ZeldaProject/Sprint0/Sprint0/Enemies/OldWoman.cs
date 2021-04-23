using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class OldWoman : INPC
    {
        private Texture2D oldManSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int> init;
        public const int WIDTHANDHEIGHT = 16;
        private const int SCALER = 4;

        public OldWoman(int x, int y, Texture2D spriteSheet)
        {
            destination = new Rectangle(x, y, WIDTHANDHEIGHT * SCALER, WIDTHANDHEIGHT * SCALER);
            source = new Rectangle(36, 11, WIDTHANDHEIGHT, WIDTHANDHEIGHT);
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
            destination = new Rectangle(init.Item1, init.Item2, WIDTHANDHEIGHT * SCALER, WIDTHANDHEIGHT * SCALER);
            source = new Rectangle(1, 11, WIDTHANDHEIGHT, WIDTHANDHEIGHT);
        }

        public Rectangle GetNPCLocation()
        {
            return destination;
        }
        public void SetPosition(Rectangle newPos)
        {
            destination = newPos;
        }
    }
}
