using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Goriya : INPC, IEnemy
    {
        private GoriyaStateMachine stateMachine;
        private GoriyaBoomerang boomerang;
        private List<Texture2D> goriyaSpriteSheet;
        private Texture2D currentSheet;
        private Rectangle source;
        private Rectangle destination;
        private Sprint5 game;
        private Tuple<int, int, GoriyaStateMachine.GoriyaColor> init;
        private SoundEffectInstance flyingBoomerang;
        private RoomManager roomAccess;

        public Goriya(int x, int y, GoriyaStateMachine.GoriyaColor c, List<Texture2D> spriteSheet, Sprint5 game)
        {
            stateMachine = new GoriyaStateMachine(x, y, c);
            goriyaSpriteSheet = spriteSheet;
            currentSheet = spriteSheet[0];
            init = new Tuple<int, int, GoriyaStateMachine.GoriyaColor>(x, y, c);
            this.game = game;
            flyingBoomerang = game.Enemy_soundEffects[0].CreateInstance();
            roomAccess = game.GetRoomManager();

        }

        public void Update()
        {
            if (!stateMachine.Throwing() && stateMachine.TryToThrow())
            {
                boomerang = new GoriyaBoomerang(goriyaSpriteSheet[0], stateMachine);
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

                if (damageFrame % 4 == 3) currentSheet = goriyaSpriteSheet[1];
                else if (damageFrame % 4 == 2) currentSheet = goriyaSpriteSheet[2];
                else if (damageFrame % 4 == 1) currentSheet = goriyaSpriteSheet[3];
                else currentSheet = goriyaSpriteSheet[0];
            }
            else SetOriginalColor();
        }

        private void SetOriginalColor()
        {
            currentSheet = goriyaSpriteSheet[0];
        }

        public void Reset()
        {
            stateMachine = new GoriyaStateMachine(init.Item1, init.Item2, init.Item3);
            flyingBoomerang.Stop();
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
            StopThrowSound();
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
            if (!stateMachine.Throwing() || (roomAccess.getRoomIndex() != 1 && roomAccess.getRoomIndex() != 8 && roomAccess.getRoomIndex() != 29) || !stateMachine.HasHealth())
            {
                flyingBoomerang.Stop();
                stateMachine.BoomerangReturned();
            }
        }
    }
}