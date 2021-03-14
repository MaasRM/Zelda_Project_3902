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
        private Texture2D wallmasterSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private SpriteEffects flip;
        private const int DAMAGE = 1;
        private Tuple<int, int, WallmasterStateMachine.Direction> init;

        public Wallmaster(int x, int y, WallmasterStateMachine.Direction d, Texture2D spritesheet)
        {
            stateMachine = new WallmasterStateMachine(x, y, d);
            wallmasterSpriteSheet = spritesheet;
            init = new Tuple<int, int, WallmasterStateMachine.Direction>(x, y, d);
        }

        public void Update()
        {
            stateMachine.Move();
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!stateMachine.IsWaiting())
            {
                WallmasterStateMachine.Direction initial = stateMachine.GetInitialDirection();
                WallmasterStateMachine.Direction second = stateMachine.GetInitialDirection();

                bool directionLeft = initial == WallmasterStateMachine.Direction.Left || second == WallmasterStateMachine.Direction.Left;
                bool directionDown = initial == WallmasterStateMachine.Direction.Down || second == WallmasterStateMachine.Direction.Down;

                if (directionLeft && directionDown)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
                }
                else if (directionLeft)
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
                else if (directionDown)
                {
                    flip = SpriteEffects.FlipVertically;
                }

                spriteBatch.Draw(wallmasterSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), flip, 0f);
            }   
        }

        public void TriggerWallmaster()
        {
            stateMachine.SetWallmaster();
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
            stateMachine = new WallmasterStateMachine(init.Item1, init.Item2, init.Item3);
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