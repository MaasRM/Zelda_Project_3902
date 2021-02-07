using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Link : IPlayer
    {
        LinkStateMachine stateMachine = new LinkStateMachine();

        public Link()
        {
            //Constructor??
        }
        public void Update()
        {

            //Call set methods in LinkStateMachine
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Call get LinkStateMachineMethods to draw the sprite??
        }
    }
}
