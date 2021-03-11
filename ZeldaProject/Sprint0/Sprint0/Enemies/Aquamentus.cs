﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Aquamentus : INPC, IEnemy
    {
        private AquamentusStateMachine stateMachine;
        private Texture2D aquamentusSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private Sprint3 game;
        private Tuple<int, int> init;

        public Aquamentus(int x, int y, Texture2D spriteSheet, Sprint3 game)
        {
            stateMachine = new AquamentusStateMachine(x, y);
            aquamentusSpriteSheet = spriteSheet;
            init = new Tuple<int, int>(x, y);
            this.game = game;
        }

        public void Update()
        {
            stateMachine.Move();
            
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();

            if (!stateMachine.IsFiring())
            {
                if (stateMachine.TryToFire())
                {
                    int fireballX = destination.X + destination.Width / 4;
                    int fireballY = destination.Y + destination.Width / 2;
                    game.AddProjectile(new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Top, aquamentusSpriteSheet, game));
                    game.AddProjectile(new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Center, aquamentusSpriteSheet, game));
                    game.AddProjectile(new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Bottom, aquamentusSpriteSheet, game));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aquamentusSpriteSheet, destination, source, Color.White);
        }

        public void Reset()
        {
            stateMachine = new AquamentusStateMachine(init.Item1, init.Item2);
        }

        public Rectangle GetNPCLocation()
        {
            return destination;
        }

        public void Damage()
        {

        }
    }
}
