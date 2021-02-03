//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0
{
    public class StationaryAnimatedSprite : ISprite
    {
        private Rectangle destination;
        private Rectangle spriteSource;
        private Rectangle[] spriteFrames;
        private int frameIndex;
        private int frameCount;
        private Texture2D sheet;


        public StationaryAnimatedSprite(Rectangle startPos, Rectangle[] frames, int numFrames, Texture2D spriteSheet)
        {
            destination = startPos;
            spriteFrames = frames;
            spriteSource = spriteFrames[0];
            frameIndex = 0;
            frameCount = numFrames;
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

            Animate();
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
