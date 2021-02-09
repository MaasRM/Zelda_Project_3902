using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkSpriteFactory
    {
        int linkHeight;
        int linkWidth;
        public LinkSpriteFactory()
        {
            //initial height and width
        }

        public Rectangle getSourceRectangle(Direction direction, LinkColor color, Animation animation)
        {
            //Use params to get proper rectangle from sprite sheet and update height and width
            if(direction == x && color == y && animation == z)
            {

            }
            //Return a List of rectangles to then animate
        }

        public int getHeight()
        {
            return linkHeight;
        }

        public int getWidth()
        {
            return linkWidth;
        }

    }

}
