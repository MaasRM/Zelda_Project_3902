﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class BrownBoomerangProjectile : IProjectile
    {
        private LinkStateMachine stateMachine;
        private Texture2D spritesheet;
        public BrownBoomerangProjectile(Texture2D spritesheet, LinkStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            this.spritesheet = spritesheet;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
