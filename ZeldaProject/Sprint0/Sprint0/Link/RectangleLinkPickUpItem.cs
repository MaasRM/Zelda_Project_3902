using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkPickUpItem : ILinkRectangle
	{
		public RectangleLinkPickUpItem()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			retRectangle = new Rectangle(230, 11, 15, 15);
			return retRectangle;
		}

	}

}
