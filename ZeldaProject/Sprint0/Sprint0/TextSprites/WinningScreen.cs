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
        private IPlayer player;
        private int counter = 0;
        private const int letterCount = 67;
        private int frameCount = 130;

        //x then y so grouped in twos
        //size is always 7x7
        readonly private int[] letterSource =
            {  49, 11, 97, 11, 89, 19, 65, 11, 105, 19, 41, 11, 113, 19, 121, 11, 81, 19, 41, 11, 113, 19, 73, 11, 97, 11, 89, 19, 113, 11, 33, 35, //Congratulations! (32)
              65, 27, 10, 27, 97, 11, 121, 11, // you (8)
              65, 27, 65, 19, 41, 11, 121, 19, 57, 11, // have (10)
              65, 27, 49, 19, 97, 11, 89, 11, 97, 19, 81, 19, 57, 11, 113, 19, 57, 11, 49, 19, // completed (20)
              65, 27, 114, 19, 65, 19, 57, 11, // the (8)
              65, 27, 113, 19, 105, 19, 73, 11, 57, 19, 97, 11, 105, 19, 49, 11, 57, 11, 33, 35, // triforce! (20)
              113, 19, 65, 19, 73, 11, 113, 11, //this (8)
              65, 27, 41, 11, 105, 19, 113, 19, 73, 11, 57, 19, 41, 11, 49, 11, 113, 19, // artifact (18)
              65, 27, 1, 27, 73, 11, 81, 19, 81, 19, // will (10)
              65, 27, 41, 11, 81, 19, 81, 19, 97, 11, 1, 27, // allow (6)
              65, 27, 10, 27, 97, 11, 121, 11, // you (8)
              65, 27, 114, 19, 97, 11, // to (6)
              65, 27, 105, 19, 57, 11, 113, 11, 113, 19, 97, 11, 105, 19, 57, 11, // restore (16)
              65, 27, 97, 19, 57, 11, 41, 11, 49, 11, 57, 11, // peace (12)
              65, 27, 114, 19, 97, 11, // to (6)
              65, 27, 114, 19, 65, 19, 57, 11, // the (8)
              65, 27, 81, 19, 41, 11, 89, 19, 49, 19, 33, 35, // land! (10)
              //thanks (12)
              65, 27, // for (8)
              65, 27, // playing! (18)
              //developed (18)
              65, 27, // by (6)
              //Jacob Kline (22)
              //Jared Zins (20)
              //Nathan Schultz (28)
              //Phil Brocker (24)
              //Riley Maas (20)
            };
        readonly private int[] letterDest =
            { 54, 27, 61, 27, 68, 27, 75, 27, 82, 27, 89, 27, 96, 27, 103, 27, 110, 27, 117, 27, 124, 27, 131, 27, 138, 27, //row 1: 16 letters (32)
              54, 41, 61, 41, 68, 41, 75, 41, 82, 41, 89, 41, 96, 41, 103, 41, 110, 41, 117, 41, 124, 41, 131, 41, 138, 41, 145, 41, 152, 41, 159, 41, //row 1: 16 letters (32)
              54, 55, 61, 55, 68, 55, 75, 55, 82, 55, 89, 55, 96, 55, 103, 55, 110, 55, 117, 55, 124, 55, 131, 55, 138, 55, 145, 55, 152, 55, 159, 55, 166, 55, //row 2: 17 letters (34)
              54, 62, 61, 62, 68, 62, 75, 62, 82, 62, 89, 62, 96, 62, 103, 62, 110, 62, 117, 62, 124, 62, 131, 62, 138, 62, 145, 62, //row 3: 14 letters (28)
              54, 69, 61, 69, 68, 69, 75, 69, 82, 69, 89, 69, 96, 69, 103, 69 //row 4: 8 letters (16)
            };

        public WinningScreen(Texture2D dungeonSheet, RoomManager manager, SoundEffectInstance text, IPlayer link)
        {
            letterSheet = dungeonSheet;
            textSound = text;
            player = link;
            textSound.Volume = 0.25f;
            textSound.IsLooped = true;          
        }

        public void Update()
        {
            if (!player.IsAlive() && frameCount ==130)
            {
                frameCount = 0;
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
                    Rectangle destination = new Rectangle((letterDest[i] + 8) * GameConstants.SCALE, (GameConstants.GAMEWINDOWHEIGHT / 8) + (letterDest[i + 1] + 40) * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                    Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], 7, 7);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                }
                if (counter < letterCount)
                {
                    Rectangle destination = new Rectangle((letterDest[counter * 2] + 15) * GameConstants.SCALE, (GameConstants.GAMEWINDOWHEIGHT / 8) + (letterDest[(counter * 2) + 1] + 40) * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                    Rectangle source = new Rectangle(9, 56, 7, 7);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                } else textSound.Stop();
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
