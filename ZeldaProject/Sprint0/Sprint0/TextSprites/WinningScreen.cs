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
        private int gameHeight;

        //x then y so grouped in twos
        //size is always 7x7
        readonly private int[] letterSource =
            { 49, 11, 97, 11, 89, 19, 65, 11, 105, 19, 41, 11, 113, 19, 121, 11, 81, 19, 41, 11, 113, 19, 73, 11, 97, 11, 89, 19, 113, 11, 33, 35, //Congratulations! (32)
              10, 27, 97, 11, 121, 11, //you (8)
              65, 27, 65, 19, 41, 11, 121, 19, 57, 11, // have (10)
              65, 27, 49, 19, 97, 11, 89, 11, 97, 19, 81, 19, 57, 11, 113, 19, 57, 11, 49, 19, // completed (20)
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
            { 464, 1050, 471, 1050, 478, 1050, 485, 1050, 492, 1050, 499, 1050, 506, 1050, 513, 1050, 520, 1050, 527, 1050, 534, 1050, 541, 1050, 548, 1050, 555, 1050, 562, 1050, 569, 1050, //Congratulations! (32)
              408, 1064, 415, 1064, 422, 1064, //you (8)
              429, 1064, 436, 1064, 443, 1064, 450, 1064, 457, 1064, // have (10)
              464, 1064, 471, 1064, 478, 1064, 485, 1064, 492, 1064, 499, 1064, 506, 1064, 513, 1064, 520, 1064, 527, 1064, // completed (20)
              534, 1064, 541, 1064, 548, 1064, 555, 1064, // the (8)
              562, 1064, 569, 1064, 576, 1064, 583, 1064, 590, 1064, 597, 1064, 604, 1064, 611, 1064, 618, 1064, 625, 1064, // triforce! (20)
              422, 1178, 429, 1178, 436, 1178, 443, 1178, //this (8)
              450, 1178, 457, 1178, 464, 1178, 471, 1178, 478, 1178, 485, 1178, 492, 1178, 499, 1178, 506, 1178, // artifact (18)
              513, 1178, 520, 1178, 527, 1178, 534, 1178, 541, 1178, // will (10)
              548, 1178, 555, 1178, 562, 1178, 569, 1178, 576, 1178, 583, 1178, // allow (6)
              590, 1178, 597, 1178, 604, 1178, 611, 1178, // you (8)
              418, 1185, 425, 1185, //to (4)
              432, 1185, 439, 1185, 446, 1185, 453, 1185, 460, 1185, 467, 1185, 474, 1185, 481, 1185, // restore (16)
              488, 1185, 495, 1185, 502, 1185, 509, 1185, 516, 1185, 523, 1185, // peace (12)
              530, 1185, 537, 1185, 544, 1185, // to (6)
              551, 1185, 558, 1185, 565, 1185, 572, 1185, // the (8)
              579, 1185, 586, 1185, 593, 1185, 600, 1185, 607, 1185, 614, 1185, // land! (10)
              453, 1199, 460, 1199, 467, 1199, 474, 1199, 481, 1199, 488, 1199, //thanks (12)
              495, 1199, 502, 1199, 509, 1199, 516, 1199, // for (8)
              523, 1199, 530, 1199, 537, 1199, 544, 1199, 551, 1199, 558, 1199, 565, 1199, 572, 1199, 579, 1199, // playing! (18)
              478, 1213, 485, 1213, 492, 1213, 499, 1213, 506, 1213, 513, 1213, 520, 1213, 527, 1213, 534, 1213, //developed (18)
              541, 1213, 548, 1213, 555, 1213, // by (6)
              481, 1227, 488, 1227, 495, 1227, 502, 1227, 509, 1227, 516, 1227, 523, 1227, 530, 1227, 537, 1227, 544, 1227, 551, 1227, //Jacob Kline (22)
              485, 1241, 492, 1241, 499, 1241, 506, 1241, 513, 1241, 520, 1241, 527, 1241, 534, 1241, 541, 1241, 548, 1241, //Jared Zins (20)
              471, 1255, 478, 1255, 485, 1255, 492, 1255, 499, 1255, 506, 1255, 513, 1255, 520, 1255, 527, 1255, 534, 1255, 541, 1255, 548, 1255, 555, 1255, 562, 1255, //Nathan Schultz (28)
              478, 1269, 485, 1269, 492, 1269, 499, 1269, 506, 1269, 41, 1269, 513, 1269, 520, 1269, 527, 1269, 534, 1269, 541, 1269, 548, 1269, //Phil Brocker (24)
              485, 1283, 492, 1283, 499, 1283, 506, 1283, 513, 1283, 520, 1283, 527, 1283, 534, 1283, 541, 1283, 548, 1283 //Riley Maas (20)
            };

        public WinningScreen(Texture2D dungeonSheet, RoomManager manager, SoundEffectInstance text, IPlayer link, Sprint5 game)
        {
            letterSheet = dungeonSheet;
            textSound = text;
            player = link;
            textSound.Volume = 0.25f;
            textSound.IsLooped = true;
            gameHeight = game.GraphicsDevice.Viewport.Bounds.Height;
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
                    Rectangle destination = new Rectangle((letterDest[i] + 8) * GameConstants.SCALE, (gameHeight / 8) + (letterDest[i + 1] + 40) * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
                    Rectangle source = new Rectangle(letterSource[i], letterSource[i + 1], 7, 7);
                    spriteBatch.Draw(letterSheet, destination, source, Color.White);
                }
                if (counter < letterCount)
                {
                    Rectangle destination = new Rectangle((letterDest[counter * 2] + 15) * GameConstants.SCALE, (gameHeight / 8) + (letterDest[(counter * 2) + 1] + 40) * GameConstants.SCALE, 7 * GameConstants.SCALE, 7 * GameConstants.SCALE);
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
