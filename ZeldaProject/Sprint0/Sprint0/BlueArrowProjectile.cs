﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class BlueArrowProjectile : IProjectile
    {
        private LinkStateMachine stateMachine;
        public BlueArrowProjectile(LinkStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public void Update()
        {

        }
        public void Draw(Texture2D spritesheet, SpriteBatch spriteBatch)
        {

        }
    }
}