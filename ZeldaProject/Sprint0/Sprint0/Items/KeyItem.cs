using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
namespace Sprint0
{
    public class KeyItem : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Texture2D sheet;
        private bool dropped;
        private SoundEffectInstance keyDrop;


        public KeyItem(Rectangle startPos, Rectangle source, Texture2D spriteSheet, Sprint4 sprint3)
        {
            destination = startPos;
            spriteSource = source;
            sheet = spriteSheet;
            dropped = false;
            keyDrop = sprint3.Enemy_soundEffects[1].CreateInstance();
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!dropped) keyDrop.Play(); dropped = true;
            spriteBatch.Draw(sheet, destination, spriteSource, Color.White);

        }

        public Rectangle GetLocationRectangle()
        {
            return destination;
        }
    }
}