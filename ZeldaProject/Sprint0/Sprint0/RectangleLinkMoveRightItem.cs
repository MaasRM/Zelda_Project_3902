using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveRightItem : ILinkRectangle
	{
		public RectangleLinkMoveRightItem()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			retRectangle = new Rectangle(124, 11, 15, 15);
			return retRectangle;
		}

	}

}
