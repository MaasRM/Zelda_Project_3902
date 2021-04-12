using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Zol : INPC, IEnemy
    {
        private ZolStateMachine stateMachine;
        private Texture2D ZolSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private const int DAMAGE = 1;
        private Tuple<int, int, ZolStateMachine.ZolColor> init;

        public Zol(int x, int y, ZolStateMachine.ZolColor c, Texture2D spriteSheet)
        {
            stateMachine = new ZolStateMachine(x, y, c);
            ZolSpriteSheet = spriteSheet;
            init = new Tuple<int, int, ZolStateMachine.ZolColor>(x, y, c);
        }

        public void Update()
        {
            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ZolSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            stateMachine = new ZolStateMachine(init.Item1, init.Item2, init.Item3);
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
            stateMachine.TakeDamage(damage);
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
            stateMachine.SetStun();
        }

        public bool IsDamaged()
        {
            return false;
        }
    }
}
