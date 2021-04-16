using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class Gohma : INPC, IEnemy
    {
        private GohmaStateMachine stateMachine;
        private Texture2D gohmaSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private const int DAMAGE = 2;
        private Tuple<int, int, GohmaStateMachine.GohmaColor> init;
        private Sprint5 game;

        public Gohma(int x, int y, GohmaStateMachine.GohmaColor c, Texture2D spriteSheet, Sprint5 sprint)
        {
            stateMachine = new GohmaStateMachine(x, y, c);
            gohmaSpriteSheet = spriteSheet;
            init = new Tuple<int, int, GohmaStateMachine.GohmaColor>(x, y, c);
            game = sprint;
        }

        public void Update()
        {
            stateMachine.Move();

            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();

            if (stateMachine.TryToFire())
            {
                int fireballX = destination.X + destination.Width / 2;
                int fireballY = destination.Y + destination.Height / 2;
                game.AddProjectile(new GohmaFireball(fireballX, fireballY, gohmaSpriteSheet, game));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(stateMachine.GetFrame() % 2 == 1)
            {
                spriteBatch.Draw(gohmaSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(gohmaSpriteSheet, destination, source, Color.White);
            }

        }

        public void Reset()
        {
            stateMachine = new GohmaStateMachine(init.Item1, init.Item2, init.Item3);
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
            stateMachine.TakeDamage();
        }
        public void SetPosition(Rectangle newPos)
        {
            destination = newPos;
            stateMachine.SetDestination(destination.X, destination.Y);
        }

        public bool StillAlive()
        {
            return stateMachine.HasHealth();
        }

        public void Stun()
        {
            //Won't get stunned
        }

        public bool IsDamaged()
        {
            //Once hit, it's killed, so never damaged
            return false;
        }
    }
}