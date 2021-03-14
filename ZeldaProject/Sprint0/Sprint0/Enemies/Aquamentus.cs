using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Aquamentus : INPC, IEnemy
    {
        private AquamentusStateMachine stateMachine;
        private List<Texture2D> aquamentusSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private Sprint3 game;
        private int DAMAGE = 2;
        private Tuple<int, int> init;

        public Aquamentus(int x, int y, List<Texture2D> spriteSheet, Sprint3 game)
        {
            stateMachine = new AquamentusStateMachine(x, y);
            aquamentusSpriteSheet = spriteSheet;
            currentSheet = spriteSheet[0];
            init = new Tuple<int, int>(x, y);
            this.game = game;
        }

        public void Update()
        {
            stateMachine.Move();
            
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
            ChangeSpriteSheet();

            if (!stateMachine.IsFiring())
            {
                if (stateMachine.TryToFire())
                {
                    int fireballX = destination.X + destination.Width / 4;
                    int fireballY = destination.Y + destination.Width / 2;
                    game.AddProjectile(new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Top, aquamentusSpriteSheet[0], game));
                    game.AddProjectile(new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Center, aquamentusSpriteSheet[0], game));
                    game.AddProjectile(new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Bottom, aquamentusSpriteSheet[0], game));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentSheet, destination, source, Color.White);
        }

        private void ChangeSpriteSheet()
        {
            if (stateMachine.IsDamaged())
            {
                int damageFrame = stateMachine.GetDamageFrame();

                if (damageFrame % 4 == 3)
                {
                    currentSheet = aquamentusSpriteSheet[1];
                    //contentManager.Load<Texture2D>("LinkSpriteSheetBlack");
                }
                else if (damageFrame % 4 == 2)
                {
                    currentSheet = aquamentusSpriteSheet[2];
                }
                else if (damageFrame % 4 == 1)
                {
                    currentSheet = aquamentusSpriteSheet[3];
                }
                else //damageFrameCount %4 == 0
                {
                    currentSheet = aquamentusSpriteSheet[0];
                }
            }
            else
            {
                SetOriginalColor();
            }
        }

        private void SetOriginalColor()
        {
            currentSheet = aquamentusSpriteSheet[0];
        }

        public void Reset()
        {
            stateMachine = new AquamentusStateMachine(init.Item1, init.Item2);
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
            //Won't get stunned
        }

        public bool IsDamaged()
        {
            return stateMachine.IsDamaged();
        }
    }
}
