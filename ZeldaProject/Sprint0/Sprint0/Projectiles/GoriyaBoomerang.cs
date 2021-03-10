using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class GoriyaBoomerang : IProjectile, IEnemyProjectile
    {
        private GoriyaStateMachine goriyaState;
        private Texture2D spritesheet;
        private int x;
        private int y;
        private int width;
        private int height;
        private GoriyaStateMachine.Direction direction;
        private int frame;
        private SpriteEffects flip;
        private const int frameCount = 21;
        private const int moveDist = 8;
        private const int PIXELSCALER = 2;

        public GoriyaBoomerang(Texture2D spritesheet, GoriyaStateMachine state)
        {
            goriyaState = state;
            direction = goriyaState.GetDirection();
            width = 8;
            height = 16;
            InitialPosition();
            frame = 0;
            this.spritesheet = spritesheet;
        }

        public void Update()
        {
            frame++;
            if (frame < frameCount / 2)
            {
                if(direction == GoriyaStateMachine.Direction.Down)
                {
                    y += moveDist * PIXELSCALER;
                }
                else if(direction == GoriyaStateMachine.Direction.Up)
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
            else if (frame > frameCount / 2 + 2)
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
            spriteBatch.Draw(spritesheet, GetDestination(), GetSource(), Color.White, 0, new Vector2(0, 0), flip, 0f);

            if (frame == frameCount)
            {
                goriyaState.BoomerangReturned();
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

            if(direction == GoriyaStateMachine.Direction.Down)
            {
                x += goriyaState.GetWidth() / 2 - width * PIXELSCALER / 2;
                y += goriyaState.GetHeight();
            }
            else if (direction == GoriyaStateMachine.Direction.Up)
            {
                x += goriyaState.GetWidth() / 2 - width * PIXELSCALER / 2;
                y -= height * PIXELSCALER;
            }
            else if (direction == GoriyaStateMachine.Direction.Left)
            {
                x -= width * PIXELSCALER;
                y += goriyaState.GetHeight() / 2 - height * PIXELSCALER / 2;
            }
            else
            {
                x += goriyaState.GetWidth();
                y += goriyaState.GetHeight() / 2 - height * PIXELSCALER / 2;
            }
        }

        private Rectangle GetDestination()
        {
            return new Rectangle(x, y, width * PIXELSCALER, height * PIXELSCALER);
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
    }
}
