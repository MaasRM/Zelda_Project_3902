using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Gibdo : INPC, IEnemy
    {
        private GibdoStateMachine stateMachine;
        private List<Texture2D> gibdoSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private const int DAMAGE = 1;
        private Tuple<int, int> init;

        public Gibdo(int x, int y, List<Texture2D> spriteSheet)
        {
            stateMachine = new GibdoStateMachine(x, y);
            gibdoSpriteSheet = spriteSheet;
            currentSheet = spriteSheet[0];
            init = new Tuple<int, int>(x, y);
        }

        public void Update()
        {
            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
            ChangeSpriteSheet();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int frame = stateMachine.GetFrame();

            if (frame % 2 == 1)
            {
                spriteBatch.Draw(currentSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(currentSheet, destination, source, Color.White);
            }

        }

        private void ChangeSpriteSheet()
        {
            if (stateMachine.IsDamaged())
            {
                int damageFrame = stateMachine.GetDamageFrame();

                if (damageFrame % 4 == 3) currentSheet = gibdoSpriteSheet[1];
                else if (damageFrame % 4 == 2) currentSheet = gibdoSpriteSheet[2];
                else if (damageFrame % 4 == 1) currentSheet = gibdoSpriteSheet[3];
                else currentSheet = gibdoSpriteSheet[0];
            }
            else
            {
                SetOriginalColor();
            }
        }

        private void SetOriginalColor()
        {
            currentSheet = gibdoSpriteSheet[0];
        }

        public void Reset()
        {
            stateMachine = new GibdoStateMachine(init.Item1, init.Item2);
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
            stateMachine.TakeDamage(damage, direction);
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
            return stateMachine.IsDamaged();
        }

        public void Burn()
        {
            stateMachine.Burn();
        }

        public bool IsBurned()
        {
            return stateMachine.IsBurned();
        }
    }
}
