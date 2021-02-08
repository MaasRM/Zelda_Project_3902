using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Link : IPlayer
    {
        private LinkStateMachine stateMachine = new LinkStateMachine();
        private int xLoc;
        private int yLoc;

        public Link()
        {
            //Constructor??
        }
        public void Update()
        {

            //Call set methods in LinkStateMachine
        }

        public void changeXLocation(int x)
        {
            this.xLoc += x;
        }

        public void changeYLocation(int y)
        {
            this.yLoc += y;
        }

        public LinkStateMachine getLinkStateMachine()
        {
            return stateMachine;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Call get LinkStateMachineMethods to draw the sprite??
        }
    }
}
