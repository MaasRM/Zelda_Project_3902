using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveUpAttack : ILinkRectangle
	{
		public RectangleLinkMoveUpAttack()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			if (frame == 0)
			{
				retRectangle = new Rectangle(1, 109, 15, 15);
			} 
			else if (frame == 1)
			{
				retRectangle = new Rectangle(18, 97, 15, 27);
			} 
			else if (frame == 2)
            {
				retRectangle = new Rectangle(35, 97, 15, 27);
			} 
			else
            {
				retRectangle = new Rectangle(52, 97, 15, 27);
			}
			return retRectangle;
		}

	}

}