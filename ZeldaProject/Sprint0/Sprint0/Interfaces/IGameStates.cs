using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.GameStates
{
    public interface IGameStates
    {   
        public void Initialize();
        public void LoadContent(ContentManager content);
        public void UnloadContent();
        public void Update(GameTime gameTime);
        public void Draw(GameTime gameTime);
    }
}
