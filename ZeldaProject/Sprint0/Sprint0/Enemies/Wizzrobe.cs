using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Wizzrobe : INPC, IEnemy
    {
        private WizzrobeStateMachine stateMachine;
        private List<Texture2D> wizzrobeSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private Sprint5 game;
        private Tuple<int, int, WizzrobeStateMachine.WizzrobeColor> init;

        public Wizzrobe(int x, int y, WizzrobeStateMachine.WizzrobeColor c, List<Texture2D> spriteSheet, Sprint5 game)
        {
            stateMachine = new WizzrobeStateMachine(x, y, c, game);
            wizzrobeSpriteSheet = spriteSheet;
            currentSheet = spriteSheet[0];
            init = new Tuple<int, int, WizzrobeStateMachine.WizzrobeColor>(x, y, c);
            this.game = game;

        }

        public void Update()
        {
            stateMachine.Move();
            
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();

            if (stateMachine.FireChance())
            {
                game.AddProjectile(new WizzrobeMagic(destination.X, destination.Y, wizzrobeSpriteSheet[0], stateMachine.GetDirection(), stateMachine.color));
            }

            ChangeSpriteSheet();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!stateMachine.Teleporting())
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
        }

        private void ChangeSpriteSheet()
        {
            if (stateMachine.IsDamaged())
            {
                int damageFrame = stateMachine.GetDamageFrame();

                if (damageFrame % 4 == 3) currentSheet = wizzrobeSpriteSheet[1];
                else if (damageFrame % 4 == 2) currentSheet = wizzrobeSpriteSheet[2];
                else if (damageFrame % 4 == 1) currentSheet = wizzrobeSpriteSheet[3];
                else currentSheet = wizzrobeSpriteSheet[0];
            }
            else SetOriginalColor();
        }

        private void SetOriginalColor()
        {
            currentSheet = wizzrobeSpriteSheet[0];
        }

        public void Reset()
        {
            stateMachine = new WizzrobeStateMachine(init.Item1, init.Item2, init.Item3, game);
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

        public bool IsTeleporting()
        {
            return stateMachine.Teleporting();
        }
    }
}
