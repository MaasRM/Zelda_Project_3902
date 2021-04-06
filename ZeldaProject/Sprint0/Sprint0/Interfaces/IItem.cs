using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public interface IItem
    {
        public void Update();

        public void Draw(SpriteBatch spriteBatch);

        public Rectangle GetLocationRectangle();

        public Rectangle GetSourceRectangle();

        public Texture2D GetSpriteSheet();
    }
}
