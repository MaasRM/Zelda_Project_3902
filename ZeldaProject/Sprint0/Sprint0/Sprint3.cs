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
        private List<Texture2D> linkSheetList;
        public IPlayer link;
        public Texture2D dungeonSheet;
        private int frame;

        //Tuples are immutable turns out, so just update these instead on room switch
        private List<IBlock> blocks;
        private List<IItem> items;
        private List<INPC> npcs;
        private List<IProjectile> projectiles;
        private RoomManager roomManager;

        public Sprint3()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            controllerList = new List<IController>();
            linkSheetList = new List<Texture2D>();
            frame = 0;
            roomManager = new RoomManager();
            contentManager = new ContentManager(Content.ServiceProvider, Content.RootDirectory);
            contentManager.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            KeyboardController keyControls = new KeyboardController();
            MouseController mouseControls = new MouseController(this);
            controllerList.Add(keyControls);
            controllerList.Add(mouseControls);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheet")); // 0 is green
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetBlack")); // 1 is black
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetRed")); // 2 is red
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetBlue")); // 3 is blue
            link = new Link(contentManager.Load<Texture2D>("LinkSpriteSheet"), linkSheetList);
            dungeonSheet = contentManager.Load<Texture2D>("Dungeon_Tileset");
            XmlDocument doc = new XmlDocument();
            doc.Load(new FileStream("ZeldaRoomLayout.xml", FileMode.Open));
            roomManager.SetUpRooms(doc, dungeonSheet);

            foreach(IController controller in controllerList)
            {
                controller.SetCommands(this);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            frame++;

            if (frame % 4 == 0)
            {
                //Call updates for Link, Enemies, Blocks, etc.
                link.Update();
                roomManager.Update();

                foreach (IBlock block in blocks)
                {
                    block.Update();
                }
                foreach (IItem item in items)
                {
                    item.Update();
                }
                foreach (INPC npc in npcs)
                {
                    npc.Update();
                }
                foreach (IProjectile proj in projectiles)
                {
                    proj.Update();
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
            link.Draw(this._spriteBatch);
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

            this._spriteBatch.End();

            base.Draw(gameTime);
        }

        public IPlayer GetPlayer()
        {
            return link;
        }      

        public Texture2D GetEnemySpriteSheet()
        {
            return contentManager.Load<Texture2D>("Dungeon_Enemies");
        }

        public Texture2D GetItemSpriteSheet()
        {
            return contentManager.Load<Texture2D>("Dungeon_Items");
        }

        public Texture2D GetBossSpriteSheet()
        {
            return contentManager.Load<Texture2D>("Dungeon_Bosses");
        }

        public Texture2D GetNPCSpriteSheet()
        {
            return contentManager.Load<Texture2D>("Zelda_NPCs");
        }

        public void AddProjectile(IProjectile projectile)
        {
            projectiles.Add(projectile);
        }

        public void RemoveProjectile(IProjectile projectile)
        {
            projectiles.Remove(projectile);
        }
    }
}
