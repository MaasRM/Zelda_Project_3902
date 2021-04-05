using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Sprint0
{
    class RoomBuilder
    {
        private Sprint3 game;
        private XmlDocument xmlDoc;
        private Texture2D dungeonSheet;
        private List<Texture2D> enemiesSheets;
        private Texture2D itemsSheet;
        private List<Texture2D> bossesSheets;
        private Texture2D npcSheet;
        private const int scale = 4;

        public RoomBuilder(Sprint3 game, XmlDocument doc, Texture2D dungeon, List<Texture2D> enemies, Texture2D items, List<Texture2D> bosses, Texture2D npcs)
        {
            this.game = game;
            xmlDoc = doc;
            dungeonSheet = dungeon;
            enemiesSheets = enemies;
            itemsSheet = items;
            bossesSheets = bosses;
            npcSheet = npcs;
        }

        public List<Room> buildRoomList()
        {
            XmlNode root = xmlDoc["Rooms"];
            List<Room> roomList = new List<Room>();
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                XmlNode currentRoom = root.ChildNodes[i];
                List<IBlock> blockList = new List<IBlock>();
                for (int b = 0; b < currentRoom["Blocks"].ChildNodes.Count; b++)
                {
                    blockList.Add(CreateBlock(currentRoom["Blocks"].ChildNodes[b]));
                }
                List<INPC> npcList = new List<INPC>();
                for (int n = 0; n < currentRoom["Enemies"].ChildNodes.Count; n++)
                {
                    npcList.Add(CreateNPC(currentRoom["Enemies"].ChildNodes[n]));
                }
                List<IItem> itemList = new List<IItem>();
                for (int it = 0; it < currentRoom["Items"].ChildNodes.Count; it++)
                {
                    itemList.Add(CreateItem(currentRoom["Items"].ChildNodes[it], npcList));
                }
                Rectangle floor = new Rectangle(int.Parse(currentRoom["Background"]["XLoc"].InnerText), int.Parse(currentRoom["Background"]["YLoc"].InnerText), 192, 112);
                Rectangle walls = new Rectangle(521, 11, 255, 175);
                Rectangle topDoor = GetDoorSource("top", currentRoom["Doors"]["UpDoor"]["DoorType"].InnerText);
                Rectangle bottomDoor = GetDoorSource("bottom", currentRoom["Doors"]["DownDoor"]["DoorType"].InnerText);
                Rectangle leftDoor = GetDoorSource("left", currentRoom["Doors"]["LeftDoor"]["DoorType"].InnerText);
                Rectangle rightDoor = GetDoorSource("right", currentRoom["Doors"]["RightDoor"]["DoorType"].InnerText);
                int roomNum = int.Parse(currentRoom["Info"]["RoomNumber"].InnerText);
                int[] nextRoomNums = new int[4];
                nextRoomNums[0] = int.Parse(currentRoom["Info"]["TopRoomNumber"].InnerText);
                nextRoomNums[1] = int.Parse(currentRoom["Info"]["BottomRoomNumber"].InnerText);
                nextRoomNums[2] = int.Parse(currentRoom["Info"]["LeftRoomNumber"].InnerText);
                nextRoomNums[3] = int.Parse(currentRoom["Info"]["RightRoomNumber"].InnerText);
                roomList.Add(new Room(blockList, itemList, npcList, floor, walls, topDoor, bottomDoor, leftDoor, rightDoor, roomNum, nextRoomNums));
            }
            return roomList;
        }

        private IBlock CreateBlock(XmlNode blockInfo)
        {
            XmlNode parent = blockInfo.ParentNode;
            //Edited
            return new Block(int.Parse(blockInfo["BlockType"].InnerText), dungeonSheet, (int.Parse(blockInfo["XLoc"].InnerText)) * scale, (int.Parse(blockInfo["YLoc"].InnerText) + 64) * scale);
        }

        private IItem CreateItem(XmlNode itemInfo, List<INPC> npcList)
        {
            switch (itemInfo["ItemType"].InnerText)
            {
                case "KeyItem":
                    return new KeyItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText) * scale, (int.Parse(itemInfo["YLoc"].InnerText) + 64) * scale, 7 * scale, 15 * scale), new Rectangle(240, 0, 7, 15), itemsSheet, game);
                case "HeartContainerItem":
                    return new HeartContainerItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText) * scale, (int.Parse(itemInfo["YLoc"].InnerText) + 64) * scale, 15 * scale, 15 * scale), new Rectangle(23, 0, 15, 15), itemsSheet);
                case "TriforceShardItem":
                    return new TriforceShardItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText) * scale, (int.Parse(itemInfo["YLoc"].InnerText) + 64) * scale, 15 * scale, 15 * scale), new Rectangle(272, 0, 15, 15), itemsSheet);
                case "Fire":
                    return new Fire(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText) * scale, (int.Parse(itemInfo["YLoc"].InnerText) + 64) * scale, 15 * scale, 15 * scale), new Rectangle(52, 11, 15, 15), npcSheet);
                case "MapItem":
                    return new MapItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText) * scale, (int.Parse(itemInfo["YLoc"].InnerText) + 64) * scale, 7 * scale, 15 * scale), new Rectangle(88, 0, 7, 15), itemsSheet);
                case "CompassItem":
                    return new CompassItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText) * scale, (int.Parse(itemInfo["YLoc"].InnerText) + 64) * scale, 15 * scale, 15 * scale), new Rectangle(256, 0, 15, 15), itemsSheet);
                case "BowItem":
                    return new BowItem(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText) * scale, (int.Parse(itemInfo["YLoc"].InnerText) + 64) * scale, 7 * scale, 15 * scale), new Rectangle(144, 0, 7, 15), itemsSheet);
                case "SecretKeyItem":
                    return new SecretKey(new Rectangle(int.Parse(itemInfo["XLoc"].InnerText) * scale, (int.Parse(itemInfo["YLoc"].InnerText) + 64) * scale, 7 * scale, 15 * scale), new Rectangle(240, 0, 7, 15), itemsSheet, npcList, game);
                case "EnemyKeyItem":
                    return new EnemyKey(new Rectangle(240, 0, 7, 15), itemsSheet, npcList[0], game);
                default:
                    return new KeyItem(new Rectangle(0, 0, 7, 15), new Rectangle(240, 0, 7, 15), itemsSheet, game);
            }
        }

        private INPC CreateNPC(XmlNode npcInfo)
        {
            switch (npcInfo["EnemyType"].InnerText)
            {
                case "Aquamentus":
                    return new Aquamentus(int.Parse(npcInfo["XLoc"].InnerText) * scale, (int.Parse(npcInfo["YLoc"].InnerText) + 64) * scale, bossesSheets, game);
                case "Gel":
                    return new Gel(int.Parse(npcInfo["XLoc"].InnerText) * scale, (int.Parse(npcInfo["YLoc"].InnerText) + 64) * scale, GelStateMachine.GelColor.Teal, enemiesSheets[0]);
                case "Goriya":
                    return new Goriya(int.Parse(npcInfo["XLoc"].InnerText) * scale, (int.Parse(npcInfo["YLoc"].InnerText) + 64) * scale, GoriyaStateMachine.GoriyaColor.Red, enemiesSheets, game);
                case "Keese":
                    return new Keese(int.Parse(npcInfo["XLoc"].InnerText) * scale, (int.Parse(npcInfo["YLoc"].InnerText) + 64) * scale, KeeseStateMachine.KeeseColor.Blue, enemiesSheets[0]);
                case "OldMan":
                    return new OldMan(int.Parse(npcInfo["XLoc"].InnerText) * scale, (int.Parse(npcInfo["YLoc"].InnerText) + 64) * scale, npcSheet);
                case "Stalfos":
                    return new Stalfos(int.Parse(npcInfo["XLoc"].InnerText) * scale, (int.Parse(npcInfo["YLoc"].InnerText) + 64) * scale, enemiesSheets);
                case "Trap":
                    return new Trap(int.Parse(npcInfo["XLoc"].InnerText) * scale, (int.Parse(npcInfo["YLoc"].InnerText) + 64) * scale, enemiesSheets[0]);
                case "Wallmaster":
                    return new Wallmaster(int.Parse(npcInfo["XLoc"].InnerText) * scale, (int.Parse(npcInfo["YLoc"].InnerText) + 64) * scale, WallmasterStateMachine.Direction.Up, enemiesSheets); //Should this be up?
                default:
                    return new Aquamentus(0, 0, bossesSheets, game);
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
    }
}