using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Wallmaster : INPC
    {
        private WallmasterStateMachine stateMachine;
        private Texture2D wallmasterSpriteSheet;
        private Rectangle source;
        private Rectangle destination;

        public Wallmaster()
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
            spriteBatch.Draw(wallmasterSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {

        }
    }
}