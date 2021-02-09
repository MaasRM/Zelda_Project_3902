using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Link : IPlayer
    {
        private LinkStateMachine stateMachine;
        private Texture2D linkSpriteSheet;
        private Rectangle source;
        private Rectangle destination;

        public Link(Texture2D spriteSheet)
        {
            stateMachine = new LinkStateMachine();
            linkSpriteSheet = spriteSheet;
        }

        public void Update()
        {
            source = stateMachine.getSource();
            destination = stateMachine.getDestination();
        }

        public LinkStateMachine getLinkStateMachine()
        {
            return stateMachine;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(linkSpriteSheet, destination, source, Color.White);
        }
    }
}
