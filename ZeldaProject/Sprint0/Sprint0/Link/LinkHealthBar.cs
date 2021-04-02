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
        private int currentHealth;

        public LinkHealthBar(Texture2D inventory)
        {
            healthTexture = inventory;
            fullHeartSource = new Rectangle(645, 118, 7, 7);
            halfHeartSource = new Rectangle(636, 118, 7, 7);
            currentHealth = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void setCurrentHealth(int health)
        {
            currentHealth = health;
        }
    }
}
