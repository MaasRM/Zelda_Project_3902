using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.GameStates
{
    class MainGameState : IGameStates
    {
        GraphicsDevice _graphicsDevice;
        SpriteBatch _spriteBatch;
        public MainGameState(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public void Initialize()
        {
            //base.Initialize();
        }

        public void LoadContent(ContentManager content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(_graphicsDevice);
            GameStateManager.Instance.SetContent(content);
        }

        public void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            GameStateManager.Instance.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            GameStateManager.Instance.Update(gameTime);
            //base.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);

            GameStateManager.Instance.Draw(gameTime);
            //base.Draw(gameTime);
        }
    }
}

