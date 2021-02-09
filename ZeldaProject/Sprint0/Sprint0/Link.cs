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

        public Link()
        {
            LinkStateMachine stateMachine = new LinkStateMachine();
        }

        public void Update()
        {
            //Do we need this since we are using the command classes from the controller?
        }

        public LinkStateMachine getLinkStateMachine()
        {
            return stateMachine;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(sheet, destination, spriteSource, Color.White);
        }
    }
}
