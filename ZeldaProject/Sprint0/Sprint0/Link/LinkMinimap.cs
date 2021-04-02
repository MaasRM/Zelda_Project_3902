using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkMinimap
    {
        private Rectangle linkMinimapSource;
        private Rectangle linkMinimapDestination;
        private Texture2D minimapTexture;

        public LinkMinimap(Texture2D inventory)
        {
            minimapTexture = inventory;
            linkMinimapSource = new Rectangle(519, 126, 4, 4);
            linkMinimapDestination = new Rectangle(162, 175, 4 * 4, 4 * 4);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(minimapTexture, linkMinimapDestination, linkMinimapSource, Color.White);
        }

        public Rectangle getLinkMinimapSourceSprite()
        {
            return linkMinimapSource;
        }

        public void setLinkMinimapDestinationSprite(int roomNumber)
        {
            if (roomNumber == 0)
            {
                linkMinimapDestination = new Rectangle(129, 80, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 1)
            {
                linkMinimapDestination = new Rectangle(162, 80, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 2)
            {
                linkMinimapDestination = new Rectangle(164, 103, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 3)
            {
                linkMinimapDestination = new Rectangle(226, 103, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 4)
            {
                linkMinimapDestination = new Rectangle(259, 103, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 5)
            {
                linkMinimapDestination = new Rectangle(96, 126, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 6)
            {
                linkMinimapDestination = new Rectangle(129, 126, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 7)
            {
                linkMinimapDestination = new Rectangle(162, 126, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 8)
            {
                linkMinimapDestination = new Rectangle(194, 126, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 9)
            {
                linkMinimapDestination = new Rectangle(226, 126, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 10)
            {
                linkMinimapDestination = new Rectangle(129, 150, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 11)
            {
                linkMinimapDestination = new Rectangle(162, 150, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 12)
            {
                linkMinimapDestination = new Rectangle(194, 150, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 13)
            {
                linkMinimapDestination = new Rectangle(162, 174, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 14)
            {
                linkMinimapDestination = new Rectangle(129, 197, 4 * 4, 4 * 4);
            }
            else if (roomNumber == 15)
            {
                linkMinimapDestination = new Rectangle(162, 197, 4 * 4, 4 * 4);
            }
            else
            {
                linkMinimapDestination = new Rectangle(194, 197, 4 * 4, 4 * 4);
            }
        }
    }
}
