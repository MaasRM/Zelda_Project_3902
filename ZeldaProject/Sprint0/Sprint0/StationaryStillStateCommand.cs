//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryStillStateCommand : ICommand
    {
        private Sprint2 game;
        public StationaryStillStateCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
