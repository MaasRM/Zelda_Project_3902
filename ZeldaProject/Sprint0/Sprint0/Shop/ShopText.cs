using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class ShopText
    {
        private Texture2D letterSheet;
        private SoundEffectInstance textSound;
        private Sprint4 game;
        private int counter;
        private const int letterCount = 29;
        private int[] letterSource;

        public ShopText(Texture2D dungeonSheet, Sprint4 game)
        {
            this.game = game;
            letterSheet = dungeonSheet;
            textSound = game.Text_soundEffects[1].CreateInstance();
            textSound.Volume = 0.25f;
            textSound.IsLooped = true;
            counter = 0;
            letterSource = ShopConstants.letterSource1;
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
                Rectangle destination = new Rectangle(ShopConstants.letterDest[i] * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + ShopConstants.letterDest[i + 1] * GameConstants.SCALE, ShopConstants.LETTERSIZE * GameConstants.SCALE, ShopConstants.LETTERSIZE * GameConstants.SCALE);
                Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], ShopConstants.LETTERSIZE, ShopConstants.LETTERSIZE);
                spriteBatch.Draw(letterSheet, destination, source, Color.White);
            }
            if (counter < letterCount)
            {
                Rectangle destination = new Rectangle((ShopConstants.letterDest[counter * 2] + ShopConstants.LETTERSIZE) * GameConstants.SCALE, (GameConstants.HUDSIZE * GameConstants.SCALE) + ShopConstants.letterDest[(counter * 2) + 1] * GameConstants.SCALE, ShopConstants.LETTERSIZE * GameConstants.SCALE, ShopConstants.LETTERSIZE * GameConstants.SCALE);
                Rectangle source = new Rectangle(ShopConstants.UNDERSCOREX, ShopConstants.UNDERSCOREY, ShopConstants.LETTERSIZE, ShopConstants.LETTERSIZE);
                spriteBatch.Draw(letterSheet, destination, source, Color.White);
            }
            else textSound.Stop();
        }

        public void ChangeText(int i)
        {
            switch(i)
            {
                case 1:
                    letterSource = ShopConstants.letterSource1;
                    break;
                case 2:
                    letterSource = ShopConstants.letterSource2;
                    break;
                case 3:
                    letterSource = ShopConstants.letterSource3;
                    break;
                default:
                    letterSource = ShopConstants.letterSource1;
                    break;
            }
            counter = 0;
        }

        public void Reset()
        {
            letterSource = ShopConstants.letterSource1;
            counter = 0;
            textSound.Stop();
        }
    }
}
