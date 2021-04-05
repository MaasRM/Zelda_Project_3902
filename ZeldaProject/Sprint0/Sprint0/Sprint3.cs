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
        private IPlayer link;
        private int frame;

        //Tuples are immutable turns out, so just update these instead on room switch
        private List<IBlock> blocks;
        private List<IItem> items;
        private List<INPC> npcs;
        private List<IProjectile> projectiles;
        private RoomManager roomManager;
        private AllCollisionHandler allCollisionHandler;
        private PauseController pauseControls;

        //Sound
        public List<SoundEffect> Collision_soundEffects;
        public List<SoundEffect> Link_soundEffects;
        public List<SoundEffect> Enemy_soundEffects;
        public List<SoundEffect> Text_soundEffects;
        private Song Title_music;
        private Song Dungeon_music;

        //text sprite
        private TextSprite textSprite;

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

            Texture2D inventory = contentManager.Load<Texture2D>("HUD_Pause_Screen");

            //Songs
            Title_music = Content.Load<Song>("Intro");
            Dungeon_music = Content.Load<Song>("Dungeon");

            //Collision sound effects
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Scream1")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Hit")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Door_Unlock")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Die")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Hit")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Fanfare"));
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Heart")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Item")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Get_Rupee")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Secret")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Stairs")); //done
            Collision_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Shield")); //done

            //Link sound effects
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Arrow_Boomerang")); //done
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Blow")); //done
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Drop")); //done
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Candle")); //done
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_LowHealth")); //done
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Recorder"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Refill_Loop"));
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Shoot")); //done
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Slash")); //done
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Link_Die")); //done
            Link_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Link_Hurt")); //done

            //Enemy sound effects
            Enemy_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Arrow_Boomerang")); //done
            Enemy_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Key_Appear")); //done

            //Text sound effects
            Text_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Text")); //to be implemented
            Text_soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/LOZ_Text_Slow")); //to be implemented

            //should probably be moved later
            MediaPlayer.Play(Dungeon_music);
            MediaPlayer.Volume = 0.25f;
            MediaPlayer.IsRepeating = true;

            textSprite = new TextSprite(dungeonSheet, this);

            XmlDocument doc = new XmlDocument();
            doc.Load(new FileStream("..\\..\\..\\Content\\ZeldaRoomLayout.xml", FileMode.Open));
            roomManager.SetUpRooms(doc, dungeonSheet, enemySheets, itemsSheet, bossSheets, npcSheet);

            foreach (IController controller in controllerList)
            {
                controller.SetCommands(this);
            }

            pauseControls.SetCommands(this);
            allCollisionHandler = new AllCollisionHandler(this.GraphicsDevice.Viewport.Bounds.X, this.GraphicsDevice.Viewport.Bounds.Width, this.GraphicsDevice.Viewport.Bounds.Y, this.GraphicsDevice.Viewport.Bounds.Height, itemsSheet);

            link = new Link(contentManager.Load<Texture2D>("LinkSpriteSheet"), linkSheetList, Link_soundEffects, inventory);
        }

        protected override void Update(GameTime gameTime)
        {
            int i;
            frame++;
            if (GetPlayer().GetLinkInventory().GetLinkPauseScreen().isGamePaused() == false)
            {
                if (frame % 4 == 0)
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

                    allCollisionHandler.PlayerItemCollisions(link, items, npcs, Collision_soundEffects);
                    allCollisionHandler.BlockCollisions(link, npcs, blocks, roomManager, Collision_soundEffects);
                    allCollisionHandler.ProjectileCollisions(link, npcs, projectiles, Collision_soundEffects, items, roomManager);
                    allCollisionHandler.CheckTraps(npcs);
                    allCollisionHandler.PlayerEnemyCollisions(link, npcs, Collision_soundEffects, items);
                    allCollisionHandler.CheckWalls(link, npcs, roomManager);

                    CheckPlayer();

                    roomManager.Update();
                    if (!roomManager.RoomChange())
                    {
                        link.Update();
                        foreach (IController controller in controllerList)
                        {
                            controller.Update();
                        }
                    }
                    if(roomManager.getRoomIndex() == 5)
                    {
                        textSprite.Update();
                    } else
                    {
                        textSprite.Reset();
                    }
                }
            } else
            {
                if (frame % 2 == 0)
                {
                    pauseControls.Update();
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

            if (roomManager.getRoomIndex() == 5)
            {
                textSprite.Draw(this._spriteBatch);
            }

            link.GetLinkInventory().Draw(this._spriteBatch);

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

        public void CheckPlayer()
        {
            if (!link.IsAlive())
            {
                roomManager.ChangeRoom(15);
                link.Reset();
            }
        }
    }
}
