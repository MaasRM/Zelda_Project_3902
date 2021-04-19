using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Sprint0
{
    public class RoomManager
    {
        private Sprint5 game;
        private List<Room> roomList;
        private int roomIndex;
        private Room currentRoom;
        private Texture2D dungeonSheet;
        private bool roomChange;
        private Direction nextRoomDirection;
        private Rectangle nextRoomLoc;
        private Room oldRoom;
        private Rectangle oldRoomLoc;

        public RoomManager(Sprint5 game)
        {
            this.game = game;
            roomList = new List<Room>();
            roomIndex = GameConstants.OUTSIDEROOM;
            roomChange = false;
        }

        public void SetUpRooms(XmlDocument xmlDoc, Texture2D dungeon, List<Texture2D> enemies, Texture2D items, List<Texture2D> bosses, Texture2D npcs, Texture2D overworld)
        {
            dungeonSheet = dungeon;
            RoomBuilder builder = new RoomBuilder(game, xmlDoc, dungeon, enemies, items, bosses, npcs, overworld, new List<IItem>());
            roomList = builder.buildRoomList();
            currentRoom = roomList[GameConstants.OUTSIDEROOM];
        }

        public void Update()
        {
            if(roomChange)
            {
                switch (nextRoomDirection)
                {
                    case Direction.Up:
                        nextRoomLoc = new Rectangle(nextRoomLoc.X, nextRoomLoc.Y + (5 * GameConstants.SCALE), 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                        oldRoomLoc = new Rectangle(oldRoomLoc.X, oldRoomLoc.Y + (5 * GameConstants.SCALE), 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                        break;
                    case Direction.Down:
                        nextRoomLoc = new Rectangle(nextRoomLoc.X, nextRoomLoc.Y - (5 * GameConstants.SCALE), 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                        oldRoomLoc = new Rectangle(oldRoomLoc.X, oldRoomLoc.Y - (5 * GameConstants.SCALE), 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                        break;
                    case Direction.Left:
                        nextRoomLoc = new Rectangle(nextRoomLoc.X + (5 * GameConstants.SCALE), nextRoomLoc.Y, 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                        oldRoomLoc = new Rectangle(oldRoomLoc.X + (5 * GameConstants.SCALE), oldRoomLoc.Y, 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                        break;
                    case Direction.Right:
                        nextRoomLoc = new Rectangle(nextRoomLoc.X - (5 * GameConstants.SCALE), nextRoomLoc.Y, 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                        oldRoomLoc = new Rectangle(oldRoomLoc.X - (5 * GameConstants.SCALE), oldRoomLoc.Y, 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                        break;
                    default:
                        break;
                }
                if (nextRoomLoc.X == 0 && nextRoomLoc.Y == 0) roomChange = false;
            } else
            {
                game.GetPlayer().GetLinkInventory().linkMinimap.setLinkMinimapDestinationSprite(roomIndex, 0);
                game.SetBlocks(currentRoom.getBlocks());
                if(roomIndex != GameConstants.SHOPROOM) game.SetItems(currentRoom.getItems());
                game.SetNPCs(currentRoom.getNPCs());
            }
            if((currentRoom.RoomNum() ==3 || currentRoom.RoomNum() == 10) && currentRoom.getNPCs().Count == 0)
            {
                UnlockDoor(Direction.Right);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 displacement = new Vector2(0, -64);
            if (roomChange)
            {
                Rectangle nextRoomFloorLoc = new Rectangle(nextRoomLoc.X + (32 * GameConstants.SCALE), nextRoomLoc.Y + (32 * GameConstants.SCALE), 192 * GameConstants.SCALE, 112 * GameConstants.SCALE);
                Rectangle nextRoomTopDoorLoc = new Rectangle(nextRoomLoc.X + (112 * GameConstants.SCALE), nextRoomLoc.Y + (0 * GameConstants.SCALE), 32 * GameConstants.SCALE, 32 * GameConstants.SCALE);
                Rectangle nextRoomBottomDoorLoc = new Rectangle(nextRoomLoc.X + (112 * GameConstants.SCALE), nextRoomLoc.Y + (144 * GameConstants.SCALE), 32 * GameConstants.SCALE, 32 * GameConstants.SCALE);
                Rectangle nextRoomLeftDoorLoc = new Rectangle(nextRoomLoc.X + (0 * GameConstants.SCALE), nextRoomLoc.Y + (72 * GameConstants.SCALE), 32 * GameConstants.SCALE, 32 * GameConstants.SCALE);
                Rectangle nextRoomRightDoorLoc = new Rectangle(nextRoomLoc.X + (224 * GameConstants.SCALE), nextRoomLoc.Y + (72 * GameConstants.SCALE), 32 * GameConstants.SCALE, 32 * GameConstants.SCALE);
                spriteBatch.Draw(dungeonSheet, nextRoomLoc, currentRoom.getWall(), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomTopDoorLoc, currentRoom.getDoorSource(Direction.Up), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomBottomDoorLoc, currentRoom.getDoorSource(Direction.Down), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomLeftDoorLoc, currentRoom.getDoorSource(Direction.Left), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomRightDoorLoc, currentRoom.getDoorSource(Direction.Right), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomFloorLoc, currentRoom.getFloor(), Color.White, 0, displacement, SpriteEffects.None, 0f);
                Rectangle oldRoomFloorLoc = new Rectangle(oldRoomLoc.X + (32 * GameConstants.SCALE), oldRoomLoc.Y + (32 * GameConstants.SCALE), 192 * GameConstants.SCALE, 112 * GameConstants.SCALE);
                Rectangle oldRoomTopDoorLoc = new Rectangle(oldRoomLoc.X + (112 * GameConstants.SCALE), oldRoomLoc.Y + (0 * GameConstants.SCALE), 32 * GameConstants.SCALE, 32 * GameConstants.SCALE);
                Rectangle oldRoomBottomDoorLoc = new Rectangle(oldRoomLoc.X + (112 * GameConstants.SCALE), oldRoomLoc.Y + (144 * GameConstants.SCALE), 32 * GameConstants.SCALE, 32 * GameConstants.SCALE);
                Rectangle oldRoomLeftDoorLoc = new Rectangle(oldRoomLoc.X + (0 * GameConstants.SCALE), oldRoomLoc.Y + (72 * GameConstants.SCALE), 32 * GameConstants.SCALE, 32 * GameConstants.SCALE);
                Rectangle oldRoomRightDoorLoc = new Rectangle(oldRoomLoc.X + (224 * GameConstants.SCALE), oldRoomLoc.Y + (72 * GameConstants.SCALE), 32 * GameConstants.SCALE, 32 * GameConstants.SCALE);
                spriteBatch.Draw(dungeonSheet, oldRoomLoc, oldRoom.getWall(), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomTopDoorLoc, oldRoom.getDoorSource(Direction.Up), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomBottomDoorLoc, oldRoom.getDoorSource(Direction.Down), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomLeftDoorLoc, oldRoom.getDoorSource(Direction.Left), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomRightDoorLoc, oldRoom.getDoorSource(Direction.Right), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomFloorLoc, oldRoom.getFloor(), Color.White, 0, displacement, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(dungeonSheet, new Rectangle(0 * GameConstants.SCALE, 0 * GameConstants.SCALE, 255 * GameConstants.SCALE, 175 * GameConstants.SCALE), currentRoom.getWall(), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(112 * GameConstants.SCALE, 0 * GameConstants.SCALE, 32 * GameConstants.SCALE, 32 * GameConstants.SCALE), currentRoom.getDoorSource(Direction.Up), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(112 * GameConstants.SCALE, 144 * GameConstants.SCALE, 32 * GameConstants.SCALE, 32 * GameConstants.SCALE), currentRoom.getDoorSource(Direction.Down), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(0 * GameConstants.SCALE, 72 * GameConstants.SCALE, 32 * GameConstants.SCALE, 32 * GameConstants.SCALE), currentRoom.getDoorSource(Direction.Left), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(224 * GameConstants.SCALE, 72 * GameConstants.SCALE, 32 * GameConstants.SCALE, 32 * GameConstants.SCALE), currentRoom.getDoorSource(Direction.Right), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(32 * GameConstants.SCALE, 32 * GameConstants.SCALE, 192 * GameConstants.SCALE, 112 * GameConstants.SCALE), currentRoom.getFloor(), Color.White, 0, displacement, SpriteEffects.None, 0f);
            }

        }

        public void NextRoom()
        {
            roomIndex++;
            if (roomIndex >= roomList.Count) roomIndex = 0;
            currentRoom = roomList[roomIndex];
            game.ClearProjectiles();
        }

        public void PreviousRoom()
        {
            roomIndex--;
            if (roomIndex < 0) roomIndex = roomList.Count - 1;
            currentRoom = roomList[roomIndex];
            game.ClearProjectiles();
        }

        public Boolean SwapRoom(Direction dir)
        {
            int index = currentRoom.getAdjacentRoomIndex(dir);
            if (index != -1 && (currentRoom.getDoorSource(dir).X == 815 + 33 || currentRoom.getDoorSource(dir).X == 815 + 132))
            {
                roomIndex = index;
                oldRoom = currentRoom;
                currentRoom = roomList[roomIndex];
                roomChange = true;
                ResetRoomObjects();
                game.ClearProjectiles();
                game.SetBlocks(new List<IBlock>());
                game.SetItems(new List<IItem>());
                game.SetNPCs(new List<INPC>());
                SetNextRoomLoc(dir);
                ResetRoomObjects();
            }
            return roomChange;
        }

        private void SetNextRoomLoc(Direction dir)
        {
            nextRoomDirection = dir;
            oldRoomLoc = new Rectangle(0, 0, 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
            switch (dir)
            {
                case Direction.Up:
                    nextRoomLoc = new Rectangle(0, 0 - (175 * GameConstants.SCALE), 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                    break;
                case Direction.Down:
                    nextRoomLoc = new Rectangle(0, 0 + (175 * GameConstants.SCALE), 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                    break;
                case Direction.Left:
                    nextRoomLoc = new Rectangle(0 - (255 * GameConstants.SCALE), 0, 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                    break;
                case Direction.Right:
                    nextRoomLoc = new Rectangle(0 + (255 * GameConstants.SCALE), 0, 255 * GameConstants.SCALE, 175 * GameConstants.SCALE);
                    break;
                default:
                    nextRoomLoc = new Rectangle(0, 0, 0, 0);
                    break;
            }
        }

        public Boolean BlowDoor(Direction dir)
        {
            int index = currentRoom.getAdjacentRoomIndex(dir);
            Boolean blow = false;
            if (index != -1 && currentRoom.getDoorSource(dir).X == 815)
            {
                currentRoom.setDoorSource(dir, new Rectangle(815 + 132, currentRoom.getDoorSource(dir).Y, 32, 32));
                Direction oppDir;
                switch (dir)
                {
                    case Direction.Up:
                        oppDir = Direction.Down;
                        break;
                    case Direction.Down:
                        oppDir = Direction.Up;
                        break;
                    case Direction.Left:
                        oppDir = Direction.Right;
                        break;
                    case Direction.Right:
                        oppDir = Direction.Left;
                        break;
                    default:
                        oppDir = Direction.Down;
                        break;
                }
                roomList[currentRoom.getAdjacentRoomIndex(dir)].setDoorSource(oppDir, new Rectangle(815 + 132, currentRoom.getDoorSource(oppDir).Y, 32, 32));
                blow = true;
            }
            return blow;
        }

        public Boolean UnlockDoor(Direction dir)
        {
            int index = currentRoom.getAdjacentRoomIndex(dir);
            Boolean unlock = false;
            if (index != -1 && (currentRoom.getDoorSource(dir).X == 815 + 66 || currentRoom.getDoorSource(dir).X == 815 + 99))
            {
                currentRoom.setDoorSource(dir, new Rectangle(815 + 33, currentRoom.getDoorSource(dir).Y, 32, 32));
                game.Collision_soundEffects[2].Play();
                unlock = true;
            }
            return unlock;
        }

        public void ChangeRoom(int newRoom)
        {
            Boolean fromShopOrWM = false;
            ResetRoomObjects();
            int oldRoom = roomIndex;
            roomIndex = newRoom;

            if(currentRoom.RoomNum() == GameConstants.SHOPROOM || currentRoom.RoomNum() == GameConstants.WALLMASTERROOM) fromShopOrWM = true;

            currentRoom = roomList[roomIndex];
            game.ClearProjectiles();

            if (roomIndex == GameConstants.VERTICALROOMTOP) game.GetPlayer().getLinkStateMachine().SetPositions(new Rectangle(48 * GameConstants.SCALE, GameConstants.HUDSIZE * GameConstants.SCALE, game.GetPlayer().LinkPosition().Width, game.GetPlayer().LinkPosition().Height));
            if (roomIndex == GameConstants.VERTICALROOMBOTTOM)
            {
                if(oldRoom == 25) game.GetPlayer().getLinkStateMachine().SetPositions(new Rectangle(48 * GameConstants.SCALE, GameConstants.HUDSIZE * GameConstants.SCALE, game.GetPlayer().LinkPosition().Width, game.GetPlayer().LinkPosition().Height));
                else game.GetPlayer().getLinkStateMachine().SetPositions(new Rectangle(48 * GameConstants.SCALE, GameConstants.HUDSIZE * GameConstants.SCALE, game.GetPlayer().LinkPosition().Width, game.GetPlayer().LinkPosition().Height));
            } else if (roomIndex == GameConstants.STARTROOM) game.GetPlayer().getLinkStateMachine().SetPositions(new Rectangle(LinkConstants.XINIT * GameConstants.SCALE, LinkConstants.YINIT * GameConstants.SCALE, game.GetPlayer().LinkPosition().Width, game.GetPlayer().LinkPosition().Height));
            else if (roomIndex == GameConstants.OUTSIDEROOM && !fromShopOrWM) game.GetPlayer().getLinkStateMachine().SetPositions(new Rectangle(LinkConstants.XINIT * GameConstants.SCALE, LinkConstants.YINIT * GameConstants.SCALE, game.GetPlayer().LinkPosition().Width, game.GetPlayer().LinkPosition().Height));

            if (roomIndex == GameConstants.STARTROOM && !fromShopOrWM) game.GetSongManager().Dungeon();
            else if (roomIndex == GameConstants.OUTSIDEROOM && !fromShopOrWM) game.GetSongManager().Overworld();
        }

        public bool RoomChange()
        {
            return roomChange;
        }

        public Room Room()
        {
            return currentRoom;
        }

        public int getRoomIndex()
        {
            return roomIndex;
        }

        public void Reset(List<IItem> noReset, XmlDocument xmlDoc, Texture2D dungeon, List<Texture2D> enemies, Texture2D items, List<Texture2D> bosses, Texture2D npcs, Texture2D overworld)
        {
            RoomBuilder builder = new RoomBuilder(game, xmlDoc, dungeon, enemies, items, bosses, npcs, overworld, noReset);
            roomList = builder.buildRoomList();
            currentRoom = roomList[GameConstants.OUTSIDEROOM];
        }

        private void ResetRoomObjects()
        {
            foreach(IBlock block in currentRoom.getBlocks())
            {
                block.ResetBlock();
            }

            foreach (INPC npc in currentRoom.getNPCs())
            {
                npc.Reset();

                if(npc is Goriya)
                {
                    ((Goriya)npc).StopThrowSound();
                }
            }
        }
    }
}