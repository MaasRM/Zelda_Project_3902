﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface IPlayer
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
        public LinkStateMachine getLinkStateMachine();
        public void changeXLocation(int change);
        public void changeYLocation(int change);
    }
}
