using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public interface INPC
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
        public void Reset();
        public Rectangle GetNPCLocation();
        public void SetPosition(Rectangle newPos);
    }
}
