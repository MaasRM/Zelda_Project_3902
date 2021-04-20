using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class TriForceText
    {
        private Texture2D letterSheet;
        private Texture2D itemSheet;
        private SoundEffectInstance textSound;
        private Sprint5 game;
        private int counter;
        private int shardUpdate;
        private int[] letterSource;

        private INPC zelda;
        private LinkTriForceShards shards;

        public TriForceText(Texture2D dungeonSheet, Texture2D npcSheet, Texture2D itemSheet,  Sprint5 game, LinkTriForceShards shards)
        {
            this.game = game;
            letterSheet = dungeonSheet;
            this.itemSheet = itemSheet;
            textSound = game.Text_soundEffects[1].CreateInstance();
            textSound.Volume = 0.25f;
            textSound.IsLooped = true;
            counter = 0;
            shardUpdate = 0;
            letterSource = LinkConstants.letterSource;
            zelda = new Zelda(LinkConstants.ZELDAX * GameConstants.SCALE, LinkConstants.ZELDAY * GameConstants.SCALE, npcSheet);
            this.shards = shards;
        }

        public void Update()
        {
            if (counter < LinkConstants.LETTERCOUNT) counter++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (game.GetRoomManager().getRoomIndex() == GameConstants.OUTSIDEROOM)
            {
                LinkPauseScreen pause = game.GetPlayer().GetLinkInventory().pauseScreen;
                if (pause.getCurrentYOffset() > 0 || pause.isGamePaused() == true) { textSound.Stop(); }
                else { textSound.Play(); }
                for (int i = 0; i <= counter * 2; i += 2)
                {
                    Rectangle destination = new Rectangle(LinkConstants.letterDest[i] * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + LinkConstants.letterDest[i + 1] * GameConstants.SCALE, LinkConstants.LETTERSIZE * GameConstants.SCALE, LinkConstants.LETTERSIZE * GameConstants.SCALE);
                    Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], LinkConstants.LETTERSIZE, LinkConstants.LETTERSIZE);
                    if (i == 0) source = new Rectangle(LinkConstants.numberSource[(3 - shards.getShards().Count) * 2], LinkConstants.numberSource[(3 - shards.getShards().Count) * 2 + 1], LinkConstants.LETTERSIZE, LinkConstants.LETTERSIZE);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                }
                if (counter < LinkConstants.LETTERCOUNT)
                {
                    Rectangle destination = new Rectangle((LinkConstants.letterDest[counter * 2] + LinkConstants.LETTERSIZE) * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + LinkConstants.letterDest[(counter * 2) + 1] * GameConstants.SCALE, LinkConstants.LETTERSIZE * GameConstants.SCALE, LinkConstants.LETTERSIZE * GameConstants.SCALE);
                    Rectangle source = new Rectangle(LinkConstants.UNDERSCOREX, LinkConstants.UNDERSCOREY, LinkConstants.LETTERSIZE, LinkConstants.LETTERSIZE);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                }
                else textSound.Stop();
                zelda.Draw(spriteBatch);
                DrawShards(spriteBatch);
            }
            else textSound.Stop();
        }

        private void DrawShards(SpriteBatch spriteBatch)
        {
            bool one = false;
            bool two = false;
            bool three = false;
            shardUpdate++;
            if (shardUpdate > 2) shardUpdate = 0;
            foreach (IItem shard in shards.getShards())
            {
                if (((TriforceShardItem)shard).getTriForceIndex() == 1)
                {
                    spriteBatch.Draw(itemSheet, new Rectangle(LinkConstants.TRIFORCE1X * GameConstants.SCALE, LinkConstants.TRIFORCE1Y * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE), shard.GetSourceRectangle(), Color.White);
                    one = true;
                }
                if (((TriforceShardItem)shard).getTriForceIndex() == 2)
                {
                    spriteBatch.Draw(itemSheet, new Rectangle(LinkConstants.TRIFORCE2X * GameConstants.SCALE, LinkConstants.TRIFORCE2Y * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE), shard.GetSourceRectangle(), Color.White);
                    two = true;
                }
                if (((TriforceShardItem)shard).getTriForceIndex() == 3)
                {
                    spriteBatch.Draw(itemSheet, new Rectangle(LinkConstants.TRIFORCE3X * GameConstants.SCALE, LinkConstants.TRIFORCE3Y * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE), shard.GetSourceRectangle(), Color.White);
                    three = true;
                }
                if(shardUpdate == 0)shard.Update();
            }
            if (!one)
            {
                IItem emptyShard1 = new EmptyTriforceShardItem(new Rectangle(LinkConstants.TRIFORCE1X * GameConstants.SCALE, LinkConstants.TRIFORCE1Y * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE), new Rectangle(272, 31, 15, 15), itemSheet);
                emptyShard1.Draw(spriteBatch);
            }
            if (!two)
            {
                IItem emptyShard2 = new EmptyTriforceShardItem(new Rectangle(LinkConstants.TRIFORCE2X * GameConstants.SCALE, LinkConstants.TRIFORCE2Y * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE), new Rectangle(272, 31, 15, 15), itemSheet);
                emptyShard2.Draw(spriteBatch);
            }
            if (!three)
            {
                IItem emptyShard3 = new EmptyTriforceShardItem(new Rectangle(LinkConstants.TRIFORCE3X * GameConstants.SCALE, LinkConstants.TRIFORCE3Y * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE), new Rectangle(272, 31, 15, 15), itemSheet);
                emptyShard3.Draw(spriteBatch);
            }
        }

        public void Reset()
        {
            counter = 0;
            textSound.Stop();
        }
    }
}
