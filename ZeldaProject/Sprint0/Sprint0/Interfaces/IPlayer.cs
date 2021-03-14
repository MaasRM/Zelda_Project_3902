using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public Texture2D GetSpriteSheet();
        public Rectangle LinkPosition();
        public void SetPosition(Rectangle newPos);
        public void MakeImmobile();
        public bool Attacking();
        public int GetMeleeDamage();
        public void SetDamageState(int damage, Vector2 direction);
        public bool IsAlive();
        public void Reset();
    }
}
