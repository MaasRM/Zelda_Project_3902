using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class Sprint2 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        private ISprite gameSprite;
        private ISprite textSprite;
        private int frame;
        public Texture2D characterFrames;
        public SpriteFont font;

        public Sprint2()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            controllerList = new List<IController>();
            frame = 0;
            //Does Everyone See This? Yep, test
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

            characterFrames = Content.Load<Texture2D>("LinkSpriteSheet");

            gameSprite = new StationaryStillSprite(new Rectangle((int)this.GraphicsDevice.Viewport.Width / 2 - 16, (int)this.GraphicsDevice.Viewport.Height / 2 - 32, 32, 64), new Rectangle(258, 1, 16, 32), characterFrames);
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Call draw for Link, Enemy, Block

            base.Draw(gameTime);
        }
    }
}
