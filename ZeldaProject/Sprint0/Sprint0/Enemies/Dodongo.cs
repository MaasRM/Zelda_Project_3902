using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class Dodongo : INPC, IEnemy
    {
        private DodongoStateMachine stateMachine;
        private Texture2D dodongoSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private int DAMAGE = 2;
        private Tuple<int, int> init;

        public Dodongo(int x, int y, Texture2D spriteSheet)
        {
            stateMachine = new DodongoStateMachine(x, y);
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

            if(stateMachine.GetState() != DodongoStateMachine.State.Dying || frame % 2 == 0)
            {
                if (stateMachine.GetDirection() == Direction.Left || ((stateMachine.GetDirection() == Direction.Up || stateMachine.GetDirection() == Direction.Down) && frame % 2 == 1))
                {
                    spriteBatch.Draw(dodongoSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
                }
                else
                {
                    spriteBatch.Draw(dodongoSpriteSheet, destination, source, Color.White);
                }
            }
        }

        public void Reset()
        {
            stateMachine = new DodongoStateMachine(init.Item1, init.Item2);
        }

        public Rectangle GetNPCLocation()
        {
            return destination;
        }

        public int GetDamageValue()
        {
            return DAMAGE;
        }

        public void SetDamageState(int damage, Vector2 direction)
        {
            stateMachine.Eat(damage);
        }

        public void SetPosition(Rectangle newPos)
        {
            destination = newPos;
            stateMachine.SetDestination(destination.X, destination.Y);
        }

        public bool StillAlive()
        {
            return stateMachine.NotDead();
        }

        public void Stun()
        {
            //Dodongo doesn't stun
        }

        public bool IsDamaged()
        {
            return stateMachine.IsEating();
        }
    }
}