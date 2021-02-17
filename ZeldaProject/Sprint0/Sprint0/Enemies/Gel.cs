using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Gel : INPC
    {
        private GelStateMachine stateMachine;
        private Texture2D gelSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int, int, int, GelStateMachine.GelColor> init;

        public Gel(int x, int y, int width, int height, GelStateMachine.GelColor c, Texture2D spriteSheet)
        {
            stateMachine = new GelStateMachine(x, y, width, height, c);
            gelSpriteSheet = spriteSheet;
            init = new Tuple<int, int, int, int, GelStateMachine.GelColor>(x, y, width, height, c);

        }

        public void Update()
        {
            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gelSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            stateMachine = new GelStateMachine(init.Item1, init.Item2, init.Item3, init.Item4, init.Item5);
        }
    }
}
