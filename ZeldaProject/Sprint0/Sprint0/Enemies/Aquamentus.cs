using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Aquamentus : INPC
    {
        private AquamentusStateMachine stateMachine;
        private Texture2D aquamentusSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private AquamentusFireballTriad fireballs;
        private IPlayer linkRef;
        private Tuple<int, int> init;

        public Aquamentus(int x, int y, Texture2D spriteSheet, IPlayer link)
        {
            stateMachine = new AquamentusStateMachine(x, y);
            aquamentusSpriteSheet = spriteSheet;
            init = new Tuple<int, int>(x, y);
            linkRef = link;
            fireballs = new AquamentusFireballTriad(-1, -1, spriteSheet, link);
        }

        public void Update()
        {
            stateMachine.Move();
            
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();

            fireballs.Update();

            if (!stateMachine.IsFiring())
            {
                if (stateMachine.TryToFire())
                {
                    int fireballX = destination.X + destination.Width / 4;
                    int fireballY = destination.Y + destination.Width / 2;
                    fireballs = new AquamentusFireballTriad(fireballX, fireballY, aquamentusSpriteSheet, linkRef);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aquamentusSpriteSheet, destination, source, Color.White);
            fireballs.Draw(spriteBatch);
        }

        public void Reset()
        {
            stateMachine = new AquamentusStateMachine(init.Item1, init.Item2);
        }
    }
}
