//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class MovingStillStateCommand : ICommand
    {
        private Sprint3 game;
        public MovingStillStateCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
