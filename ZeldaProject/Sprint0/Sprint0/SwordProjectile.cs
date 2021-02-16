using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class SwordProjectile : IProjectile
    {
        //This class is for the sword beam mechanic when link is at full health. Not used in sprint 2

        private LinkStateMachine stateMachine;
        public SwordProjectile(LinkStateMachine stateMachine)
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
