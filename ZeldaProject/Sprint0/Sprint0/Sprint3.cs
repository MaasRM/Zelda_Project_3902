using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Sprint0
{
    public class Sprint3 : Game
    {
        private GraphicsDeviceManager _graphics;
        private ContentManager contentManager;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        public IPlayer link;
        private int frame;

        //Tuples are immutable turns out, so just update these instead on room switch
        private List<IBlock> blocks;
        private List<IItem> items;
        private List<INPC> npcs;
        private List<IProjectile> projectiles;
        private RoomManager roomManager;
        private AllCollisionHandler allCollisionHandler;

        public Sprint3()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            contentManager = new ContentManager(Content.ServiceProvider, Content.RootDirectory);
            contentManager.RootDirectory = "Content";

            controllerList = new List<IController>();
            frame = 0;
            roomManager = new RoomManager(this);
            blocks = new List<IBlock>();
            items = new List<IItem>();
            npcs = new List<INPC>();
            projectiles = new List<IProjectile>();
        }

        protected override void Initialize()
        {
            KeyboardController keyControls = new KeyboardController();
            MouseController mouseControls = new MouseController(this);
            controllerList.Add(keyControls);
            controllerList.Add(mouseControls);
            _graphics.PreferredBackBufferWidth = 255 * 4;
            _graphics.PreferredBackBufferHeight = 175 * 4;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            List<Texture2D> enemySheets = new List<Texture2D>();
            List<Texture2D> bossSheets = new List<Texture2D>();
            List<Texture2D> linkSheetList = new List<Texture2D>();
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheet")); // 0 is green
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetBlack")); // 1 is black
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetRed")); // 2 is red
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetBlue")); // 3 is blue
            link = new Link(contentManager.Load<Texture2D>("LinkSpriteSheet"), linkSheetList);

            Texture2D dungeonSheet = contentManager.Load<Texture2D>("Dungeon_Tileset");

            enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies"));
            enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageOne"));
            enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageTwo"));
            enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageThree"));

            Texture2D itemsSheet = contentManager.Load<Texture2D>("Dungeon_Items");

            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses"));
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageOne"));
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageTwo"));
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageThree"));

            Texture2D npcSheet = contentManager.Load<Texture2D>("Zelda_NPCs");

            XmlDocument doc = new XmlDocument();
            doc.Load(new FileStream("..\\..\\..\\Content\\ZeldaRoomLayout.xml", FileMode.Open));
            roomManager.SetUpRooms(doc, dungeonSheet , enemiesSheets, itemsSheet, bossesSheets, npcSheet);

            foreach(IController controller in controllerList)
            {
                controller.SetCommands(this);
            }

            allCollisionHandler = new AllCollisionHandler(this.GraphicsDevice.Viewport.Bounds.X, this.GraphicsDevice.Viewport.Bounds.Width, this.GraphicsDevice.Viewport.Bounds.Y, this.GraphicsDevice.Viewport.Bounds.Height);
        }

        protected override void Update(GameTime gameTime)
        {
            int i;
            frame++;

            if (frame % 4 == 0)
            {
                //Call updates for Link, Enemies, Blocks, etc.
                link.Update();

                foreach (IBlock block in blocks)
                {
                    block.Update();
                }
                foreach (IItem item in items)
                {
                    item.Update();
                }
                for(i = npcs.Count-1; i >= 0; i--)
                {
                    npcs[i].Update();
                    if(npcs[i] is IEnemy)
                    {
                        if(!((IEnemy)npcs[i]).StillAlive())
                        {
                            npcs.RemoveAt(i);
                        }
                    }
                }
                for(i = projectiles.Count-1; i >= 0; i--)
                {
                    projectiles[i].Update();
                    if(projectiles[i].CheckForRemoval())
                    {
                        projectiles.RemoveAt(i);
                    }
                }

                allCollisionHandler.HandleCollisions(link, npcs, items, blocks, projectiles, roomManager);

                if (roomManager.RoomChange())
                {
                    roomManager.Update();
                    roomManager.RoomFixed();
                }

                foreach (IController controller in controllerList)
                {
                    controller.Update();
                }
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this._spriteBatch.Begin();

            //Call draw for Link, Enemies, Blocks, etc
            roomManager.Draw(this._spriteBatch);
            
            foreach (IBlock block in blocks)
            {
                block.Draw(this._spriteBatch);
            }
            foreach (IItem item in items)
            {
                item.Draw(this._spriteBatch);
            }
            foreach (INPC npc in npcs)
            {
                npc.Draw(this._spriteBatch);
            }
            foreach (IProjectile proj in projectiles)
            {
                proj.Draw(this._spriteBatch);
            }

            link.Draw(this._spriteBatch);

            this._spriteBatch.End();

            base.Draw(gameTime);
        }

        public IPlayer GetPlayer()
        {
            return link;
        }

        public RoomManager GetRoomManager()
        {
            return roomManager;
        }

        public void AddProjectile(IProjectile projectile)
        {
            projectiles.Add(projectile);
        }

        public void RemoveProjectile(IProjectile projectile)
        {
            projectiles.Remove(projectile);
        }

        public void RemoveItem(IItem item)
        {
            items.Remove(item);
        }

        public void SetBlocks(List<IBlock> newBlocks)
        {
            blocks = newBlocks;
        }

        public void SetItems(List<IItem> newItems)
        {
            items = newItems;
        }

        public void SetNPCs(List<INPC> newNPCs)
        {
            npcs = newNPCs;
        }

        public void ClearProjectiles()
        {
            projectiles.Clear();
        }
    }
}
