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
        private Texture2D spritesheet;
        public SwordProjectile(Texture2D spritesheet, LinkStateMachine stateMachine)
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
