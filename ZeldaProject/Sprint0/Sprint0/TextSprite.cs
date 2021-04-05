using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Sprint0
{
    public class TextSprite : ISprite
    {

        private Texture2D letterSheet;
        private SoundEffectInstance textSound;
        private Sprint4 game;
        private RoomManager roomManager;
        private int counter;
        private const int letterCount = 33;

        //x then y so grouped in twos
        //size is always 7x7
        readonly private int[] letterSource = 
            { 57, 11, 41, 11, 113, 11, 113, 19, 89, 11, 97, 11, 113, 11, 113, 19, //eastmost (16)
              65, 27, 97, 19, 57, 11, 89, 19, 89, 19, 73, 11, 89, 19, 113, 11, 121, 11, 82, 19, 41, 11, // penninsula (22)
              65, 27, 73, 11, 113, 11, // is (6)
              65, 27, 113, 19, 65, 19, 57, 11, // the (8)
              65, 27, 113, 11, 57, 11, 49, 11, 105, 19, 57, 11, 113, 19, 49, 27 // secret. (16)
            };
        readonly private int[] letterDest =
            { 54, 48, 61, 48, 68, 48, 75, 48, 82, 48, 89, 48, 96, 48, 103, 48, 110, 48, 117, 48, 124, 48, 131, 48, 138, 48, 145, 48, 152, 48, 159, 48, 166, 48, 173, 48, 180, 48, 187, 48, //top 19 letters (40)
              75, 55, 82, 55, 89, 55, 96, 55, 103, 55, 110, 55, 117, 55, 124, 55, 131, 55, 138, 55, 145, 55, 152, 55, 159, 55, 166, 55 //bottom 14 letters (28)
            };

        public TextSprite(Texture2D dungeonSheet, RoomManager manager, Sprint4 game)
        {
            this.game = game;
            roomManager = manager;
            letterSheet = dungeonSheet;
            textSound = game.Text_soundEffects[1].CreateInstance();
            textSound.Volume = 0.25f;
            textSound.IsLooped = true;
            counter = 0;
        }

        public void Update()
        {
            if (roomManager.getRoomIndex() == GameConstants.OLDMANROOM && !roomManager.RoomChange() && counter < letterCount) counter++;
            else if(roomManager.getRoomIndex() != GameConstants.OLDMANROOM) counter = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (roomManager.getRoomIndex() == GameConstants.OLDMANROOM && !roomManager.RoomChange())
            {
                textSound.Play();
                for (int i = 0; i <= counter * 2; i += 2)
                {
                    Rectangle destination = new Rectangle((letterDest[i] + 8) * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + (letterDest[i + 1] + 40) * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                    Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], 7, 7);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                }
                if (counter < letterCount)
                {
                    Rectangle destination = new Rectangle((letterDest[counter * 2] + 15) * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + (letterDest[(counter * 2) + 1] + 40) * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                    Rectangle source = new Rectangle(9, 56, 7, 7);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                } else textSound.Stop();
            } else
            {
                textSound.Stop();
            }
        }
    }
}
