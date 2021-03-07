//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryStillStateCommand : ICommand
    {
        private Sprint3 game;
        public StationaryStillStateCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
