using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class EnemyKey : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Texture2D sheet;
        private INPC npc;


        public EnemyKey(Rectangle source, Texture2D spriteSheet, INPC NPC)
        {
            destination = NPC.GetNPCLocation();
            spriteSource = source;
            sheet = spriteSheet;
            npc = NPC;
        }

        public void Update()
        {
            destination = npc.GetNPCLocation();
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