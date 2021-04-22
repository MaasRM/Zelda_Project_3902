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
        private List<Texture2D> ZolSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private const int DAMAGE = 1;
        private Tuple<int, int, ZolStateMachine.ZolColor> init;

        public Zol(int x, int y, ZolStateMachine.ZolColor c, List<Texture2D> spriteSheet)
        {
            stateMachine = new ZolStateMachine(x, y, c);
            ZolSpriteSheet = spriteSheet;
            currentSheet = spriteSheet[0];
            init = new Tuple<int, int, ZolStateMachine.ZolColor>(x, y, c);
            ChangeSpriteSheet();
        }

        public void Update()
        {
            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
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

                if (damageFrame % 4 == 3) currentSheet = ZolSpriteSheet[1];
                else if (damageFrame % 4 == 2) currentSheet = ZolSpriteSheet[2];
                else if (damageFrame % 4 == 1) currentSheet = ZolSpriteSheet[3];
                else currentSheet = ZolSpriteSheet[0];
            }
            else
            {
                SetOriginalColor();
            }
        }

        private void SetOriginalColor()
        {
            currentSheet = ZolSpriteSheet[0];
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
