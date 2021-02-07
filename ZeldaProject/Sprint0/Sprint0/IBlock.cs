﻿//Code by: Jared Zins

using System;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public interface IBlock
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
