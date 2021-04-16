using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
namespace Sprint0
{
    public class EnemyKey : IItem
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Texture2D sheet;
        private INPC npc;
        bool enemyAlive;
        private const int width = 7;
        private const int height = 15;
        private const int scale = 4;
        private bool dropped;
        private SoundEffectInstance keyDrop;


        public EnemyKey(Rectangle source, Texture2D spriteSheet, INPC NPC, Sprint5 game)
        {
            npc = NPC;
            destination = new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, width * scale, height * scale);
            spriteSource = source;
            sheet = spriteSheet;
            enemyAlive = true;
            dropped = false;
            keyDrop = game.Enemy_soundEffects[1].CreateInstance();
        }

        public void Update()
        {
            if(enemyAlive && ((IEnemy)npc).StillAlive())
            {
                destination = new Rectangle(npc.GetNPCLocation().X, npc.GetNPCLocation().Y, width * scale, height * scale);
            }
            else
            {
                enemyAlive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!enemyAlive)
            {
                if (!dropped) keyDrop.Play(); dropped = true;
                spriteBatch.Draw(sheet, destination, spriteSource, Color.White);
            }
        }

        public Rectangle GetLocationRectangle()
        {
            if (!enemyAlive)
            {
                return destination;
            } else
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