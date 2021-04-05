//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryAnimatedStateCommand : ICommand
    {
        private Sprint4 game;
        public StationaryAnimatedStateCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
