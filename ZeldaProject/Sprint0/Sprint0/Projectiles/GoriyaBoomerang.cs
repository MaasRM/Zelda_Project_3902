using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint0
{
    public class GoriyaBoomerang : IProjectile
    {
        private GoriyaStateMachine goriyaState;
        private Texture2D spritesheet;
        private int x;
        private int y;
        private int width;
        private int height;
        private GoriyaStateMachine.Direction direction;
        private int frame;
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
            spriteBatch.Draw(spritesheet, GetDestination(), GetSource(), Color.White);

            if (frame == frameCount)
            {
                goriyaState.BoomerangReturned();
            }
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
            return new Rectangle(290 + 9 * (frame % 3), 11, width, height);
        }
    }
}
