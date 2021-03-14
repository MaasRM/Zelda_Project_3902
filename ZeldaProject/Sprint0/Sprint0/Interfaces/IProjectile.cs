using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
namespace Sprint0
{
    public interface IProjectile
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
        public Rectangle GetProjectileLocation();
        public bool CheckForRemoval();
        public int GetDamage();
        public void Hit();
    }
}
