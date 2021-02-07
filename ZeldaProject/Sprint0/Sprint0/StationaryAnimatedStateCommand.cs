//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryAnimatedStateCommand : ICommand
    {
        private Sprint2 game;
        public StationaryAnimatedStateCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
