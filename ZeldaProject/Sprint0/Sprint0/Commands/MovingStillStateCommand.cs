//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class MovingStillStateCommand : ICommand
    {
        private Sprint4 game;
        public MovingStillStateCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
