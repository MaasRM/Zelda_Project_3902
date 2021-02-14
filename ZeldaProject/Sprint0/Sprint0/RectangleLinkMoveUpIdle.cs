using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveUpIdle
	{
		public RectangleLinkMoveUpIdle()
		{
		}

		public Rectangle getRectangle(LinkColor color)
		{
			Rectangle retRectangle;
			if (color == LinkColor.Green)
            {
				retRectangle = new Rectangle(69, 11, 15, 15);
			} else if (color == LinkColor.Red)
            {
				retRectangle = new Rectangle(69, 11, 15, 15);
			} else //LinkColor.White
            {
				retRectangle = new Rectangle(69, 11, 15, 15);
			}
			return retRectangle;
		}

	}

}
