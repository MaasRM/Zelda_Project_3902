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
        private Sprint3 game;
        private List<Room> roomList;
        private int roomIndex;
        private Room currentRoom;
        private Texture2D dungeonSheet;
        private bool roomChange;
        private Direction nextRoomDirection;
        private Rectangle nextRoomLoc;
        private Room oldRoom;
        private Rectangle oldRoomLoc;
        private const int scale = 4;
        private const int FIRSTROOM = 15;

        public RoomManager(Sprint3 game)
        {
            this.game = game;
            roomList = new List<Room>();
            roomIndex = 15;
            roomChange = false;
        }

        public void SetUpRooms(XmlDocument xmlDoc, Texture2D dungeon, List<Texture2D> enemies, Texture2D items, List<Texture2D> bosses, Texture2D npcs)
        {
            dungeonSheet = dungeon;
            RoomBuilder builder = new RoomBuilder(game, xmlDoc, dungeon, enemies, items, bosses, npcs);
            roomList = builder.buildRoomList();
            currentRoom = roomList[FIRSTROOM];
        }

        public void Update()
        {
            if(roomChange)
            {
                switch (nextRoomDirection)
                {
                    case Direction.MoveUp:
                        nextRoomLoc = new Rectangle(nextRoomLoc.X, nextRoomLoc.Y + (5 * scale), 255 * scale, 175 * scale);
                        oldRoomLoc = new Rectangle(oldRoomLoc.X, oldRoomLoc.Y + (5 * scale), 255 * scale, 175 * scale);
                        break;
                    case Direction.MoveDown:
                        nextRoomLoc = new Rectangle(nextRoomLoc.X, nextRoomLoc.Y - (5 * scale), 255 * scale, 175 * scale);
                        oldRoomLoc = new Rectangle(oldRoomLoc.X, oldRoomLoc.Y - (5 * scale), 255 * scale, 175 * scale);
                        break;
                    case Direction.MoveLeft:
                        nextRoomLoc = new Rectangle(nextRoomLoc.X + (5 * scale), nextRoomLoc.Y, 255 * scale, 175 * scale);
                        oldRoomLoc = new Rectangle(oldRoomLoc.X + (5 * scale), oldRoomLoc.Y, 255 * scale, 175 * scale);
                        break;
                    case Direction.MoveRight:
                        nextRoomLoc = new Rectangle(nextRoomLoc.X - (5 * scale), nextRoomLoc.Y, 255 * scale, 175 * scale);
                        oldRoomLoc = new Rectangle(oldRoomLoc.X - (5 * scale), oldRoomLoc.Y, 255 * scale, 175 * scale);
                        break;
                    default:
                        break;
                }
                if (nextRoomLoc.X == 0 && nextRoomLoc.Y == 0) roomChange = false;
            } else
            {
                game.GetPlayer().GetLinkInventory().GetLinkMinimap().setLinkMinimapDestinationSprite(roomIndex);
                game.SetBlocks(currentRoom.getBlocks());
                game.SetItems(currentRoom.getItems());
                game.SetNPCs(currentRoom.getNPCs());
            }
            if((currentRoom.RoomNum() ==3 || currentRoom.RoomNum() == 10) && currentRoom.getNPCs().Count == 0)
            {
                UnlockDoor(Direction.MoveRight);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 displacement = new Vector2(0, -64);
            if (roomChange)
            {
                Rectangle nextRoomFloorLoc = new Rectangle(nextRoomLoc.X + (32 * scale), nextRoomLoc.Y + (32 * scale), 192 * scale, 112 * scale);
                Rectangle nextRoomTopDoorLoc = new Rectangle(nextRoomLoc.X + (112 * scale), nextRoomLoc.Y + (0 * scale), 32 * scale, 32 * scale);
                Rectangle nextRoomBottomDoorLoc = new Rectangle(nextRoomLoc.X + (112 * scale), nextRoomLoc.Y + (144 * scale), 32 * scale, 32 * scale);
                Rectangle nextRoomLeftDoorLoc = new Rectangle(nextRoomLoc.X + (0 * scale), nextRoomLoc.Y + (72 * scale), 32 * scale, 32 * scale);
                Rectangle nextRoomRightDoorLoc = new Rectangle(nextRoomLoc.X + (224 * scale), nextRoomLoc.Y + (72 * scale), 32 * scale, 32 * scale);
                spriteBatch.Draw(dungeonSheet, nextRoomLoc, currentRoom.getWall(), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomTopDoorLoc, currentRoom.getDoorSource(Direction.MoveUp), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomBottomDoorLoc, currentRoom.getDoorSource(Direction.MoveDown), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomLeftDoorLoc, currentRoom.getDoorSource(Direction.MoveLeft), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomRightDoorLoc, currentRoom.getDoorSource(Direction.MoveRight), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, nextRoomFloorLoc, currentRoom.getFloor(), Color.White, 0, displacement, SpriteEffects.None, 0f);
                Rectangle oldRoomFloorLoc = new Rectangle(oldRoomLoc.X + (32 * scale), oldRoomLoc.Y + (32 * scale), 192 * scale, 112 * scale);
                Rectangle oldRoomTopDoorLoc = new Rectangle(oldRoomLoc.X + (112 * scale), oldRoomLoc.Y + (0 * scale), 32 * scale, 32 * scale);
                Rectangle oldRoomBottomDoorLoc = new Rectangle(oldRoomLoc.X + (112 * scale), oldRoomLoc.Y + (144 * scale), 32 * scale, 32 * scale);
                Rectangle oldRoomLeftDoorLoc = new Rectangle(oldRoomLoc.X + (0 * scale), oldRoomLoc.Y + (72 * scale), 32 * scale, 32 * scale);
                Rectangle oldRoomRightDoorLoc = new Rectangle(oldRoomLoc.X + (224 * scale), oldRoomLoc.Y + (72 * scale), 32 * scale, 32 * scale);
                spriteBatch.Draw(dungeonSheet, oldRoomLoc, oldRoom.getWall(), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomTopDoorLoc, oldRoom.getDoorSource(Direction.MoveUp), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomBottomDoorLoc, oldRoom.getDoorSource(Direction.MoveDown), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomLeftDoorLoc, oldRoom.getDoorSource(Direction.MoveLeft), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomRightDoorLoc, oldRoom.getDoorSource(Direction.MoveRight), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, oldRoomFloorLoc, oldRoom.getFloor(), Color.White, 0, displacement, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(dungeonSheet, new Rectangle(0 * scale, 0 * scale, 255 * scale, 175 * scale), currentRoom.getWall(), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(112 * scale, 0 * scale, 32 * scale, 32 * scale), currentRoom.getDoorSource(Direction.MoveUp), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(112 * scale, 144 * scale, 32 * scale, 32 * scale), currentRoom.getDoorSource(Direction.MoveDown), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(0 * scale, 72 * scale, 32 * scale, 32 * scale), currentRoom.getDoorSource(Direction.MoveLeft), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(224 * scale, 72 * scale, 32 * scale, 32 * scale), currentRoom.getDoorSource(Direction.MoveRight), Color.White, 0, displacement, SpriteEffects.None, 0f);
                spriteBatch.Draw(dungeonSheet, new Rectangle(32 * scale, 32 * scale, 192 * scale, 112 * scale), currentRoom.getFloor(), Color.White, 0, displacement, SpriteEffects.None, 0f);
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
                game.ClearProjectiles();
                game.SetBlocks(new List<IBlock>());
                game.SetItems(new List<IItem>());
                game.SetNPCs(new List<INPC>());
                ResetRoomObjects();
                SetNextRoomLoc(dir);
            }
            return roomChange;
        }

        private void SetNextRoomLoc(Direction dir)
        {
            nextRoomDirection = dir;
            oldRoomLoc = new Rectangle(0, 0, 255 * scale, 175 * scale);
            switch (dir)
            {
                case Direction.MoveUp:
                    nextRoomLoc = new Rectangle(0, 0 - (175 * scale), 255 * scale, 175 * scale);
                    break;
                case Direction.MoveDown:
                    nextRoomLoc = new Rectangle(0, 0 + (175 * scale), 255 * scale, 175 * scale);
                    break;
                case Direction.MoveLeft:
                    nextRoomLoc = new Rectangle(0 - (255 * scale), 0, 255 * scale, 175 * scale);
                    break;
                case Direction.MoveRight:
                    nextRoomLoc = new Rectangle(0 + (255 * scale), 0, 255 * scale, 175 * scale);
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
                    case Direction.MoveUp:
                        oppDir = Direction.MoveDown;
                        break;
                    case Direction.MoveDown:
                        oppDir = Direction.MoveUp;
                        break;
                    case Direction.MoveLeft:
                        oppDir = Direction.MoveRight;
                        break;
                    case Direction.MoveRight:
                        oppDir = Direction.MoveLeft;
                        break;
                    default:
                        oppDir = Direction.MoveDown;
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
            roomIndex = newRoom;
            currentRoom = roomList[roomIndex];
            game.ClearProjectiles();

            if (roomIndex == 17)
            {
                game.GetPlayer().getLinkStateMachine().SetPositions(new Rectangle(48 * scale, 64 * scale, game.GetPlayer().LinkPosition().Width, game.GetPlayer().LinkPosition().Height));
            }
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

        private void ResetRoomObjects()
        {
            foreach(IBlock block in currentRoom.getBlocks())
            {
                block.ResetBlock();
            }

            foreach (INPC npc in currentRoom.getNPCs())
            {
                npc.Reset();
            }
        }
    }
}