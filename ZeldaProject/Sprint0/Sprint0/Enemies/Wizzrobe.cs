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
        private GoriyaBoomerang boomerang;
        private List<Texture2D> wizzrobeSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private Sprint5 game;
        private Tuple<int, int, WizzrobeStateMachine.WizzrobeColor> init;
        private SoundEffectInstance flyingBoomerang;
        private RoomManager roomAccess;

        public Wizzrobe(int x, int y, WizzrobeStateMachine.WizzrobeColor c, List<Texture2D> spriteSheet, Sprint5 game)
        {
            stateMachine = new WizzrobeStateMachine(x, y, c);
            wizzrobeSpriteSheet = spriteSheet;
            currentSheet = spriteSheet[0];
            init = new Tuple<int, int, WizzrobeStateMachine.WizzrobeColor>(x, y, c);
            this.game = game;
            flyingBoomerang = game.Enemy_soundEffects[0].CreateInstance();
            roomAccess = game.GetRoomManager();

        }

        public void Update()
        {
            if (!stateMachine.Throwing() && stateMachine.TryToThrow())
            {
                flyingBoomerang.IsLooped = true;
                flyingBoomerang.Volume = 0.2f;
                flyingBoomerang.Play();
                game.AddProjectile(boomerang);
            }

            StopThrowSound();

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
            stateMachine = new WizzrobeStateMachine(init.Item1, init.Item2, init.Item3);
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
            if (!stateMachine.HasHealth())
            {
                StopThrowSound();
            }
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

        public void StopThrowSound()
        {
            if (!stateMachine.Throwing() || (roomAccess.getRoomIndex() != 1 && roomAccess.getRoomIndex() != 8))
            {
                flyingBoomerang.Stop();
                stateMachine.BoomerangReturned();
            }
        }
    }
}
