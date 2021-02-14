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
        int frame;

        public Stalfos(int x, int y, int width, int height, Texture2D spriteSheet)
        {
            stateMachine = new StalfosStateMachine(x, y, width, height);
            frame = -1;
            stalfosSpriteSheet = spriteSheet;
        }

        public void Update()
        {
            frame++;
            stateMachine.move(frame);
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
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
