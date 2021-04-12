using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Sprint0
{
    public class Darknut : INPC, IEnemy
    {
        private DarknutStateMachine stateMachine;
        private List<Texture2D> darknutSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private Tuple<int, int, DarknutStateMachine.DarknutColor> init;

        public Darknut(int x, int y, DarknutStateMachine.DarknutColor c, List<Texture2D> spriteSheet)
        {
            stateMachine = new DarknutStateMachine(x, y, c);
            darknutSpriteSheet = spriteSheet;
            currentSheet = spriteSheet[0];
            init = new Tuple<int, int, DarknutStateMachine.DarknutColor>(x, y, c);
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
            if (stateMachine.GetFrame() % 2 == 0)
            {
                if (stateMachine.GetDirection() == Direction.Left)
                {
                    spriteBatch.Draw(currentSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
                }
                else
                {
                    spriteBatch.Draw(currentSheet, destination, source, Color.White);
                }
            }
            else
            {
                if (stateMachine.GetDirection() == Direction.Right)
                {
                    spriteBatch.Draw(currentSheet, destination, source, Color.White);
                }
                else
                {
                    spriteBatch.Draw(currentSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
                }
            }
        }

        private void ChangeSpriteSheet()
        {
            if (stateMachine.IsDamaged())
            {
                int damageFrame = stateMachine.GetDamageFrame();

                if (damageFrame % 4 == 3) currentSheet = darknutSpriteSheet[1];
                else if (damageFrame % 4 == 2) currentSheet = darknutSpriteSheet[2];
                else if (damageFrame % 4 == 1) currentSheet = darknutSpriteSheet[3];
                else currentSheet = darknutSpriteSheet[0];
            }
            else SetOriginalColor();
        }

        private void SetOriginalColor()
        {
            currentSheet = darknutSpriteSheet[0];
        }

        public void Reset()
        {
            stateMachine = new DarknutStateMachine(init.Item1, init.Item2, init.Item3);
        }

        public Rectangle GetNPCLocation()
        {
            return destination;
        }

        public int GetDamageValue()
        {
            return stateMachine.GetDamage();
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
    }
}