using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
namespace Sprint0
{
    public class SecretKey : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private SoundEffectInstance keyDrop;
        private Texture2D sheet;
        private List<INPC> npcs;
        private bool dropped;


        public SecretKey(Rectangle startPos, Rectangle source, Texture2D spriteSheet, List<INPC> NPCS, Sprint4 game)
        {
            destination = startPos;
            spriteSource = source;
            sheet = spriteSheet;
            npcs = NPCS;
            dropped = false;
            keyDrop = game.Enemy_soundEffects[1].CreateInstance();
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(npcs.Count == 0 )
            {
                if (!dropped) keyDrop.Play(); dropped = true;
                spriteBatch.Draw(sheet, destination, spriteSource, Color.White);
            }            
        }

        public Rectangle GetLocationRectangle()
        {
            if(npcs.Count == 0)
            {
                return destination;
            } 
            else
            {
                return new Rectangle(0, 0, 0, 0);
            }
            
        }

        public Rectangle GetSourceRectangle()
        {
            return spriteSource;
        }

        public Texture2D GetSpriteSheet()
        {
            return sheet;
        }
    }
}