using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class GoriyaBoomerang : IProjectile, IEnemyProjectile, IBoomerang
    {
        private GoriyaStateMachine goriyaState;
        private Texture2D spritesheet;
        private bool goBack;
        private Vector2 loc;
        private GoriyaStateMachine.Direction direction;
        private int frame;
        private SpriteEffects flip;

        private const int WIDTH = 8;
        private const int HEIGHT = 16;
        private const int maxframeCount = 21;
        private const int moveDist = 8;

        public GoriyaBoomerang(Texture2D spritesheet, GoriyaStateMachine state)
        {
            goriyaState = state;
            direction = goriyaState.GetDirection();
            InitialPosition();
            frame = 0;
            goBack = false;
            this.spritesheet = spritesheet;
        }

        public void Update()
        {
            frame++;
            if (frame > maxframeCount / 2) {
                GoBack();
            }

            if (!goBack)
            {
                if (direction == GoriyaStateMachine.Direction.Down) loc.Y += moveDist * GameConstants.SCALE;
                else if (direction == GoriyaStateMachine.Direction.Up) loc.Y -= moveDist * GameConstants.SCALE;
                else if (direction == GoriyaStateMachine.Direction.Left) loc.X -= moveDist * GameConstants.SCALE;
                else loc.X += moveDist * GameConstants.SCALE;
            }
            else if (goBack)
            {
                if (direction == GoriyaStateMachine.Direction.Down) loc.Y -= moveDist * GameConstants.SCALE;
                else if (direction == GoriyaStateMachine.Direction.Up) loc.Y += moveDist * GameConstants.SCALE;
                else if (direction == GoriyaStateMachine.Direction.Left) loc.X += moveDist * GameConstants.SCALE;
                else loc.X -= moveDist * GameConstants.SCALE;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritesheet, GetDestination(), GetSource(), Color.White, 0, new Vector2(0, 0), flip, 0f);
        }

        public Rectangle GetProjectileLocation()
        {
            return GetDestination();
        }

        private void InitialPosition()
        {
            Rectangle initial = goriyaState.GetDestination();
            loc = new Vector2(initial.X, initial.Y);

            if (direction == GoriyaStateMachine.Direction.Down) {
                loc.X += initial.Width / 2 - WIDTH * GameConstants.SCALE / 2;
                loc.Y += initial.Height;
            }
            else if (direction == GoriyaStateMachine.Direction.Up) {
                loc.X += initial.Width / 2 - WIDTH * GameConstants.SCALE / 2;
                loc.Y -= HEIGHT * GameConstants.SCALE;
            }
            else if (direction == GoriyaStateMachine.Direction.Left) {
                loc.X -= WIDTH * GameConstants.SCALE;
                loc.Y += initial.Height / 2 - HEIGHT * GameConstants.SCALE / 2;
            }
            else {
                loc.X += initial.Width;
                loc.Y += initial.Height / 2 - HEIGHT * GameConstants.SCALE / 2;
            }
        }

        private Rectangle GetDestination()
        {
            return new Rectangle((int)loc.X, (int)loc.Y, WIDTH * GameConstants.SCALE, HEIGHT * GameConstants.SCALE);
        }

        private Rectangle GetSource()
        {
            if (frame % 8 == 0 || frame % 8 == 1 || frame % 8 == 2) flip = SpriteEffects.None;
            else if (frame % 8 == 3 || frame % 8 == 4) flip = SpriteEffects.FlipHorizontally;
            else if (frame % 8 == 5) flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
            else if (frame % 8 == 6 || frame % 8 == 7) flip = SpriteEffects.FlipVertically;

            if (frame % 4 == 0) return new Rectangle(290, 11, 8, 15);
            else if (frame % 4 == 1 || frame % 4 == 3) return new Rectangle(299, 11, 8, 15);
            else return new Rectangle(308, 11, 8, 15);
        }

        public bool CheckForRemoval()
        {
            float xTemp = loc.X;
            float yTemp = loc.Y;
            bool result;
            InitialPosition();

            if (direction == GoriyaStateMachine.Direction.Down) result = yTemp <= loc.Y;
            else if (direction == GoriyaStateMachine.Direction.Up) result = yTemp >= loc.Y;
            else if (direction == GoriyaStateMachine.Direction.Left) result = xTemp >= loc.X;
            else result = xTemp <= loc.X;

            if(result) goriyaState.BoomerangReturned();

            loc.Y = yTemp;
            loc.X = xTemp;

            return result;
        }

        public void GoBack()
        {
            goBack = true;
        }

        public int GetDamage()
        {
            return 1;
        }

        public void Deflect(Vector2 deflection)
        {
            GoBack();
        }

        public void Hit()
        {
            GoBack();
        }
    }
}
