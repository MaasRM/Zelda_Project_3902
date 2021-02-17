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
        private Tuple<int, int, int, int> init;

        public Stalfos(int x, int y, int width, int height, Texture2D spriteSheet)
        {
            stateMachine = new StalfosStateMachine(x, y, width, height);
            stalfosSpriteSheet = spriteSheet;
            init = new Tuple<int, int, int, int>(x, y, width, height);
        }

        public void Update()
        {
            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int frame = stateMachine.GetFrame();

            if(frame % 2 == 1)
            {
                spriteBatch.Draw(stalfosSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(stalfosSpriteSheet, destination, source, Color.White);
            }
        }

        public void Reset()
        {
            stateMachine = new StalfosStateMachine(init.Item1, init.Item2, init.Item3, init.Item4);
        }
    }
}
