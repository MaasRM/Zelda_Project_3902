using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class BoomerangItem : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private const int width = 7;
        private const int height = 15;
        private Texture2D sheet;
        private List<INPC> npcs;
        bool enemiesAlive;


        public BoomerangItem(Rectangle source, List<INPC> NPCS, Texture2D spriteSheet)
        {
            npcs = NPCS;
            if (NPCS.Count > 0) destination = new Rectangle(npcs[0].GetNPCLocation().X, npcs[0].GetNPCLocation().Y, width * GameConstants.SCALE, height * GameConstants.SCALE);
            else destination = new Rectangle(0, 0, 0, 0);
            spriteSource = source;
            sheet = spriteSheet;
            enemiesAlive = true;
        }

        public void Update()
        {
            if (enemiesAlive && npcs.Count > 0)
            {
                destination = new Rectangle(npcs[0].GetNPCLocation().X, npcs[0].GetNPCLocation().Y, width * GameConstants.SCALE, height * GameConstants.SCALE);
            }
            else
            {
                enemiesAlive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (npcs.Count == 0)
            {
                spriteBatch.Draw(sheet, destination, spriteSource, Color.White);
            }

        }

        public Rectangle GetLocationRectangle()
        {
            return destination;
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
