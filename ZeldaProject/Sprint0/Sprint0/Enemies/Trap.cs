using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Trap : INPC
    {
        private TrapStateMachine stateMachine;
        private Texture2D trapSpriteSheet;
        private Rectangle source;
        private Rectangle destination;

        public Trap()
        {
        }

        public void Update()
        {
            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(trapSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {

        }
    }
}