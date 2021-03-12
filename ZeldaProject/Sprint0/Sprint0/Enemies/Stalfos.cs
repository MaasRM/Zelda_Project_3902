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
        private Tuple<int, int> init;

        public Stalfos(int x, int y, Texture2D spriteSheet)
        {
            stateMachine = new StalfosStateMachine(x, y);
            stalfosSpriteSheet = spriteSheet;
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
            int frame = stateMachine.GetFrame();

            if(frame % 2 == 1)
            {
                spriteBatch.Draw(stalfosSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(stalfosSpriteSheet, destination, source, Color.White);
            }
        }

        public void Reset()
        {
            stateMachine = new StalfosStateMachine(init.Item1, init.Item2);
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
