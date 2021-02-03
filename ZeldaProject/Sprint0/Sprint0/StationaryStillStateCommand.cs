//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryStillStateCommand : ICommand
    {
        private Sprint0 game;
        public StationaryStillStateCommand(Sprint0 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!(game.GetGameSprite() is StationaryStillSprite))
            {
                game.UpdateGameSprite(new StationaryStillSprite(new Rectangle((int)game.GraphicsDevice.Viewport.Width / 2 - 16, (int)game.GraphicsDevice.Viewport.Height/2 - 32, 32, 64), new Rectangle(258, 1, 16, 32), game.characterFrames));
            }
        }
    }
}
