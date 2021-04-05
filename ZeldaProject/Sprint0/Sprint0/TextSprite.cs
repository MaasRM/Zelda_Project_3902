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
        private List<SoundEffect> textSounds;
        private Sprint3 game;
        private int scale = 4;
        private int counter;

        //x then y so grouped in twos
        //size is always 7x7
        readonly private int[] letterSource = 
            { 57, 11, 41, 11, 113, 11, 113, 19, 89, 11, 96, 11, 113, 11, 113, 19, //eastmost (16)
              65, 27, 97, 19, 57, 11, 89, 19, 89, 19, 72, 11, 89, 19, 113, 11, 121, 11, 82, 19, 41, 11, // penninsula (22)
              65, 74, 11, 19, 113, 11, // is (6)
              65, 27, 113, 19, 65, 19, 57, 11, // the (8)
              65, 27, 113, 11, 57, 11, 46, 11, 105, 19, 57, 11, 113, 19, 49, 27 // secret. (16)
            };
        readonly private int[] letterDest =
            { 54, 48, 61, 48, 68, 48, 75, 48, 82, 48, 89, 48, 96, 48, 103, 48, 110, 48, 117, 48, 124, 48, 131, 48, 138, 48, 145, 48, 152, 48, 159, 48, 166, 48, 173, 48, 180, 48, 187, 48, //top 19 letters (40)
              75, 55, 82, 55, 89, 55, 96, 55, 103, 55, 110, 55, 117, 55, 124, 55, 131, 55, 138, 55, 145, 55, 152, 55, 159, 55, 166, 55 //bottom 14 letters (28)
            };

        public TextSprite(Texture2D dungeonSheet, Sprint3 game)
        {
            this.game = game;
            letterSheet = dungeonSheet;
            textSounds = game.Text_soundEffects;
            counter = 0;
        }

        public void Update()
        {
            if (counter < 33) counter++;
        }

        public void Reset()
        {
            counter = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= counter * 2; i += 2)
            {
                Rectangle destination = new Rectangle((letterDest[i] + 37) * scale, (64 * scale) + (letterDest[i + 1] + 37) * scale, 7 * scale, 7 * scale);
                Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], 7, 7);
                spriteBatch.Draw(letterSheet, destination, source, Color.White);
            }
            if(counter != 33) textSounds[0].Play();
        }
    }
}
