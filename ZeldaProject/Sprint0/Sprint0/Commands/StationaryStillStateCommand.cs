//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryStillStateCommand : ICommand
    {
        private Sprint5 game;
        public StationaryStillStateCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
