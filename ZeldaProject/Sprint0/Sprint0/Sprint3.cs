using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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

        //Sound
        public List<SoundEffect> soundEffects;
        private Song Title_music;
        private Song Dungeon_music;

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
            soundEffects = new List<SoundEffect>();
        }

        protected override void Initialize()
        {
            KeyboardController keyControls = new KeyboardController();
            MouseController mouseControls = new MouseController(this);
            controllerList.Add(keyControls);
            controllerList.Add(mouseControls);
            _graphics.PreferredBackBufferWidth = 255 * 4;
            _graphics.PreferredBackBufferHeight = (175 + 64) * 4;
            _graphics.ApplyChanges();
            base.Initialize();
            roomManager.Update();
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
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageOne"));
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageTwo"));
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageThree"));

            Texture2D npcSheet = contentManager.Load<Texture2D>("Zelda_NPCs");

            XmlDocument doc = new XmlDocument();
            doc.Load(new FileStream("..\\..\\..\\Content\\ZeldaRoomLayout.xml", FileMode.Open));
            roomManager.SetUpRooms(doc, dungeonSheet , enemySheets, itemsSheet, bossSheets, npcSheet);

            foreach(IController controller in controllerList)
            {
                controller.SetCommands(this);
            }

            allCollisionHandler = new AllCollisionHandler(this.GraphicsDevice.Viewport.Bounds.X, this.GraphicsDevice.Viewport.Bounds.Width, this.GraphicsDevice.Viewport.Bounds.Y, this.GraphicsDevice.Viewport.Bounds.Height);


            //Songs
            Title_music = Content.Load<Song>("Intro");
            Dungeon_music = Content.Load<Song>("Dungeon");

            //(a lot of) Sounds
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Arrow_Boomerang"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Blow"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Drop"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Hit"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Scream1"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Candle"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Door_Unlock"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Die"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Hit"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Fanfare"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Heart"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Item"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Rupee"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Key_Appear"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Link_Die"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Link_Hurt"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_LowHealth"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Recorder"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Refill_Loop"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Secret"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Stairs"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Shoot"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Slash"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Text"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Text_Slow"));

            //should probably be moved later
            MediaPlayer.Play(Dungeon_music);
            MediaPlayer.Volume = 0.25f;
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            int i;
            frame++;

            if (frame % 4 == 0)
            {
                //Call updates for Link, Enemies, Blocks, etc.

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

                roomManager.Update();
                if (!roomManager.RoomChange())
                {
                    link.Update();
                    foreach (IController controller in controllerList)
                    {
                        controller.Update();
                    }
                }
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

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

            if (!roomManager.RoomChange())
            {
                link.Draw(this._spriteBatch);
            }

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
