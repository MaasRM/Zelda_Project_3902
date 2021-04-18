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
        private Boolean hasCompass;
        private List<int> visitedRooms;
        private int bossFrames;
        private DungeonMap theMap;

        public LinkMinimap(Texture2D inventory)
        {
            minimapTexture = inventory;
            visitedRooms = new List<int>();
            for(int n = 0; n <= 16; n++) { visitedRooms.Add(n); }
            hasMap = false;
            hasCompass = false;
            linkMinimapSource = new Rectangle(519, 126, 2, 2);
            linkMinimapDestination = new Rectangle(162, 175, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE);
            roomMinimapSource = new Rectangle(663, 109, 6, 2);
            bossFrames = 0;
            theMap = DungeonMap.Main;
        }

        public void Draw(SpriteBatch spriteBatch, int offset, DungeonMap theMap)
        {
            Rectangle tempLinkMinimapDestination = linkMinimapDestination;
            tempLinkMinimapDestination.Offset(0, offset);
            if (hasMap == true)
            {
                foreach(int room in visitedRooms){
                    spriteBatch.Draw(minimapTexture, getMinimapRoomDestinationSprite(room, offset), roomMinimapSource, Color.White);
                }
            }
            spriteBatch.Draw(minimapTexture, tempLinkMinimapDestination, linkMinimapSource, Color.White);
            if (hasCompass == true)
            {
                Rectangle bossRoomSourceRed = new Rectangle(537, 126, 2, 2);
                Rectangle bossRoomSourceBlue = new Rectangle(555, 127, 2, 2);
                Rectangle bossRoomDestination = new Rectangle(226, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE);
                if (bossFrames % 2 == 0)
                {
                    spriteBatch.Draw(minimapTexture, bossRoomDestination, bossRoomSourceRed, Color.White);
                }
                else
                {
                    spriteBatch.Draw(minimapTexture, bossRoomDestination, bossRoomSourceBlue, Color.White);
                }
                bossFrames++;
            }
        }

        public void DrawMainRooms(SpriteBatch spriteBatch, int offset)
        {

        }

        public Rectangle getLinkMinimapSourceSprite()
        {
            return linkMinimapSource;
        }

        public void setMinimap(Boolean val)
        {
            hasMap = val;
        }

        public void setCompass(Boolean val)
        {
            hasCompass = val;
        }

        public void setLinkMinimapDestinationSprite(int roomNumber, int offset)
        {
            if (!visitedRooms.Contains(roomNumber)) { visitedRooms.Add(roomNumber); }
            if (roomNumber == 0) { linkMinimapDestination = new Rectangle(129, 80 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 1) { linkMinimapDestination = new Rectangle(162, 80 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 2) { linkMinimapDestination = new Rectangle(164, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 3) { linkMinimapDestination = new Rectangle(226, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 4) { linkMinimapDestination = new Rectangle(259, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 5) { linkMinimapDestination = new Rectangle(96, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 6) { linkMinimapDestination = new Rectangle(129, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 7) { linkMinimapDestination = new Rectangle(162, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 8) { linkMinimapDestination = new Rectangle(194, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 9) { linkMinimapDestination = new Rectangle(226, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 10) { linkMinimapDestination = new Rectangle(129, 150 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 11) { linkMinimapDestination = new Rectangle(162, 150 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 12) { linkMinimapDestination = new Rectangle(194, 150 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 13) { linkMinimapDestination = new Rectangle(162, 174 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 14) { linkMinimapDestination = new Rectangle(129, 197 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 15) { linkMinimapDestination = new Rectangle(162, 197 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else { linkMinimapDestination = new Rectangle(194, 197 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
        }

        public Rectangle getMinimapRoomDestinationSprite(int roomNumber, int offset)
        {
            Rectangle roomMinimapDestination;
            if (roomNumber == 0) { roomMinimapDestination = new Rectangle(121, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 1) { roomMinimapDestination = new Rectangle(154, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 2) { roomMinimapDestination = new Rectangle(156, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 3) { roomMinimapDestination = new Rectangle(218, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 4) { roomMinimapDestination = new Rectangle(251, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 5) { roomMinimapDestination = new Rectangle(88, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 6) { roomMinimapDestination = new Rectangle(121, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 7) { roomMinimapDestination = new Rectangle(154, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 8) { roomMinimapDestination = new Rectangle(186, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 9) { roomMinimapDestination = new Rectangle(218, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 10) { roomMinimapDestination = new Rectangle(121, 150 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 11) { roomMinimapDestination = new Rectangle(154, 150 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 12) { roomMinimapDestination = new Rectangle(186, 150 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 13) { roomMinimapDestination = new Rectangle(154, 174 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 14) { roomMinimapDestination = new Rectangle(121, 197 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 15) { roomMinimapDestination = new Rectangle(154, 197 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else { roomMinimapDestination = new Rectangle(186, 197 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            return roomMinimapDestination;
        }
    }
}
