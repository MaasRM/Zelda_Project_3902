using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Wallmaster : INPC, IEnemy
    {
        private WallmasterStateMachine stateMachine;
        private List<Texture2D> wallmasterSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private SpriteEffects flip;
        private HealthAndDamageHandler healthAndDamage;
        private const int MAXHEALTH = 4;
        private const int DAMAGE = 1;
        private Tuple<int, int> init;

        public Wallmaster(int x, int y, List<Texture2D> spritesheet)
        {
            stateMachine = new WallmasterStateMachine(x, y);
            wallmasterSpriteSheet = spritesheet;
            currentSheet = spritesheet[0];
            init = new Tuple<int, int>(x, y);
            healthAndDamage = new HealthAndDamageHandler(MAXHEALTH, DAMAGE);
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
            if(stateMachine.activity != WallmasterStateMachine.Activity.Waiting)
            {
                WallmasterStateMachine.Direction initial = stateMachine.initialDirection;
                WallmasterStateMachine.Direction second = stateMachine.GetSecondDirection();

                bool directionLeft = initial == WallmasterStateMachine.Direction.Left || second == WallmasterStateMachine.Direction.Left;
                bool directionDown = initial == WallmasterStateMachine.Direction.Down || second == WallmasterStateMachine.Direction.Down;

                if (directionLeft && directionDown) flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
                else if (directionLeft) flip = SpriteEffects.FlipHorizontally;
                else if (directionDown) flip = SpriteEffects.FlipVertically;

                spriteBatch.Draw(currentSheet, destination, source, Color.White, 0, new Vector2(0, 0), flip, 0f);
            }   
        }

        private void ChangeSpriteSheet()
        {
            if(stateMachine.IsDamaged())
            {
                int damageFrame = stateMachine.GetDamageFrame();

                if (damageFrame % 4 == 3) currentSheet = wallmasterSpriteSheet[1];
                else if (damageFrame % 4 == 2) currentSheet = wallmasterSpriteSheet[2];
                else if (damageFrame % 4 == 1) currentSheet = wallmasterSpriteSheet[3];
                else currentSheet = wallmasterSpriteSheet[0];
            }
            else
            {
                SetOriginalColor();
            }
        }

        private void SetOriginalColor()
        {
            currentSheet = wallmasterSpriteSheet[0];
        }

        public void TriggerWallmaster()
        {
            stateMachine.SetWallmaster();
        }

        public bool CanGrab()
        {
            return stateMachine.activity == WallmasterStateMachine.Activity.Moving;
        }

        public bool Grabbing()
        {
            return stateMachine.GetGrabStatus();
        }

        public void GrabPlayer()
        {
            stateMachine.GrabLink();
        }

        public void Reset()
        {
            stateMachine = new WallmasterStateMachine(init.Item1, init.Item2);
        }

        public Rectangle GetNPCLocation()
        {
            return destination;
        }

        public int GetDamageValue()
        {
            return healthAndDamage.DealDamage();
        }

        public void SetDamageState(int damage, Vector2 direction)
        {
            healthAndDamage.GetDamaged(damage);
            stateMachine.SetDamageVector(direction);
        }

        public void SetPosition(Rectangle newPos)
        {
            destination = newPos;
            stateMachine.SetDestination(destination.X, destination.Y);
        }

        public bool StillAlive()
        {
            return healthAndDamage.IsAlive();
        }

        public void Stun()
        {
            stateMachine.state = WallmasterStateMachine.State.Stun;
        }

        public bool IsDamaged()
        {
            return stateMachine.state == WallmasterStateMachine.State.Damaged;
        }
    }
}