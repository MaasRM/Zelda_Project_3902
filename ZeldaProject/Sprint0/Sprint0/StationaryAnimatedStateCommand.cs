//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryAnimatedStateCommand : ICommand
    {
        private Sprint0 game;
        public StationaryAnimatedStateCommand(Sprint0 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!(game.GetGameSprite() is StationaryAnimatedSprite))
            {
                Rectangle[] frames = new Rectangle[] {
                    new Rectangle(296, 1, 16, 32),
                    new Rectangle(314, 1, 16, 32),
                    new Rectangle(331, 1, 16, 32)
                };
                game.UpdateGameSprite(new StationaryAnimatedSprite(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 16, game.GraphicsDevice.Viewport.Height / 2 - 32, 32, 64), frames, frames.Length, game.characterFrames));
            }
        }
    }
}
