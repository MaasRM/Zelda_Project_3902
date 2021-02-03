//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class MovingAnimatedStateCommand : ICommand
    {
        private Sprint0 game;
        public MovingAnimatedStateCommand(Sprint0 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!(game.GetGameSprite() is MovingAnimatedSprite))
            {
                Rectangle[] frames = new Rectangle[] {
                    new Rectangle(296, 1, 16, 32),
                    new Rectangle(314, 1, 16, 32),
                    new Rectangle(331, 1, 16, 32),
                    new Rectangle(147, 1, 16, 32),
                    new Rectangle(201, 1, 16, 32),
                    new Rectangle(183, 1, 16, 32),
                    new Rectangle(166, 1, 16, 32),
                    new Rectangle(350, 1, 16, 32)
                };
                game.UpdateGameSprite(new MovingAnimatedSprite(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 80, game.GraphicsDevice.Viewport.Height/2 - 16, 32, 64), frames, frames.Length, 6, game.characterFrames));
            }
        }
    }
}
