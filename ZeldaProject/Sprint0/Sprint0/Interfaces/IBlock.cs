//Code by: Jared Zins

using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public interface IBlock
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
        public Rectangle GetBlockLocation();
        public int getIndex();
        public void setPosition(Rectangle newRect);
        public void setBlockIndex(int num);
        public Rectangle startPos();
        public bool notMovedX();
        public bool notMovedY();
    }
}
