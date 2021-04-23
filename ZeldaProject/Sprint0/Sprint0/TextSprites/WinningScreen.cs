﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class WinningScreen : ISprite
    {

        private Texture2D letterSheet;
        private SoundEffectInstance textSound;
        private int yDist;
        private int gameMid;
        private int gameHeight;
        private Zelda zelda;
        private IdleLink link;
        private List<TriforceShardItem> shards;
        private const int letterSize = 7;

        //x then y so grouped in twos
        //size is always 7x7
        readonly private int[] letterSource =
            { 49, 11, 97, 11, 89, 19, 65, 11, 105, 19, 41, 11, 113, 19, 121, 11, 81, 19, 41, 11, 113, 19, 73, 11, 97, 11, 89, 19, 113, 11, 33, 35, //Congratulations! (32)
              10, 27, 97, 11, 121, 11, //you (8)
              65, 27, 65, 19, 41, 11, 121, 19, 57, 11, // have (10)
              65, 27, 49, 11, 97, 11, 89, 11, 97, 19, 81, 19, 57, 11, 113, 19, 57, 11, 49, 19, // completed (20)
              65, 27, 114, 19, 65, 19, 57, 11, // the (8)
              65, 27, 113, 19, 105, 19, 73, 11, 57, 19, 97, 11, 105, 19, 49, 11, 57, 11, 33, 35, // triforce! (20)
              113, 19, 65, 19, 73, 11, 113, 11, //this (8)
              65, 27, 41, 11, 105, 19, 113, 19, 73, 11, 57, 19, 41, 11, 49, 11, 113, 19, // artifact (18)
              65, 27, 1, 27, 73, 11, 81, 19, 81, 19, // will (10)
              65, 27, 41, 11, 81, 19, 81, 19, 97, 11, 1, 27, // allow (6)
              65, 27, 10, 27, 97, 11, 121, 11, // you (8)
              114, 19, 97, 11, //to (4)
              65, 27, 105, 19, 57, 11, 113, 11, 113, 19, 97, 11, 105, 19, 57, 11, // restore (16)
              65, 27, 97, 19, 57, 11, 41, 11, 49, 11, 57, 11, // peace (12)
              65, 27, 114, 19, 97, 11, // to (6)
              65, 27, 114, 19, 65, 19, 57, 11, // the (8)
              65, 27, 81, 19, 41, 11, 89, 19, 49, 19, 33, 35, // land! (10)
              113, 19, 65, 19, 41, 11, 89, 19, 81, 11, 113, 11, //thanks (12)
              65, 27, 57, 19, 97, 11, 105, 19, // for (8)
              65, 27, 97, 19, 81, 19, 41, 11, 10, 27, 73, 11, 89, 19, 65, 11, 33, 35, // playing! (18)
              49, 19, 57, 11, 121, 19, 57, 11, 81, 19, 97, 11, 97, 19, 57, 11, 49, 19, //developed (18)
              65, 27, 41, 19, 10, 27, // by (6)
              73, 19, 41, 11, 49, 11, 97, 11, 41, 19, 65, 27, 81, 11, 81, 19, 73, 11, 89, 19, 57, 11, //Jacob Kline (22)
              73, 19, 41, 11, 105, 19, 57, 11, 49, 19, 65, 27, 9, 35, 73, 11, 89,19, 113, 11, //Jared Zins (20)
              89, 19, 41, 11, 113, 19, 65, 19, 41, 11, 89, 19, 65, 27, 113, 11, 49, 11, 65, 19, 121, 11, 81, 19, 113, 19, 9, 35, //Nathan Schultz (28)
              97, 19, 65, 19, 73, 11, 81, 19, 65, 27, 41, 19, 105, 19, 97, 11, 49, 11, 81, 11, 57, 11, 105, 19, //Phil Brocker (24)
              105, 19, 73, 11, 81, 19, 57, 11, 10, 27, 65, 27, 89, 11, 41, 11, 41, 11, 113, 11 //Riley Maas (20)
            };
        readonly private int[] letterDest =
            { 296, 1050, 324, 1050, 352, 1050, 380, 1050, 408, 1050, 436, 1050, 464, 1050, 492, 1050, 520, 1050, 548, 1050, 576, 1050, 604, 1050, 632, 1050, 660, 1050, 688, 1050, 716, 1050, //Congratulations! (32)
              72, 1150, 100, 1150, 128, 1150, //you (8)
              156, 1150, 184, 1150, 212, 1150, 240, 1150, 268, 1150, // have (10)
              296, 1150, 324, 1150, 352, 1150, 380, 1150, 408, 1150, 436, 1150, 464, 1150, 492, 1150, 520, 1150, 548, 1150, // completed (20)
              576, 1150, 604, 1150, 632, 1150, 660, 1150, // the (8)
              688, 1150, 716, 1150, 744, 1150, 772, 1150, 800, 1150, 828, 1150, 856, 1150, 884, 1150, 912, 1150, 940, 1150, // triforce! (20)
              128, 1250, 156, 1250, 184, 1250, 212, 1250, //this (8)
              240, 1250, 268, 1250, 296, 1250, 324, 1250, 352, 1250, 380, 1250, 408, 1250, 436, 1250, 464, 1250, // artifact (18)
              492, 1250, 520, 1250, 548, 1250, 576, 1250, 604, 1250, // will (10)
              632, 1250, 660, 1250, 688, 1250, 716, 1250, 744, 1250, 772, 1250, // allow (6)
              800, 1250, 828, 1250, 856, 1250, 884, 1250, // you (8)
              114, 1288, 142, 1288, //to (4)
              170, 1288, 198, 1288, 226, 1288, 254, 1288, 282, 1288, 310, 1288, 338, 1288, 366, 1288, // restore (16)
              394, 1288, 422, 1288, 450, 1288, 478, 1288, 506, 1288, 534, 1288, // peace (12)
              562, 1288, 590, 1288, 618, 1288, // to (6)
              646, 1288, 674, 1288, 702, 1288, 730, 1288, // the (8)
              758, 1288, 786, 1288, 814, 1288, 842, 1288, 870, 1288, 898, 1288, // land! (10)
              254, 1400, 282, 1400, 310, 1400, 338, 1400, 366, 1400, 394, 1400, //thanks (12)
              422, 1400, 450, 1400, 478, 1400, 506, 1400, // for (8)
              534, 1400, 562, 1400, 590, 1400, 618, 1400, 646, 1400, 674, 1400, 702, 1400, 730, 1400, 758, 1400, // playing! (18)
              352, 1500, 380, 1500, 408, 1500, 436, 1500, 464, 1500, 492, 1500, 520, 1500, 548, 1500, 576, 1500, //developed (18)
              604, 1500, 632, 1500, 660, 1500, // by (6)
              366, 1556, 394, 1556, 422, 1556, 450, 1556, 478, 1556, 506, 1556, 534, 1556, 562, 1556, 590, 1556, 618, 1556, 646, 1556, //Jacob Kline (22)
              380, 1612, 408, 1612, 436, 1612, 464, 1612, 492, 1612, 520, 1612, 548, 1612, 576, 1612, 604, 1612, 632, 1612, //Jared Zins (20)
              324, 1668, 352, 1668, 380, 1668, 408, 1668, 436, 1668, 464, 1668, 492, 1668, 520, 1668, 548, 1668, 576, 1668, 604, 1668, 632, 1668, 660, 1668, 688, 1668, //Nathan Schultz (28)
              352, 1724, 380, 1724, 408, 1724, 436, 1724, 464, 1724, 492, 1724, 520, 1724, 548, 1724, 576, 1724, 604, 1724, 632, 1724, 660, 1724, //Phil Brocker (24)
              380, 1780, 408, 1780, 436, 1780, 464, 1780, 492, 1780, 520, 1780, 548, 1780, 576, 1780, 604, 1780, 632, 1780 //Riley Maas (20)
            };

        public WinningScreen(Texture2D dungeonSheet, Texture2D NPCsheet, Texture2D Linksheet, Texture2D itemsSheet, SoundEffectInstance text, Sprint5 game)
        {
            letterSheet = dungeonSheet;
            textSound = text;
            textSound.Volume = 0.25f;
            textSound.IsLooped = true;
            gameMid = game.GraphicsDevice.Viewport.Width / 2 - 16;
            gameHeight = game.GraphicsDevice.Viewport.Height;
            zelda = new Zelda(gameMid, game.GraphicsDevice.Viewport.Height, NPCsheet);
            link = new IdleLink(gameMid, game.GraphicsDevice.Viewport.Height, Linksheet);
            shards = new List<TriforceShardItem>();
            shards.Add(new TriforceShardItem(link.GetNPCLocation(), new Rectangle(272, 0, 15, 15), itemsSheet, 1));
            shards.Add(new TriforceShardItem(link.GetNPCLocation(), new Rectangle(272, 0, 15, 15), itemsSheet, 2));
            shards.Add(new TriforceShardItem(link.GetNPCLocation(), new Rectangle(272, 0, 15, 15), itemsSheet, 3));
            yDist = 0;
        }

        public void Update()
        {
            zelda.Update();
            foreach (TriforceShardItem shard in shards) shard.Update();
            yDist+=2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle ZRect = new Rectangle(gameMid, gameHeight - yDist - 25, LinkConstants.LINKSIZENORMAL * GameConstants.SCALE, LinkConstants.LINKSIZENORMAL * GameConstants.SCALE);

            for (int i = 0; i < letterSource.Length; i += 2)
            {
                Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], letterSize, letterSize);
                Rectangle destination = new Rectangle(letterDest[i], letterDest[i + 1] - yDist, letterSize*GameConstants.SCALE, letterSize*GameConstants.SCALE);
                spriteBatch.Draw(letterSheet, destination, source, Color.White);
            }
            zelda.SetPosition(ZRect);
            zelda.Draw(spriteBatch);
            link.SetPosition(new Rectangle(ZRect.X - 1, ZRect.Y - 50 * GameConstants.SCALE, ZRect.Width, ZRect.Height));
            link.Draw(spriteBatch);
            shards[0].SetLocationRectangle(new Rectangle(link.GetNPCLocation().X, link.GetNPCLocation().Y - 32 * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE));
            shards[1].SetLocationRectangle(new Rectangle(link.GetNPCLocation().X - 6 * GameConstants.SCALE, link.GetNPCLocation().Y - 21 * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE));
            shards[2].SetLocationRectangle(new Rectangle(link.GetNPCLocation().X + 6 * GameConstants.SCALE, link.GetNPCLocation().Y - 21 * GameConstants.SCALE, 15 * GameConstants.SCALE, 15 * GameConstants.SCALE));
            shards[0].Draw(spriteBatch);
            shards[1].Draw(spriteBatch);
            shards[2].Draw(spriteBatch);
        }

        public bool isDrawing()
        {
            return yDist < 2000;
        }
    }
}
