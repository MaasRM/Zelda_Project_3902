using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveRightAttack : ILinkRectangle
	{
		public RectangleLinkMoveRightAttack()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			if (frame == 0)
			{
				retRectangle = new Rectangle(1, 77, 16, 15);
			}
			else if (frame == 1)
			{
				retRectangle = new Rectangle(18, 77, 27, 15);
			}
			else if (frame == 2)
			{
				retRectangle = new Rectangle(46, 77, 23, 15);
			}
			else
			{
				retRectangle = new Rectangle(70, 77, 19, 15);
			}
			return retRectangle;
		}

	}

}
