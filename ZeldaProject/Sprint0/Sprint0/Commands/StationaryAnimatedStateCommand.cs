//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryAnimatedStateCommand : ICommand
    {
        private Sprint3 game;
        public StationaryAnimatedStateCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
