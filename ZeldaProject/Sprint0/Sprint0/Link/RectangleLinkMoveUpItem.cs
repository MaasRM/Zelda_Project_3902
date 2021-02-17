using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveUpItem : ILinkRectangle
	{
		public RectangleLinkMoveUpItem()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			retRectangle = new Rectangle(141, 11, 15, 15);
			return retRectangle;
		}

	}

}
