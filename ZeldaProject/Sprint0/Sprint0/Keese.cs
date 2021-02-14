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
        int frame;

        public Keese(int x, int y, int width, int height, Texture2D spriteSheet)
        {
            stateMachine = new KeeseStateMachine(x, y, width, height);
            frame = -1;
            keeseSpriteSheet = spriteSheet;
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
            spriteBatch.Draw(keeseSpriteSheet, destination, source, Color.White);
        }
    }
}
