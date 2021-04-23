using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class DeathMessageSprite : ISprite
    {

        private Texture2D letterSheet;
        private SoundEffectInstance textSound;
        private IPlayer player;
        private int counter = 0;
        private const int letterCount = 67;
        private int frameCount = 130;
        private int gameHeight;
        SongManager songManager;

        //x then y so grouped in twos
        //size is always 7x7
        readonly private int[] letterSource = 
            { 10, 27, 97, 11, 121, 11, //you (6)
              65, 27, 65, 19, 41, 11, 121, 19, 57, 11, // have (10) 
              65, 27, 49, 19, 74, 11, 57, 11, 49, 19, // died (10)
              114, 19, 65, 19, 57, 11, //the (6)
              65, 27, 113, 11, 65, 19, 97, 11, 97, 19, // shop (10)
              65, 27, 73, 11, 113, 11, // is (6)
              65, 27, 97, 11, 97, 19, 57, 11, 89, 19, // open (10)
              97, 19, 121, 11, 105, 19, 49, 11, 65, 19, 41, 11, 113, 11, 57, 11, //purchase (16)
              65, 27, 89, 19, 57, 11, 1, 27, // new (8)
              65, 27, 65, 11, 57, 11, 41, 11, 105, 19, // gear (10)
              114, 19, 97, 11, //to ()
              65, 27, 41, 19, 57, 11, 49, 11, 97, 11, 89, 11, 57, 11, // become (14)
              65, 27, 89, 11, 97, 11, 105, 19, 57, 11, // more (10)
              97, 19, 97, 11, 1, 27, 57, 11, 105, 19, 57, 19, 121, 11, 81, 19 //powerful(16)
            };
        readonly private int[] letterDest =
            { 68, 27, 75, 27, 82, 27, 89, 27, 96, 27, 103, 27, 110, 27, 117, 27, 124, 27, 131, 27, 138, 27, 145, 27, 152, 27, //row 1: 16 letters (32)
              57, 41, 64, 41, 71, 41, 78, 41, 85, 41, 92, 41, 99, 41, 106, 41, 113, 41, 120, 41, 127, 41, 134, 41, 141, 41, 148, 41, 155, 41, 162, 41, //row 1: 16 letters (32)
              54, 55, 61, 55, 68, 55, 75, 55, 82, 55, 89, 55, 96, 55, 103, 55, 110, 55, 117, 55, 124, 55, 131, 55, 138, 55, 145, 55, 152, 55, 159, 55, 166, 55, //row 2: 17 letters (34)
              64, 65, 71, 65, 78, 65, 85, 65, 92, 65, 99, 65, 106, 65, 113, 65, 120, 65, 127, 65, 134, 65, 141, 65, 148, 65, 155, 65, //row 3: 14 letters (28)
              85, 75, 92, 75, 99, 75, 106, 75, 113, 75, 120, 75, 127, 75, 134, 75 //row 4: 8 letters (16)
            };

        public DeathMessageSprite(Texture2D dungeonSheet, RoomManager manager, SoundEffectInstance text, IPlayer link, Sprint5 game)
        {
            letterSheet = dungeonSheet;
            textSound = text;
            player = link;
            textSound.Volume = 0.25f;
            textSound.IsLooped = true;
            gameHeight = game.GraphicsDevice.Viewport.Bounds.Height;
            songManager = game.GetSongManager();
        }

        public void Update()
        {
            if (!player.IsAlive() && frameCount ==130)
            {
                frameCount = 0;
                songManager.Stop();
            }
            if (frameCount < 130) 
            {
                if (counter < letterCount) counter++;
                frameCount++; 
            }
            else
            {
                counter = 0;
                frameCount = 130;
            }
                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (frameCount < 130)
            {
                spriteBatch.Draw(letterSheet, new Rectangle(0, 250, 1020, 750), new Rectangle(83, 38, 4, 4), Color.White);
                textSound.Play();
                spriteBatch.Draw(letterSheet, new Rectangle(0, 0, 256 * GameConstants.SCALE, 64 * GameConstants.SCALE), new Rectangle(280, 30, 1, 1), Color.White);
                for (int i = 0; i <= counter * 2; i += 2)
                {
                    Rectangle destination = new Rectangle((letterDest[i] + 8) * GameConstants.SCALE, (gameHeight / 8) + (letterDest[i + 1] + 40) * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                    Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], 7, 7);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                }
                if (counter < letterCount)
                {
                    Rectangle destination = new Rectangle((letterDest[counter * 2] + 15) * GameConstants.SCALE, (gameHeight / 8) + (letterDest[(counter * 2) + 1] + 40) * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                    Rectangle source = new Rectangle(9, 56, 7, 7);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                }
                else
                {
                    textSound.Stop();
                    songManager.Overworld();
                }
            } else
            {
                textSound.Stop();
            }
        }

        public bool isDrawing()
        {
            return frameCount != 130;
        }
    }
}
