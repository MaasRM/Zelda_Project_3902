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
        private Texture2D aquamentusSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private AquamentusFireball fireballTop, fireballCenter, fireballBottom;
        private IPlayer linkRef;
        private Tuple<int, int> init;

        public Aquamentus(int x, int y, Texture2D spriteSheet, IPlayer link)
        {
            stateMachine = new AquamentusStateMachine(x, y);
            aquamentusSpriteSheet = spriteSheet;
            init = new Tuple<int, int>(x, y);
            linkRef = link;
            fireballTop = new AquamentusFireball(-1, -1, AquamentusFireball.Position.Top, spriteSheet, link);
            fireballCenter = new AquamentusFireball(-1, -1, AquamentusFireball.Position.Center, spriteSheet, link);
            fireballBottom = new AquamentusFireball(-1, -1, AquamentusFireball.Position.Bottom, spriteSheet, link);
        }

        public void Update()
        {
            stateMachine.Move();
            
            destination = stateMachine.GetDestination();
            source = stateMachine.GetSource();

            fireballTop.Update();
            fireballCenter.Update();
            fireballBottom.Update();

            if (!stateMachine.IsFiring())
            {
                if (stateMachine.TryToFire())
                {
                    int fireballX = destination.X + destination.Width / 4;
                    int fireballY = destination.Y + destination.Width / 2;
                    fireballTop = new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Top, aquamentusSpriteSheet, linkRef);
                    fireballCenter = new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Center, aquamentusSpriteSheet, linkRef);
                    fireballBottom = new AquamentusFireball(fireballX, fireballY, AquamentusFireball.Position.Bottom, aquamentusSpriteSheet, linkRef);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aquamentusSpriteSheet, destination, source, Color.White);
            fireballTop.Draw(spriteBatch);
            fireballCenter.Draw(spriteBatch);
            fireballBottom.Draw(spriteBatch);
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
