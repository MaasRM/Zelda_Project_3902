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
        private IPlayer linkRef;
        private Tuple<int, int, IPlayer> init;

        public Trap(int x, int y, Texture2D spritesheet, IPlayer link)
        {
            stateMachine = new TrapStateMachine(x, y, link);
            linkRef = link;
            trapSpriteSheet = spritesheet;
            init = new Tuple<int, int, IPlayer>(x, y, link);
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
            stateMachine = new TrapStateMachine(init.Item1, init.Item2,init.Item3);
        }
    }
}