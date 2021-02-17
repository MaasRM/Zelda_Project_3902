//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public interface ISprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
