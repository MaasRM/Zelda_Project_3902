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
    public class Sprint5 : Game
    {
        private GraphicsDeviceManager _graphics;
        private ContentManager contentManager;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        private IPlayer link;
        private int frame;
        private Boolean title;
        private Boolean end;

        //Tuples are immutable turns out, so just update these instead on room switch
        private List<IBlock> blocks;
        private List<IItem> items;
        private List<INPC> npcs;
        private List<IProjectile> projectiles;
        private RoomManager roomManager;
        private Shop shop;
        private AllCollisionHandler allCollisionHandler;
        private PauseController pauseControls;
        private TitleScreen StartScreen;
        private TitleController titleControls;

        //Sound
        public List<SoundEffect> Collision_soundEffects;
        public List<SoundEffect> Link_soundEffects;
        public List<SoundEffect> Enemy_soundEffects;
        public List<SoundEffect> Text_soundEffects;
        private Song Title_music;
        private Song Overworld_music;
        private Song Dungeon_music;
        private Song Ending_music;
        private SongManager Songs;

        //xml string
        readonly String xmlLoc = "..\\..\\..\\Content\\ZeldaRoomLayout.xml";

        //text sprite
        private HintSprite hintSprite;
        private DeathMessageSprite deathMessageSprite;
        private TriForceText triForceSprite;

        public Sprint5()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            contentManager = new ContentManager(Content.ServiceProvider, Content.RootDirectory);
            contentManager.RootDirectory = "Content";
            title = true;
            end = false;
            controllerList = new List<IController>();
            frame = 0;
            roomManager = new RoomManager(this);
            blocks = new List<IBlock>();
            items = new List<IItem>();
            npcs = new List<INPC>();
            projectiles = new List<IProjectile>();
            Collision_soundEffects = new List<SoundEffect>();
            Enemy_soundEffects = new List<SoundEffect>();
            Link_soundEffects = new List<SoundEffect>();
            Text_soundEffects = new List<SoundEffect>();
        }

        protected override void Initialize()
        {
            KeyboardController keyControls = new KeyboardController();
            MouseController mouseControls = new MouseController(this);
            pauseControls = new PauseController();
            titleControls = new TitleController();
            controllerList.Add(keyControls);
            controllerList.Add(mouseControls);
            _graphics.PreferredBackBufferWidth = 255 * GameConstants.SCALE;
            _graphics.PreferredBackBufferHeight = (175 + GameConstants.HUDSIZE) * GameConstants.SCALE;
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
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetRed")); // 1 is red
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetBlack")); // 2 is black
            linkSheetList.Add(contentManager.Load<Texture2D>("LinkSpriteSheetBlue")); // 3 is blue

            enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies"));
            enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageOne"));
            enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageTwo"));
            enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageThree"));

            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses"));
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageOne"));
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageTwo"));
            bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageThree"));

            Texture2D dungeonSheet = contentManager.Load<Texture2D>("Dungeon_Tileset");
            Texture2D overworldSheet = contentManager.Load<Texture2D>("Overworld_Tileset");
            Texture2D npcSheet = contentManager.Load<Texture2D>("Zelda_NPCs");
            Texture2D itemsSheet = contentManager.Load<Texture2D>("Dungeon_Items");
            Texture2D inventory = contentManager.Load<Texture2D>("HUD_Pause_Screen");
            Texture2D titleSheet = contentManager.Load<Texture2D>("TitleScreen");

            //Songs
            Title_music = Content.Load<Song>("Intro");
            Overworld_music = Content.Load<Song>("Overworld");
            Dungeon_music = Content.Load<Song>("Dungeon");
            Ending_music = Content.Load<Song>("Ending");

            //Collision sound effects
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Scream1"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Hit"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Door_Unlock"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Die"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Hit"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Fanfare"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Heart"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Item"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Rupee"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Secret"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Stairs"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Shield"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Scream2"));

            //Link sound effects
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Arrow_Boomerang"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Blow"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Drop"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Candle"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_LowHealth"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Recorder"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Refill_Loop")); //not implemented
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Shoot"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Slash"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Link_Die"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Link_Hurt"));

            //Enemy sound effects
            Enemy_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Arrow_Boomerang"));
            Enemy_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Key_Appear"));

            //Text sound effects
            Text_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Text"));
            Text_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Text_Slow"));

            //SongManager
            Songs = new SongManager(Title_music, Overworld_music, Dungeon_music, Ending_music);

            link = new Link(contentManager.Load<Texture2D>("LinkSpriteSheet"), linkSheetList, Link_soundEffects, inventory);
            shop = new Shop(link, npcSheet, dungeonSheet, itemsSheet, roomManager, this);
            triForceSprite = new TriForceText(dungeonSheet, npcSheet, itemsSheet, this, link.GetLinkInventory().shards); 
            deathMessageSprite = new DeathMessageSprite(dungeonSheet, roomManager, Text_soundEffects[1].CreateInstance(), link, this);
            hintSprite = new HintSprite(dungeonSheet, roomManager, Text_soundEffects[1].CreateInstance(), link.GetLinkInventory().pauseScreen);

            StartScreen = new TitleScreen(titleSheet, this.GraphicsDevice.Viewport.Bounds.Width, this.GraphicsDevice.Viewport.Bounds.Height);

            XmlDocument doc = new XmlDocument();
            FileStream file = new FileStream(xmlLoc, FileMode.Open);
            doc.Load(file);
            file.Close();
            roomManager.SetUpRooms(doc, dungeonSheet, enemySheets, itemsSheet, bossSheets, npcSheet, overworldSheet);

            foreach (IController controller in controllerList)
            {
                controller.SetCommands(this);
            }
            pauseControls.SetCommands(this);
            titleControls.SetCommands(this);

            allCollisionHandler = new AllCollisionHandler(this.GraphicsDevice.Viewport.Bounds.X + WallConstants.LEFTWALL,
                                        this.GraphicsDevice.Viewport.Bounds.Width - WallConstants.RIGHTWALL,
                                        this.GraphicsDevice.Viewport.Bounds.Y + WallConstants.TOPWALL + GameConstants.HUDSIZE * GameConstants.SCALE,
                                        this.GraphicsDevice.Viewport.Bounds.Height - WallConstants.BOTTOMWALL, itemsSheet);
        }

        protected override void Update(GameTime gameTime)
        {
            int i;
            frame++;

            if (frame % 4 == 0)
            {
                if (title)
                {
                    StartScreen.Update();
                    titleControls.Update();
                }
                else if (end)
                {
                    //when the game is ending
                }
                else
                {
                    if (link.GetLinkInventory().pauseScreen.isGamePaused() == false && link.GetLinkInventory().pauseScreen.getCurrentYOffset() == 0)
                    {
                        foreach (IBlock block in blocks)
                        {
                            block.Update();
                        }
                        foreach (IItem item in items)
                        {
                            item.Update();
                        }
                        for (i = npcs.Count - 1; i >= 0; i--)
                        {
                            if (npcs[i] is Trap) EnemyProximityTrigger.CheckToTriggerTrap(link, (Trap)npcs[i]);
                            if (npcs[i] is Wallmaster) EnemyProximityTrigger.CheckToTriggerWallmaster(link, (Wallmaster)npcs[i]);
                            npcs[i].Update();
                            if (npcs[i] is IEnemy)
                            {
                                if (!((IEnemy)npcs[i]).StillAlive()) npcs.RemoveAt(i);
                            }
                        }
                        for (i = projectiles.Count - 1; i >= 0; i--)
                        {
                            projectiles[i].Update();
                            if (projectiles[i].CheckForRemoval()) projectiles.RemoveAt(i);
                        }

                        allCollisionHandler.CheckTraps(npcs);
                        allCollisionHandler.CheckWalls(link, npcs, roomManager, shop);
                        allCollisionHandler.PlayerItemCollisions(link, items, npcs, Collision_soundEffects, shop);
                        allCollisionHandler.BlockCollisions(link, npcs, blocks, roomManager, Collision_soundEffects);
                        allCollisionHandler.ProjectileCollisions(link, npcs, projectiles, Collision_soundEffects, items, roomManager);
                        allCollisionHandler.PlayerEnemyCollisions(link, npcs, Collision_soundEffects, items);

                        deathMessageSprite.Update();
                        CheckPlayer();

                        roomManager.Update();
                        
                        if (!roomManager.RoomChange() && !deathMessageSprite.isDrawing())
                        {
                            link.Update();
                            foreach (IController controller in controllerList)
                            {
                                controller.Update();
                            }
                        }
                        if (frame % 8 == 0)
                        {
                            hintSprite.Update();
                            shop.Update();
                            if (roomManager.getRoomIndex() == GameConstants.OUTSIDEROOM && !deathMessageSprite.isDrawing()) triForceSprite.Update();
                        }
                    }
                    else
                    {
                        pauseControls.Update();
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            this._spriteBatch.Begin();
            
            if (title)
            {
                StartScreen.Draw(this._spriteBatch);
            }
            else if (end)
            {
                //when the game is ending
            }
            else
            {
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

                hintSprite.Draw(this._spriteBatch);
                shop.Draw(this._spriteBatch);
                if (!deathMessageSprite.isDrawing()) triForceSprite.Draw(_spriteBatch);

                if (!roomManager.RoomChange())
                {
                    link.Draw(this._spriteBatch);
                }

                link.GetLinkInventory().Draw(this._spriteBatch);

                deathMessageSprite.Draw(this._spriteBatch);
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
        public SongManager GetSongManager()
        {
            return Songs;
        }

        public void AddProjectile(IProjectile projectile)
        {
            projectiles.Add(projectile);
        }

        public void RemoveProjectile(IProjectile projectile)
        {
            projectiles.Remove(projectile);
        }

        public List<IProjectile> GetProjectiles()
        {
            return projectiles;
        }

        public void RemoveItem(IItem item)
        {
            items.Remove(item);
        }

        public void SetBlocks(List<IBlock> newBlocks)
        {
            blocks = newBlocks;
        }

        public List<IItem> GetItems()
        {
            return items;
        }

        public Shop getShop()
        {
            return shop;
        }

        public void SetItems(List<IItem> newItems)
        {
            items = newItems;
        }

        public void SetNPCs(List<INPC> newNPCs)
        {
            npcs = newNPCs;
        }

        public void startGame()
        {
            title = false;
        }

        public TitleScreen TitleScreen()
        {
            return StartScreen;
        }

        public void ClearProjectiles()
        {
            foreach(IProjectile proj in projectiles)
            {
                if(proj is IBoomerang)
                {
                    ((IBoomerang)proj).StopSound();
                }
            }
            projectiles.Clear();
        }

        public void CheckPlayer()
        {
            if (!link.IsAlive())
            {
                foreach (INPC npc in npcs) if (npc is Goriya) ((Goriya)npc).StopThrowSound();
                List<Texture2D> enemySheets = new List<Texture2D>();
                List<Texture2D> bossSheets = new List<Texture2D>();

                enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies"));
                enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageOne"));
                enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageTwo"));
                enemySheets.Add(contentManager.Load<Texture2D>("Dungeon_Enemies_DamageThree"));

                bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses"));
                bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageOne"));
                bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageTwo"));
                bossSheets.Add(contentManager.Load<Texture2D>("Dungeon_Bosses_DamageThree"));

                Texture2D dungeonSheet = contentManager.Load<Texture2D>("Dungeon_Tileset");
                Texture2D overworldSheet = contentManager.Load<Texture2D>("Overworld_Tileset");
                Texture2D npcSheet = contentManager.Load<Texture2D>("Zelda_NPCs");
                Texture2D itemsSheet = contentManager.Load<Texture2D>("Dungeon_Items");

                roomManager.ChangeRoom(GameConstants.OUTSIDEROOM);

                XmlDocument doc = new XmlDocument();
                FileStream file = new FileStream(xmlLoc, FileMode.Open);
                doc.Load(file);
                roomManager.Reset(link.GetLinkInventory().getNoResetItems(), doc, dungeonSheet, enemySheets, itemsSheet, bossSheets, npcSheet, overworldSheet);
                file.Close();

                link.Reset(link.getLinkStateMachine().healthAndDamage.GetMaxHealth());
                link.Update();
                triForceSprite.Reset();
                for (int i = 0; i <= link.GetLinkInventory().getKeyCount(); i++) link.GetLinkInventory().removeKey();
            }
        }

        public void ResetTriForceText()
        {
            triForceSprite.Reset();
        }
    }
}
