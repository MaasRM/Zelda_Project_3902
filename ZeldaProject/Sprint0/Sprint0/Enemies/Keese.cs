using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Keese : INPC, IEnemy
    {
        private KeeseStateMachine stateMachine;
        private Texture2D keeseSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int, KeeseStateMachine.KeeseColor> init;

        public Keese(int x, int y, KeeseStateMachine.KeeseColor c, Texture2D spriteSheet)
        {
            stateMachine = new KeeseStateMachine(x, y, c);
            keeseSpriteSheet = spriteSheet;
            init = new Tuple<int, int, KeeseStateMachine.KeeseColor>(x, y, c);
        }

        public void Update()
        {
            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(keeseSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            stateMachine = new KeeseStateMachine(init.Item1, init.Item2, init.Item3);
        }

        public Rectangle GetNPCLocation()
        {
            return destination;
        }

        public int GetDamageValue()
        {
            return 1;
        }

        public void SetDamageState(int damage, Vector2 direction)
        {

        }
    }
}
