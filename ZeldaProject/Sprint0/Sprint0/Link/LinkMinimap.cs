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
        private bool hasMap;
        private bool hasCompass;
        private int bossFrames;
        private DungeonMap theMap;

        public LinkMinimap(Texture2D inventory)
        {
            minimapTexture = inventory;
            hasMap = false;
            hasCompass = false;
            linkMinimapSource = new Rectangle(519, 126, 2, 2);
            linkMinimapDestination = new Rectangle(162, 175, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE);
            roomMinimapSource = new Rectangle(663, 109, 6, 2);
            bossFrames = 0;
            theMap = DungeonMap.Top;
        }

        public void Draw(SpriteBatch spriteBatch, int offset)
        {
            Rectangle tempLinkMinimapDestination = linkMinimapDestination;
            tempLinkMinimapDestination.Offset(0, offset);
            if (hasMap == true)
            {
                for (int room = 0; room <= 16; room++) {
                    spriteBatch.Draw(minimapTexture, getMinimapRoomDestinationSprite(room, offset), roomMinimapSource, Color.White);
                }
            }
            spriteBatch.Draw(minimapTexture, tempLinkMinimapDestination, linkMinimapSource, Color.White);
            if (hasCompass == true)
            {
                Rectangle bossRoomSourceRed = new Rectangle(537, 126, 2, 2);
                Rectangle bossRoomSourceBlue = new Rectangle(555, 127, 2, 2);
                Rectangle bossRoomDestination = new Rectangle(226, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE);
                if (theMap == DungeonMap.Left) { bossRoomDestination = new Rectangle(129, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
                else if (theMap == DungeonMap.Right) { bossRoomDestination = new Rectangle(228, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
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

        public Rectangle getLinkMinimapSourceSprite()
        {
            return linkMinimapSource;
        }

        public void setMinimap(bool val)
        {
            hasMap = val;
        }

        public void setCompass(bool val)
        {
            hasCompass = val;
        }

        public void setLinkMinimapDestinationSprite(int roomNumber, int offset)
        {
            setLinkDungeonLocation(roomNumber);
            if (theMap == DungeonMap.Top)
            {
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
            else if (theMap == DungeonMap.Left)
            {
                setLinkLeftMinimapDestinationSprite(roomNumber, offset);
            }
            else if (theMap == DungeonMap.Right)
            {
                setLinkRightMinimapDestinationSprite(roomNumber, offset);
            }
        }

        public void setLinkLeftMinimapDestinationSprite(int roomNumber, int offset)
        {
            if (roomNumber == 20) { linkMinimapDestination = new Rectangle(129, 80 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 21) { linkMinimapDestination = new Rectangle(195, 80 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 22) { linkMinimapDestination = new Rectangle(228, 80 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 23) { linkMinimapDestination = new Rectangle(129, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 24) { linkMinimapDestination = new Rectangle(195, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 25) { linkMinimapDestination = new Rectangle(228, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 26) { linkMinimapDestination = new Rectangle(129, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 27) { linkMinimapDestination = new Rectangle(162, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 28) { linkMinimapDestination = new Rectangle(195, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 29) { linkMinimapDestination = new Rectangle(228, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 30) { linkMinimapDestination = new Rectangle(195, 150 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
        }

        public void setLinkRightMinimapDestinationSprite(int roomNumber, int offset)
        {
            if (roomNumber == 31) { linkMinimapDestination = new Rectangle(129, 80 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 32) { linkMinimapDestination = new Rectangle(162, 80 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 33) { linkMinimapDestination = new Rectangle(129, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 34) { linkMinimapDestination = new Rectangle(162, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 35) { linkMinimapDestination = new Rectangle(228, 103 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 36) { linkMinimapDestination = new Rectangle(162, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 37) { linkMinimapDestination = new Rectangle(228, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 38) { linkMinimapDestination = new Rectangle(129, 150 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 39) { linkMinimapDestination = new Rectangle(162, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 40) { linkMinimapDestination = new Rectangle(195, 126 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 41) { linkMinimapDestination = new Rectangle(228, 150 + offset, 4 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
        }

        public void setLinkDungeonLocation(int roomNumber)
        {
            if (roomNumber >= 0 && roomNumber <= 16)
            {
                theMap = DungeonMap.Top;
            }
            else if (roomNumber >= 20 && roomNumber <= 30)
            {
                theMap = DungeonMap.Left;
            }
            else if (roomNumber >= 31 && roomNumber <= 41)
            {
                theMap = DungeonMap.Right;
            }
        }

        public DungeonMap getDungeonMap()
        {
            return theMap;
        }

        public Rectangle getMinimapRoomDestinationSprite(int roomNumber, int offset)
        {
            Rectangle roomMinimapDestination;
            if (theMap == DungeonMap.Top)
            {
                if (roomNumber == 0) { roomMinimapDestination = new Rectangle(121, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
                else if (roomNumber == 1) { roomMinimapDestination = new Rectangle(154, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
                else if (roomNumber == 2) { roomMinimapDestination = new Rectangle(154, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
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
            } 
            else if (theMap == DungeonMap.Left)
            {
                roomMinimapDestination = getMinimapLeftRoomDestinationSprite(roomNumber, offset);
            }
            else
            {
                roomMinimapDestination = getMinimapRightRoomDestinationSprite(roomNumber, offset);
            }
            return roomMinimapDestination;
        }

        public Rectangle getMinimapLeftRoomDestinationSprite(int roomNumber, int offset)
        {
            Rectangle roomMinimapDestination;
            if (roomNumber == 0) { roomMinimapDestination = new Rectangle(121, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 1) { roomMinimapDestination = new Rectangle(187, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 2) { roomMinimapDestination = new Rectangle(220, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 3) { roomMinimapDestination = new Rectangle(121, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 4) { roomMinimapDestination = new Rectangle(187, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 5) { roomMinimapDestination = new Rectangle(220, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 6) { roomMinimapDestination = new Rectangle(121, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 7) { roomMinimapDestination = new Rectangle(154, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 8) { roomMinimapDestination = new Rectangle(187, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 9) { roomMinimapDestination = new Rectangle(220, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else { roomMinimapDestination = new Rectangle(187, 150 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            return roomMinimapDestination;
        }

        public Rectangle getMinimapRightRoomDestinationSprite(int roomNumber, int offset)
        {
            Rectangle roomMinimapDestination;
            if (roomNumber == 0) { roomMinimapDestination = new Rectangle(121, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 1) { roomMinimapDestination = new Rectangle(154, 80 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 2) { roomMinimapDestination = new Rectangle(121, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 3) { roomMinimapDestination = new Rectangle(154, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 4) { roomMinimapDestination = new Rectangle(220, 103 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 5) { roomMinimapDestination = new Rectangle(154, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 6) { roomMinimapDestination = new Rectangle(220, 126 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 7) { roomMinimapDestination = new Rectangle(121, 150 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 8) { roomMinimapDestination = new Rectangle(154, 150 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else if (roomNumber == 9) { roomMinimapDestination = new Rectangle(187, 150 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            else { roomMinimapDestination = new Rectangle(220, 150 + offset, 8 * GameConstants.SCALE, 4 * GameConstants.SCALE); }
            return roomMinimapDestination;
        }
    }
}
