using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Link : IPlayer
    {
        private LinkStateMachine stateMachine;
        private Texture2D linkSpriteSheet;
        private Rectangle source;
        private Rectangle destination;
        private LinkColor currentColor;

        public Link(Texture2D spriteSheet)
        {
            stateMachine = new LinkStateMachine();
            linkSpriteSheet = spriteSheet;
            currentColor = LinkColor.Green;
        }

        public void Update()
        {
            source = stateMachine.getSource();
            destination = stateMachine.getDestination();
            if (currentColor != stateMachine.getColor())
            {
                changeColor(currentColor, stateMachine.getColor());
            }
            currentColor = stateMachine.getColor();
            stateMachine.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (stateMachine.getDirection() == Direction.MoveLeft)
            {
                spriteBatch.Draw(linkSpriteSheet, destination, source, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            } 
            else
            {
                spriteBatch.Draw(linkSpriteSheet, destination, source, Color.White);
            }
        }

        public void changeColor(LinkColor currentColor, LinkColor newColor)
        {
            Color[] data = new Color[linkSpriteSheet.Width * linkSpriteSheet.Height];
            linkSpriteSheet.GetData(data);
            Color colorTo;
            Color green = new Color(128, 208, 16, 255);
            Color red = new Color(216, 40, 0, 255);
            Color white = new Color(196, 212, 252, 255);

            if (newColor == LinkColor.Green)
            {
                colorTo = green;
            }
            else if (newColor == LinkColor.Red)
            {
                colorTo = red;
            }
            else //LinkColor.White
            {
                colorTo = white;
            }

            if (currentColor == LinkColor.Green)
            {
                for (int i = 0; i < data.Length; i++)
                    if (data[i] == green)
                        data[i] = colorTo;
            }
            else if (currentColor == LinkColor.Red)
            {
                for (int i = 0; i < data.Length; i++)
                    if (data[i] == red)
                        data[i] = colorTo;
            }
            else //LinkColor.White
            {
                for (int i = 0; i < data.Length; i++)
                    if (data[i] == white)
                        data[i] = colorTo;
            }

            linkSpriteSheet.SetData(data);
        }

        public LinkStateMachine getLinkStateMachine()
        {
            return stateMachine;
        }
    }
}
