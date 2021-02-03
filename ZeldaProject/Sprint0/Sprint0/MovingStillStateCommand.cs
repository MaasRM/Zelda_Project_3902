//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class MovingStillStateCommand : ICommand
    {
        private Sprint0 game;
        public MovingStillStateCommand(Sprint0 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!(game.GetGameSprite() is MovingStillSprite))
            {
                game.UpdateGameSprite(new MovingStillSprite(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 16, game.GraphicsDevice.Viewport.Height/2 + 25, 32, 64), new Rectangle(277, 1, 16, 32), 10, 10, game.characterFrames));
            }
        }
    }
}
