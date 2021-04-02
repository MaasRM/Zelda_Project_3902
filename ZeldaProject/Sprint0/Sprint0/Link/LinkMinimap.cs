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
        private Rectangle roomMinimapSource;
        private Texture2D minimapTexture;
        private Boolean hasMap;
        private List<int> visitedRooms;

        public LinkMinimap(Texture2D inventory)
        {
            minimapTexture = inventory;
            visitedRooms = new List<int>();
            visitedRooms.Add(15);
            hasMap = false;
            linkMinimapSource = new Rectangle(519, 126, 2, 2);
            linkMinimapDestination = new Rectangle(162, 175, 4 * 4, 4 * 4);
            roomMinimapSource = new Rectangle(663, 109, 6, 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (hasMap == true)
            {
                foreach(int room in visitedRooms){
                    spriteBatch.Draw(minimapTexture, getMinimapRoomDestinationSprite(room), roomMinimapSource, Color.White);
                }
            }
            spriteBatch.Draw(minimapTexture, linkMinimapDestination, linkMinimapSource, Color.White);
        }

        public Rectangle getLinkMinimapSourceSprite()
        {
            return linkMinimapSource;
        }

        public void setMinimap(Boolean val)
        {
            hasMap = val;
        }

        public void setLinkMinimapDestinationSprite(int roomNumber)
        {
            if (!visitedRooms.Contains(roomNumber))
            {
                visitedRooms.Add(roomNumber);
            }

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

        public Rectangle getMinimapRoomDestinationSprite(int roomNumber)
        {
            Rectangle roomMinimapDestination;
            
            if (roomNumber == 0)
            {
                roomMinimapDestination = new Rectangle(121, 80, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 1)
            {
                roomMinimapDestination = new Rectangle(154, 80, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 2)
            {
                roomMinimapDestination = new Rectangle(156, 103, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 3)
            {
                roomMinimapDestination = new Rectangle(218, 103, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 4)
            {
                roomMinimapDestination = new Rectangle(251, 103, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 5)
            {
                roomMinimapDestination = new Rectangle(88, 126, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 6)
            {
                roomMinimapDestination = new Rectangle(121, 126, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 7)
            {
                roomMinimapDestination = new Rectangle(154, 126, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 8)
            {
                roomMinimapDestination = new Rectangle(186, 126, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 9)
            {
                roomMinimapDestination = new Rectangle(218, 126, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 10)
            {
                roomMinimapDestination = new Rectangle(121, 150, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 11)
            {
                roomMinimapDestination = new Rectangle(154, 150, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 12)
            {
                roomMinimapDestination = new Rectangle(186, 150, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 13)
            {
                roomMinimapDestination = new Rectangle(154, 174, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 14)
            {
                roomMinimapDestination = new Rectangle(121, 197, 8 * 4, 4 * 4);
            }
            else if (roomNumber == 15)
            {
                roomMinimapDestination = new Rectangle(154, 197, 8 * 4, 4 * 4);
            }
            else
            {
                roomMinimapDestination = new Rectangle(186, 197, 8 * 4, 4 * 4);
            }

            return roomMinimapDestination;
        }
    }
}
