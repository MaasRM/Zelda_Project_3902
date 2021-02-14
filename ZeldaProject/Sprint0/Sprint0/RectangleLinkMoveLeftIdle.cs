using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{

	public class RectangleLinkMoveLeftIdle : ILinkRectangle
	{
		public RectangleLinkMoveLeftIdle()
		{
		}

		public Rectangle getRectangle(LinkColor color, int frame)
		{
			Rectangle retRectangle;
			retRectangle = new Rectangle(69, 11, 15, 15);
			//Code for moving left: spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
			return retRectangle;
		}

	}

}
