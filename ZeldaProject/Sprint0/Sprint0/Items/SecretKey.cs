using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class SecretKey : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Texture2D sheet;
        private List<INPC> npcs;


        public SecretKey(Rectangle startPos, Rectangle source, Texture2D spriteSheet, List<INPC> NPCS)
        {
            destination = startPos;
            spriteSource = source;
            sheet = spriteSheet;
            npcs = NPCS;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(npcs.Count == 0)
            {
                spriteBatch.Draw(sheet, destination, spriteSource, Color.White);
            }            
        }

        public Rectangle GetLocationRectangle()
        {
            return destination;
        }
    }
}