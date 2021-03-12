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
        private Texture2D enemiesSheet;
        private Texture2D itemsSheet;
        private Texture2D bossesSheet;
        private Texture2D npcSheet;

        public RoomManager(Sprint3 game)
        {
            this.game = game;
            roomList = new List<Room>();
            roomIndex = 0;
        }

        public void SetUpRooms(XmlDocument xmlDoc, Texture2D dungeon, Texture2D enemies, Texture2D items, Texture2D bosses, Texture2D npcs)
        {
            dungeonSheet = dungeon;
            enemiesSheet = enemies;
            itemsSheet = bosses;
            bossesSheet = bosses;
            npcSheet = npcs;

            XmlNode root = xmlDoc["Rooms"];
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                XmlNode currentRoom = root.ChildNodes[i];
                List<IBlock> blockList = new List<IBlock>();
                for (int b = 0; b < currentRoom["Blocks"].ChildNodes.Count; b++)
                {
                    blockList.Add(CreateBlock(currentRoom["Blocks"].ChildNodes[b]));
                }
                List<IItem> itemList = new List<IItem>();
                for (int it = 0; it < currentRoom["Items"].ChildNodes.Count; it++)
                {
                    itemList.Add(CreateItem(currentRoom["Items"].ChildNodes[it]));
                }
                List<INPC> npcList = new List<INPC>();
                for (int n = 0; n < currentRoom["Enemies"].ChildNodes.Count; n++)
                {
                    npcList.Add(CreateNPC(currentRoom["Enemies"].ChildNodes[n]));
                }
                Rectangle floor = new Rectangle(int.Parse(currentRoom["Background"]["XLoc"].InnerText), int.Parse(currentRoom["Background"]["YLoc"].InnerText), 191, 111);
                Rectangle walls = new Rectangle(521, 11, 255, 175);
                Rectangle topDoor = GetDoorSource("top", currentRoom["Doors"]["UpDoor"]["DoorType"].InnerText);
                Rectangle bottomDoor = GetDoorSource("bottom", currentRoom["Doors"]["DownDoor"]["DoorType"].InnerText);
                Rectangle leftDoor = GetDoorSource("left", currentRoom["Doors"]["LeftDoor"]["DoorType"].InnerText);
                Rectangle rightDoor = GetDoorSource("right", currentRoom["Doors"]["RightDoor"]["DoorType"].InnerText);
                roomList.Add(new Room(blockList, itemList, npcList, floor, walls, topDoor, bottomDoor, leftDoor, rightDoor));
            }
            currentRoom = roomList[0];
        }

        private IBlock CreateBlock(XmlNode blockInfo)
        {
            return new Block(int.Parse(blockInfo.InnerText), dungeonSheet);
        }

        private IItem CreateItem(XmlNode itemInfo)
        {
            switch (itemInfo["ItemType"].InnerText)
            {
                case "KeyItem":
                    return new KeyItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText), int.Parse(itemInfo["YLoc"].InnerText), 7, 15), new Rectangle(240, 0, 7, 15), itemsSheet);
                case "HeartContainerItem":
                    return new HeartContainerItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText), int.Parse(itemInfo["YLoc"].InnerText), 15, 15), new Rectangle(23, 0, 15, 15), itemsSheet);
                case "TriforceShardItem":
                    return new TriforceShardItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText), int.Parse(itemInfo["YLoc"].InnerText), 15, 15), new Rectangle(272, 0, 15, 15), itemsSheet);
                case "Fire":
                    return new Fire(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText), int.Parse(itemInfo["YLoc"].InnerText), 15, 15), new Rectangle(52, 11, 15, 15), npcSheet);
                case "MapItem":
                    return new MapItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText), int.Parse(itemInfo["YLoc"].InnerText), 7, 15), new Rectangle(88, 0, 7, 15), itemsSheet);
                case "CompassItem":
                    return new CompassItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText), int.Parse(itemInfo["YLoc"].InnerText), 15, 15), new Rectangle(256, 0, 15, 15), itemsSheet);
                default:
                    return new KeyItem(new Rectangle(0, 0, 7, 15), new Rectangle(240, 0, 7, 15), itemsSheet);
            }
        }

        private INPC CreateNPC(XmlNode npcInfo)
        {
            switch (npcInfo["EnemyType"].InnerText)
            {
                case "Aquamentus":
                    return new Aquamentus(int.Parse(npcInfo["XLoc"].InnerText), int.Parse(npcInfo["YLoc"].InnerText), bossesSheet, game);
                case "Gel":
                    return new Gel(int.Parse(npcInfo["XLoc"].InnerText), int.Parse(npcInfo["YLoc"].InnerText), GelStateMachine.GelColor.Teal, enemiesSheet);
                case "Goriya":
                    return new Goriya(int.Parse(npcInfo["XLoc"].InnerText), int.Parse(npcInfo["YLoc"].InnerText), GoriyaStateMachine.GoriyaColor.Blue, enemiesSheet, game);
                case "Keese":
                    return new Keese(int.Parse(npcInfo["XLoc"].InnerText), int.Parse(npcInfo["YLoc"].InnerText), KeeseStateMachine.KeeseColor.Blue, enemiesSheet);
                case "OldMan":
                    return new OldMan(int.Parse(npcInfo["XLoc"].InnerText), int.Parse(npcInfo["YLoc"].InnerText), enemiesSheet);
                case "Stalfos":
                    return new Stalfos(int.Parse(npcInfo["XLoc"].InnerText), int.Parse(npcInfo["YLoc"].InnerText), enemiesSheet);
                case "Trap":
                    return new Trap(int.Parse(npcInfo["XLoc"].InnerText), int.Parse(npcInfo["YLoc"].InnerText), enemiesSheet);
                case "Wallmaster":
                    return new Wallmaster(int.Parse(npcInfo["XLoc"].InnerText), int.Parse(npcInfo["YLoc"].InnerText), WallmasterStateMachine.Direction.Up ,enemiesSheet); //Should this be up?
                default:
                    return new Aquamentus(0, 0, bossesSheet, game);
            }
        }

        private Rectangle GetDoorSource(String direction, String doorType)
        {
            int yOffset = 0;
            int xOffset = 0;
            switch (direction)
            {
                case "top":
                    yOffset = 0;
                    break;
                case "bottom":
                    yOffset = 99;
                    break;
                case "left":
                    yOffset = 33;
                    break;
                case "right":
                    yOffset = 66;
                    break;
                default:
                    break;
            }
            switch (doorType)
            {
                case "Wall":
                    xOffset = 0;
                    break;
                case "OpenDoor":
                    xOffset = 33;
                    break;
                case "LockedDoor":
                    xOffset = 66;
                    break;
                case "ClosedDoor":
                    xOffset = 99;
                    break;
                case "BlownDoor":
                    xOffset = 132;
                    break;
                default:
                    break;
            }
            return new Rectangle(815 + xOffset, 11 + yOffset, 32, 32);
        }

        public void Update()
        {
            game.SetBlocks(currentRoom.getBlocks());
            game.SetItems(currentRoom.getItems());
            game.SetNPCs(currentRoom.getNPCs());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(dungeonSheet, new Rectangle(0, 0, 255, 175), currentRoom.getWall(), Color.White);
            spriteBatch.Draw(dungeonSheet, new Rectangle(32, 32, 191, 111), currentRoom.getFloor(), Color.White);
            spriteBatch.Draw(dungeonSheet, new Rectangle(112, 0, 31, 31), currentRoom.getTopDoor(), Color.White);
            spriteBatch.Draw(dungeonSheet, new Rectangle(112, 144, 31, 31), currentRoom.getBottomDoor(), Color.White);
            spriteBatch.Draw(dungeonSheet, new Rectangle(0, 72, 31, 31), currentRoom.getLeftDoor(), Color.White);
            spriteBatch.Draw(dungeonSheet, new Rectangle(224, 72, 31, 31), currentRoom.getRightDoor(), Color.White);
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
    }
}