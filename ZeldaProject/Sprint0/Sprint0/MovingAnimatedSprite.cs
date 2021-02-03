//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class MovingAnimatedSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Rectangle[] spriteFrames;
        private int frameIndex;
        private int frameCount;
        private int moveDistance;
        private int directionSign;
        private int loopCounter;
        private Texture2D sheet;

        public MovingAnimatedSprite(Rectangle startPos, Rectangle[] frames, int numFrames, int moveDist, Texture2D spriteSheet)
        {
            destination = startPos;
            spriteFrames = frames;
            spriteSource = spriteFrames[0];
            frameIndex = 0;
            frameCount = numFrames;
            moveDistance = moveDist;
            directionSign = 1;
            loopCounter = 0;
            sheet = spriteSheet;
        }

        public void Update()
        {
            if (frameIndex == (frameCount - 1))
            {
                frameIndex = 0;
            }
            else if (frameIndex == 2 || frameIndex == 6)
            {
                if (loopCounter == 10)
                {
                    frameIndex++;
                    loopCounter = 0;
                }
                else
                {
                    loopCounter++;
                    frameIndex -= 2;
                }
            }
            else
            {
                frameIndex++;
            }

            Move();
            Animate();


        }

        private void Move()
        {
            if(loopCounter == 0 && frameIndex % 4 == 0)
            {
                directionSign *= -1;
            }
            destination = new Rectangle(destination.X + moveDistance * directionSign, destination.Y, destination.Width, destination.Height);           
        }

        private void Animate()
        {
            spriteSource = spriteFrames[frameIndex];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(sheet, destination, spriteSource, Color.White);

            spriteBatch.End();
        }
    }
}
