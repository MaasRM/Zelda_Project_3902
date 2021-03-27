using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;


namespace Sprint0
{
    public class BombItem : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Texture2D sheet;
        private List<SoundEffect> SoundEffects;


        public BombItem(Rectangle startPos, Rectangle source, Texture2D spriteSheet, List<SoundEffect> Link_soundEffects)
        {
            destination = startPos;
            spriteSource = source;
            sheet = spriteSheet;
            SoundEffects = Link_soundEffects;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(sheet, destination, spriteSource, Color.White);

        }

        public Rectangle GetLocationRectangle()
        {
            return destination;
        }
    }
}