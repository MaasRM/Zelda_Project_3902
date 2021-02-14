using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveDownWalk : ILinkRectangle
	{
		public RectangleLinkMoveDownWalk()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			if (frame == 0)
			{
				retRectangle = new Rectangle(18, 11, 15, 15);
			}
			else
			{
				retRectangle = new Rectangle(1, 11, 15, 15);
			}
			return retRectangle;
		}

	}

}
