using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Sprint2 : Game
    {
        private GraphicsDeviceManager _graphics;
        private ContentManager contentManager;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        public IPlayer link;
        public IBlock block;
        private INPC npc;
        private List<IItem> items;
        //private List<IBlock> blocks;
        private int frame;
        private int npcIndex;

        public Sprint2()
        {
            _graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            IsMouseVisible = true;
            controllerList = new List<IController>();
            frame = 0;
            npcIndex = 0;
            contentManager = new ContentManager(Content.ServiceProvider, Content.RootDirectory);
            contentManager.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            KeyboardController keyControls = new KeyboardController(this);

            controllerList.Add(keyControls);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            link = new Link(contentManager.Load<Texture2D>("LinkSpriteSheet"), contentManager);
            block = new Block(contentManager.Load<Texture2D>("Dungeon_Tileset"));
            npc = new Stalfos(520, 222, 16, 16, contentManager.Load<Texture2D>("Dungeon_Enemies"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            frame++;

            if (frame % 4 == 0)
            {
                foreach (IController controller in controllerList)
                {
                    controller.Update();
                }
                //Call updates for Link, Enemy, Block
                link.Update();
                npc.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(115, 115, 115, 255));
            this._spriteBatch.Begin();

            //if (frame % 4 == 0)
            //{
                //Call draw for Link, Enemy, Block
                link.Draw(this._spriteBatch);
                npc.Draw(this._spriteBatch);
            //}

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
    }
}
