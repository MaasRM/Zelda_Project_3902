using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Stalfos : INPC
    {
        private StalfosStateMachine stateMachine;
        private Texture2D stalfosSpriteSheet;
        private Rectangle source;
        private Rectangle destination;

        public Stalfos(int x, int y, int width, int height, Texture2D spriteSheet)
        {
            stateMachine = new StalfosStateMachine(x, y, width, height);
            stalfosSpriteSheet = spriteSheet;
        }

        public void Update()
        {
            stateMachine.move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int frame = stateMachine.getFrame();

            if(frame % 2 == 1)
            {
                spriteBatch.Draw(stalfosSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(stalfosSpriteSheet, destination, source, Color.White);
            }
        }
    }
}
