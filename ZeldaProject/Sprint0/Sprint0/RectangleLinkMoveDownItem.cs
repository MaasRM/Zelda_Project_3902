using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveDownItem : ILinkRectangle
	{
		public RectangleLinkMoveDownItem()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			retRectangle = new Rectangle(107, 11, 15, 15);
			return retRectangle;
		}

	}

}
