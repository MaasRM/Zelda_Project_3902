using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace Sprint0
{
    class SwordProjectile : IProjectile, IPlayerProjectile
    {
        //This class is for the sword beam mechanic when link is at full health. Not used in sprint 2

        private LinkStateMachine stateMachine;
        private Texture2D spritesheet;
        private int damage;
        private bool remove;
        public SwordProjectile(Texture2D spritesheet, LinkStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            this.spritesheet = spritesheet;
            remove = false;
            damage = 1;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public Rectangle GetProjectileLocation()
        {
            return new Rectangle(1, 1, 1, 1);
        }

        public bool CheckForRemoval()
        {
            return remove;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void Hit()
        {
            remove = true;
        }
    }
}
