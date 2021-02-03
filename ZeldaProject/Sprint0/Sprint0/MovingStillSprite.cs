//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class MovingStillSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private int frameIndex;
        private int frameCount;
        private int moveDistance;
        private int directionSign;
        private Texture2D sheet;

        public MovingStillSprite(Rectangle startPos, Rectangle source, int numFrames, int moveDist, Texture2D spriteSheet)
        {
            destination = startPos;
            spriteSource = source;
            frameIndex = 0;
            frameCount = numFrames;
            moveDistance = moveDist;
            directionSign = -1;
            sheet = spriteSheet;
        }

        public void Update()
        {
            if (frameIndex == frameCount - 1)
            {
                frameIndex = 0;
            }
            else
            {
                frameIndex++;
            }

            Move();
        }

        private void Move()
        {
            if (frameIndex == 0)
            {
                directionSign *= -1;
            }
            else
            {
                destination = new Rectangle(destination.X, destination.Y + moveDistance * directionSign, destination.Width, destination.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(sheet, destination, spriteSource, Color.White);

            spriteBatch.End();
        }
    }
}
