using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class ShopText
    {
        private Texture2D letterSheet;
        private SoundEffectInstance textSound;
        private Sprint4 game;
        private int counter;
        private const int letterCount = 29;
        private int[] letterSource;
        readonly private int[] letterDest = { 95, 120, 102, 120, 109, 120, 116, 120, 123, 120, 130, 120, 137, 120, 144, 120, 151, 120, 158, 120, 165, 120,
            67, 127, 74, 127, 81, 127, 88, 127, 95, 127, 102, 127, 109, 127, 116, 127, 123, 127, 130, 127, 137, 127, 144, 127, 151, 127, 158, 127, 165, 127,
            172, 127, 179, 127, 186, 127, 193, 127 };

        //PHRASE 1 -    Hi there!!!
        //          Welcome To the shop
        readonly private int[] letterSource1 
            = { 65, 150, 73, 142, 73, 158, 113, 150, 65, 150, 57, 142, 105, 150, 57, 142, 34, 166, 34, 166, 34, 166, //Hi there!!!
            1, 158, 57, 142, 81, 150, 49, 142, 97, 142, 89, 142, 57, 142, 73, 158, 113, 150, 97, 142, //Welcome To
            73, 158, 113, 150, 65, 150, 57, 142, 73, 158, 113, 142, 65, 150, 97, 142, 97, 150 }; //  the shop
        //PHRASE 2 -    Nice buy!!!
        //          That will be useful
        readonly private int[] letterSource2 = { };
        //PHRASE 3 -    Not enough,
        //          come back later ...
        readonly private int[] letterSource3 = { };

        public ShopText(Texture2D dungeonSheet, Sprint4 game)
        {
            this.game = game;
            letterSheet = dungeonSheet;
            textSound = game.Text_soundEffects[1].CreateInstance();
            textSound.Volume = 0.25f;
            textSound.IsLooped = true;
            counter = 0;
            letterSource = letterSource1;
        }

        public void Update()
        {
            if (counter < letterCount) counter++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            textSound.Play();
            for (int i = 0; i <= counter * 2; i += 2)
            {
                Rectangle destination = new Rectangle(letterDest[i] * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + letterDest[i + 1] * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], 7, 7);
                spriteBatch.Draw(letterSheet, destination, source, Color.White);
            }
            if (counter < letterCount)
            {
                Rectangle destination = new Rectangle((letterDest[counter * 2] + 7) * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + letterDest[(counter * 2) + 1] * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                Rectangle source = new Rectangle(65, 158, 7, 7);
                spriteBatch.Draw(letterSheet, destination, source, Color.White);
            }
            else textSound.Stop();
        }

        public void ChangeText(int i)
        {
            switch(i)
            {
                case 1:
                    letterSource = letterSource1;
                    break;
                case 2:
                    letterSource = letterSource2;
                    break;
                case 3:
                    letterSource = letterSource3;
                    break;
                default:
                    letterSource = letterSource1;
                    break;
            }
        }

        public void Reset()
        {
            letterSource = letterSource1;
            counter = 0;
            textSound.Stop();
        }
    }
}
