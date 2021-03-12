using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace Sprint0
{
    public interface IEnemy
    {
        public int GetDamageValue();
        public void SetDamageState(int damage, Vector2 direction);
    }
}
