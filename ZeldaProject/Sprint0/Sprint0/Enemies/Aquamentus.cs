using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Aquamentus : INPC
    {
        private AquamentusStateMachine stateMachine;
        private Texture2D aquamentusSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int, int, int> init;

        public Aquamentus(int x, int y, int width, int height, Texture2D spriteSheet, Link link)
        {
            stateMachine = new AquamentusStateMachine(x, y, width, height);
            aquamentusSpriteSheet = spriteSheet;
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
            spriteBatch.Draw(aquamentusSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            stateMachine = new AquamentusStateMachine(init.Item1, init.Item2, init.Item3, init.Item4);
        }
    }
}
