using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Stalfos : INPC, IEnemy
    {
        private StalfosStateMachine stateMachine;
        private Texture2D stalfosSpriteSheet;
        private Rectangle source;
        private Rectangle destination;

        public Stalfos()
        {
            stateMachine = new StalfosStateMachine();
        }

        public void Update()
        {
            stateMachine.move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetDestination();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(stalfosSpriteSheet, destination, source, Color.White);
        }
    }
}
