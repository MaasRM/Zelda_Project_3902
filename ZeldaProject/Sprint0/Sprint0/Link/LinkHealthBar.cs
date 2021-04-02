﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkHealthBar
    {
        private Texture2D healthTexture;
        private Rectangle fullHeartSource;
        private Rectangle halfHeartSource;
        private int currentHealth;

        public LinkHealthBar(Texture2D inventory)
        {
            healthTexture = inventory;
            fullHeartSource = new Rectangle(645, 117, 7, 8);
            halfHeartSource = new Rectangle(636, 117, 7, 8);
            currentHealth = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentHealth % 2 == 0)
            {
                int numberOfHearts = currentHealth / 2;
                int currentInRow = 0;
                int currentY = 148;
                int currentX = 710;

                for(int n = 0; n <= numberOfHearts; n ++)
                {
                    spriteBatch.Draw(healthTexture, new Rectangle(currentX, currentY, 8 * 4, 8 * 4), fullHeartSource, Color.White);
                    currentInRow++;
                    currentX += 32;
                    if(currentInRow % 8 == 0)
                    {
                        currentX -= 256;
                        currentY += 34;
                        currentInRow = 0;
                    }
                }
            }
            else
            {
                int numberOfHearts = (currentHealth-1) / 2;
                int currentInRow = 0;
                int currentY = 148;
                int currentX = 710;

                for (int n = 0; n <= numberOfHearts; n++)
                {
                    spriteBatch.Draw(healthTexture, new Rectangle(currentX, currentY, 8 * 4, 8 * 4), fullHeartSource, Color.White);
                    currentInRow++;
                    currentX += 32;
                    if (currentInRow % 8 == 0)
                    {
                        currentX -= 256;
                        currentY += 34;
                        currentInRow = 0;
                    }
                }
                spriteBatch.Draw(healthTexture, new Rectangle(currentX, currentY, 8 * 4, 8 * 4), halfHeartSource, Color.White);
            }
        }

        public void setCurrentHealth(int health)
        {
            currentHealth = health;
        }
    }
}
