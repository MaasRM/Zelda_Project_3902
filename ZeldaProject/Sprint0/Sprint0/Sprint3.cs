using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

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
        public IBlock block;
        private INPC npc;
        private IItem item;
        public Texture2D dungeonSheet;
        //private List<IBlock> blocks;
        private int frame;
        private int npcIndex;
        private int itemIndex;
        private Tuple<IPlayer, List<IBlock>, List<IItem>, List<INPC>, List<IProjectile>> gameObjects;

        public Sprint3()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            controllerList = new List<IController>();
            linkSheetList = new List<Texture2D>();
            frame = 0;
            npcIndex = 0;
            itemIndex = 0;
            contentManager = new ContentManager(Content.ServiceProvider, Content.RootDirectory);
            contentManager.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            KeyboardController keyControls = new KeyboardController();

            controllerList.Add(keyControls);

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
            block = new Block(new Rectangle (200, 200, 16, 16), new Rectangle(984, 11, 16, 16), dungeonSheet);
            npc = new Stalfos(520, 222, contentManager.Load<Texture2D>("Dungeon_Enemies"));
            item = new BlueRupeeItem(new Rectangle(500, 100, 24, 48), new Rectangle(72, 16, 8, 16), contentManager.Load<Texture2D>("Dungeon_Items"));

            foreach(IController controller in controllerList)
            {
                controller.SetCommands(this);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            frame++;

            if (frame % 4 == 0)
            {
                //Call updates for Link, Enemy, Block
                link.Update();
                npc.Update();
                block.Update();
                item.Update();


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

            
            //Call draw for Link, Enemy, Block
            link.Draw(this._spriteBatch);
            npc.Draw(this._spriteBatch);
            block.Draw(this._spriteBatch);
            item.Draw(this._spriteBatch);

            this._spriteBatch.End();

            base.Draw(gameTime);
        }

        public IPlayer GetPlayer()
        {
            return link;
        }
        
        public void UpdateGameBlock(IBlock newBlock)
        {
            block = newBlock;
        }

        public void UpdateNPC(INPC newNPC)
        {
            npc = newNPC;
            npc.Reset();
        }

        public int GetNPCIndex()
        {
            return npcIndex;
        }

        public void SetNPCIndex(int index)
        {
            npcIndex = index;
        }       

        public Texture2D GetEnemySpriteSheet()
        {
            return contentManager.Load<Texture2D>("Dungeon_Enemies");
        } 
        
        public int GetItemIndex()
        {
            return itemIndex;
        }

        public void SetItemIndex(int index)
        {
            itemIndex = index;
        }

        public void SetItem(IItem newItem)
        {
            item = newItem;
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
    }
}
