﻿using Microsoft.Xna.Framework.Graphics;
using System;
namespace Sprint0
{
    public interface IProjectile
    {
        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
