using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Trap : INPC, IEnemy
    {
        private TrapStateMachine stateMachine;
        private Texture2D trapSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int> init;

        public Trap(int x, int y, Texture2D spritesheet)
        {
            stateMachine = new TrapStateMachine(x, y);
            trapSpriteSheet = spritesheet;
            init = new Tuple<int, int>(x, y);
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
            stateMachine = new TrapStateMachine(init.Item1, init.Item2);
        }

        public Rectangle GetNPCLocation()
        {
            return destination;
        }

        public void Damage()
        {

        }

        public void SetCharge(Rectangle playerPos)
        {
            stateMachine.SetCharge(playerPos);
        }

        public bool IsStill()
        {
            return stateMachine.IsStill();
        }
    }
}