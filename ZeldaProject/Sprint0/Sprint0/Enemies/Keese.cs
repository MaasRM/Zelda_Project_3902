using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Keese : INPC
    {
        private KeeseStateMachine stateMachine;
        private Texture2D keeseSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int, int, int, KeeseStateMachine.KeeseColor> init;

        public Keese(int x, int y, int width, int height, KeeseStateMachine.KeeseColor c, Texture2D spriteSheet)
        {
            stateMachine = new KeeseStateMachine(x, y, width, height, c);
            keeseSpriteSheet = spriteSheet;
            init = new Tuple<int, int, int, int, KeeseStateMachine.KeeseColor>(x, y, width, height, c);
        }

        public void Update()
        {
            stateMachine.move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(keeseSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            stateMachine = new KeeseStateMachine(init.Item1, init.Item2, init.Item3, init.Item4, init.Item5);
        }
    }
}
