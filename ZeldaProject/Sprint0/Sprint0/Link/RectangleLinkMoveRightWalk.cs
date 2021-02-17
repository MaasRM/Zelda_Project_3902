using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveRightWalk : ILinkRectangle
	{
		public RectangleLinkMoveRightWalk()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			if (frame == 0)
			{
				retRectangle = new Rectangle(52, 11, 15, 15);
			}
			else
			{
				retRectangle = new Rectangle(35, 11, 15, 15);
			}
			return retRectangle;
		}

	}

}
