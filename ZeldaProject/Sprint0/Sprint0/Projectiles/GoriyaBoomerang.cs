using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private int x;
        private int y;
        private const int WIDTH = 8;
        private const int HEIGHT = 16;
        private GoriyaStateMachine.Direction direction;
        private int frame;
        private SpriteEffects flip;
        private const int maxframeCount = 21;
        private const int moveDist = 8;
        private const int PIXELSCALER = 4;

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
            if (frame > maxframeCount / 2)
            {
                GoBack();
            }

            if (!goBack)
            {
                if (direction == GoriyaStateMachine.Direction.Down)
                {
                    y += moveDist * PIXELSCALER;
                }
                else if (direction == GoriyaStateMachine.Direction.Up)
                {
                    y -= moveDist * PIXELSCALER;
                }
                else if (direction == GoriyaStateMachine.Direction.Left)
                {
                    x -= moveDist * PIXELSCALER;
                }
                else
                {
                    x += moveDist * PIXELSCALER;
                }
            }
            else if (goBack)
            {
                if (direction == GoriyaStateMachine.Direction.Down)
                {
                    y -= moveDist * PIXELSCALER;
                }
                else if (direction == GoriyaStateMachine.Direction.Up)
                {
                    y += moveDist * PIXELSCALER;
                }
                else if (direction == GoriyaStateMachine.Direction.Left)
                {
                    x += moveDist * PIXELSCALER;
                }
                else
                {
                    x -= moveDist * PIXELSCALER;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (CheckForRemoval())
            {
                goriyaState.BoomerangReturned();
            }
            else
            {
                spriteBatch.Draw(spritesheet, GetDestination(), GetSource(), Color.White, 0, new Vector2(0, 0), flip, 0f);
            }
        }

        public Rectangle GetProjectileLocation()
        {
            return GetDestination();
        }

        private void InitialPosition()
        {
            Rectangle initial = goriyaState.GetDestination();
            x = initial.X;
            y = initial.Y;

            if (direction == GoriyaStateMachine.Direction.Down)
            {
                x += goriyaState.GetWidth() / 2 - WIDTH * PIXELSCALER / 2;
                y += goriyaState.GetHeight();
            }
            else if (direction == GoriyaStateMachine.Direction.Up)
            {
                x += goriyaState.GetWidth() / 2 - WIDTH * PIXELSCALER / 2;
                y -= HEIGHT * PIXELSCALER;
            }
            else if (direction == GoriyaStateMachine.Direction.Left)
            {
                x -= WIDTH * PIXELSCALER;
                y += goriyaState.GetHeight() / 2 - HEIGHT * PIXELSCALER / 2;
            }
            else
            {
                x += goriyaState.GetWidth();
                y += goriyaState.GetHeight() / 2 - HEIGHT * PIXELSCALER / 2;
            }
        }

        private Rectangle GetDestination()
        {
            return new Rectangle(x, y, WIDTH * PIXELSCALER, HEIGHT * PIXELSCALER);
        }

        private Rectangle GetSource()
        {
            if (frame % 8 == 0 || frame % 8 == 1 || frame % 8 == 2)
            {
                flip = SpriteEffects.None;
            }
            else if (frame % 8 == 3 || frame % 8 == 4)
            {
                flip = SpriteEffects.FlipHorizontally;
            }
            else if (frame % 8 == 5)
            {
                flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
            }
            else if (frame % 8 == 6 || frame % 8 == 7)
            {
                flip = SpriteEffects.FlipVertically;
            }

            if (frame % 4 == 0)
            {
                return new Rectangle(290, 11, 8, 15);
            }
            else if (frame % 4 == 1 || frame % 4 == 3)
            {
                return new Rectangle(299, 11, 8, 15);
            }
            else
            {
                return new Rectangle(308, 11, 8, 15);
            }
        }

        public bool CheckForRemoval()
        {
            int xTemp = x;
            int yTemp = y;
            bool result;
            InitialPosition();

            if (direction == GoriyaStateMachine.Direction.Down)
            {
                result = yTemp <= y;
            }
            else if (direction == GoriyaStateMachine.Direction.Up)
            {
                result = yTemp >= y;
            }
            else if (direction == GoriyaStateMachine.Direction.Left)
            {
                result = xTemp >= x;
            }
            else
            {
                result = xTemp <= x;
            }

            y = yTemp;
            x = xTemp;

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
