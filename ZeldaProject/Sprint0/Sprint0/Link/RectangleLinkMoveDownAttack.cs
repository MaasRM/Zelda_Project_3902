using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveDownAttack : ILinkRectangle
	{
		public RectangleLinkMoveDownAttack()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			if (frame == 0)
			{
				retRectangle = new Rectangle(1, 47, 15, 30);
			}
			else if (frame == 1)
			{
				retRectangle = new Rectangle(18, 47, 15, 30);
			}
			else if (frame == 2)
			{
				retRectangle = new Rectangle(35, 47, 15, 30);
			}
			else
			{
				retRectangle = new Rectangle(52, 47, 15, 30);
			}
			return retRectangle;
		}

	}

}
