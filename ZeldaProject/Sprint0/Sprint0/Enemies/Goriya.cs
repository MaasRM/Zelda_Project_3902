using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Goriya : INPC
    {
        private GoriyaStateMachine stateMachine;
        private GoriyaBoomerang boomerang;
        private Texture2D goriyaSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int, GoriyaStateMachine.GoriyaColor> init;

        public Goriya(int x, int y, GoriyaStateMachine.GoriyaColor c, Texture2D spriteSheet)
        {
            stateMachine = new GoriyaStateMachine(x, y, c);
            goriyaSpriteSheet = spriteSheet;
            init = new Tuple<int, int, GoriyaStateMachine.GoriyaColor>(x, y, c);
            boomerang = new GoriyaBoomerang(goriyaSpriteSheet, stateMachine);
        }

        public void Update()
        {
            if(!stateMachine.Throwing() && stateMachine.TryToThrow())
            {
                boomerang = new GoriyaBoomerang(goriyaSpriteSheet, stateMachine);
            }
            if(stateMachine.Throwing())
            {
                boomerang.Update();
            }

            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (stateMachine.Throwing())
            {
                boomerang.Draw(spriteBatch);
            }

            if (stateMachine.GetFrame() % 2 == 0)
            {
                if(stateMachine.GetDirection() == GoriyaStateMachine.Direction.Left)
                {
                    spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
                }
                else
                {
                    spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White);
                }
            }
            else
            {
                if(stateMachine.GetDirection() == GoriyaStateMachine.Direction.Right)
                {
                    spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White);
                }
                else
                {
                    spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
                }
            }
        }

        public void Reset()
        {
            stateMachine = new GoriyaStateMachine(init.Item1, init.Item2, init.Item3);
        }
    }
}
