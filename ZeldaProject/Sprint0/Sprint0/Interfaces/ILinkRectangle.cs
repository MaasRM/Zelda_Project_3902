using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface ILinkRectangle
    {
        public Rectangle getRectangle(LinkColor color, int Frame);
    }
}
