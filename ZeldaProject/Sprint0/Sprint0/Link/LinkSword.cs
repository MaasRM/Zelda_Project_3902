using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkSword
    {
        IItem currentSword;

        public LinkSword(IItem startSword)
        {
            currentSword = startSword;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle dest)
        {
            spriteBatch.Draw(currentSword.GetSpriteSheet(), dest, currentSword.GetSourceRectangle(), Color.White);
        }

        public void setSword(IItem sword)
        {
            currentSword = sword;
        }

        public IItem getSword()
        {
            return currentSword;
        }

    }
}
