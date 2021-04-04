using Microsoft.Xna.Framework;
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
        private Rectangle emptyHeartSource;
        private int maxHealth;
        private int currentHealth;

        public LinkHealthBar(Texture2D inventory)
        {
            healthTexture = inventory;
            fullHeartSource = new Rectangle(645, 117, 7, 8);
            halfHeartSource = new Rectangle(636, 117, 7, 8);
            emptyHeartSource = new Rectangle(627, 117, 7, 8);
            currentHealth = 0;
            maxHealth = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int currentInRow = 0;
            int currentY = 148;
            int currentX = 710;
            DrawMaxHearts(spriteBatch);
            if (currentHealth % 2 == 0)
            {
                int numberOfHearts = currentHealth / 2;
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

        public void DrawMaxHearts(SpriteBatch spriteBatch)
        {
            int currentInRow = 0;
            int currentY = 148;
            int currentX = 710;
            if (maxHealth % 2 == 0)
            {
                int numberOfHearts = maxHealth / 2;
                for (int n = 0; n <= numberOfHearts; n++)
                {
                    spriteBatch.Draw(healthTexture, new Rectangle(currentX, currentY, 8 * 4, 8 * 4), emptyHeartSource, Color.White);
                    currentInRow++;
                    currentX += 32;
                    if (currentInRow % 8 == 0)
                    {
                        currentX -= 256;
                        currentY += 34;
                        currentInRow = 0;
                    }
                }
            }
        }

        public void setCurrentHealth(int health)
        {
            currentHealth = health;
        }

        public void addCurrentHealth(int health)
        {
            if ((currentHealth += health) <= maxHealth)
            {
                currentHealth += health;
            } else
            {
                currentHealth = maxHealth;
            }
        }

        public void addMaxHealth(int health)
        {
            maxHealth += health;
        }

        public void setMaxHealth(int health)
        {
            maxHealth = health;
        }
    }
}
