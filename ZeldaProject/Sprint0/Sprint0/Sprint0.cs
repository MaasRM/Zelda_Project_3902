//Code by: Nathan Schultz

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        private ISprite gameSprite;
        private ISprite textSprite;
        private int frame;
        public Texture2D characterFrames;
        public SpriteFont font;

        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            controllerList = new List<IController>();
            frame = 0;
            //Does Everyone See This? Yep
        }

        protected override void Initialize()
        {
            KeyboardController keyControls = new KeyboardController(this);
            MouseController mouseControls = new MouseController(this);

            controllerList.Add(keyControls);
            controllerList.Add(mouseControls);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            characterFrames = Content.Load<Texture2D>("characters");
            font = Content.Load<SpriteFont>("credits");

            gameSprite = new StationaryStillSprite(new Rectangle((int)this.GraphicsDevice.Viewport.Width / 2 - 16, (int)this.GraphicsDevice.Viewport.Height / 2 - 32, 32, 64), new Rectangle(258, 1, 16, 32), characterFrames);
            textSprite = new TextSprite(new Vector2(200, 360), font, "Credits\nPorgram Made By: Nathan Schultz\nSprites from: http://www.mariouniverse.com/wp-content/img/sprites/nes/smb");
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
            if (frame % 8 == 0)
            {
                gameSprite.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            textSprite.Draw(_spriteBatch);
            gameSprite.Draw(_spriteBatch);

            base.Draw(gameTime);
        }

        public void UpdateGameSprite(ISprite newSprite)
        {
            gameSprite = newSprite;
        }

        public ISprite GetGameSprite()
        {
            return gameSprite;
        }
    }
}
