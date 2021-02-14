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
				retRectangle = new Rectangle(1, 77, 15, 15);
			}
			else if (frame == 1)
			{
				retRectangle = new Rectangle(18, 77, 15, 26);
			}
			else if (frame == 2)
			{
				retRectangle = new Rectangle(46, 77, 15, 22);
			}
			else
			{
				retRectangle = new Rectangle(70, 77, 15, 18);
			}
			return retRectangle;
		}

	}

}
