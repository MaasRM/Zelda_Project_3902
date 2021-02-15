//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class MovingStillStateCommand : ICommand
    {
        private Sprint2 game;
        public MovingStillStateCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
