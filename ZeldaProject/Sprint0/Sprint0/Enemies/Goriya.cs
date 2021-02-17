using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Goriya : INPC
    {
        private GoriyaStateMachine stateMachine;
        private Texture2D goriyaSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int, int, int> init;

        public Goriya(int x, int y, int width, int height, Texture2D spriteSheet)
        {
            stateMachine = new GoriyaStateMachine(x, y, width, height);
            goriyaSpriteSheet = spriteSheet;
            init = new Tuple<int, int, int, int>(x, y, width, height);
        }

        public void Update()
        {
            stateMachine.move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            stateMachine = new GoriyaStateMachine(init.Item1, init.Item2, init.Item3, init.Item4);
        }
    }
}
