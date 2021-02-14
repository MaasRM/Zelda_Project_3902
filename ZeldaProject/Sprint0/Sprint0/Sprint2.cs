﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Sprint2 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        public IPlayer link;
        public IBlock block;
        private List<INPC> nonPlayers;
        private List<IItem> items;
        //private List<IBlock> blocks;
        private int frame;

        public Sprint2()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            controllerList = new List<IController>();
            frame = 0;
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

            link = new Link(Content.Load<Texture2D>("LinkSpriteSheet"));
            block = new Block(Content.Load<Texture2D>("Dungeon_Tileset"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            frame++;

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            //Call updates for Link, Enemy, Block
            link.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Call draw for Link, Enemy, Block
            link.Draw(this._spriteBatch);

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
    }
}
