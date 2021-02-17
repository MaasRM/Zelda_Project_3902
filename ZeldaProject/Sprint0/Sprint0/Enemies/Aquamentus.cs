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
        private Tuple<int, int, int, int> initPos;

        public Aquamentus(int x, int y, int width, int height, Texture2D spriteSheet)
        {
            stateMachine = new AquamentusStateMachine(x, y, width, height);
            aquamentusSpriteSheet = spriteSheet;
            initPos = new Tuple<int, int, int, int>(x, y, width, height);
        }

        public void Update()
        {
            stateMachine.move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aquamentusSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            stateMachine = new AquamentusStateMachine(initPos.Item1, initPos.Item2, initPos.Item3, initPos.Item4);
        }
    }
}
