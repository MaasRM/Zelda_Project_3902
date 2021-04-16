//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class MovingStillStateCommand : ICommand
    {
        private Sprint5 game;
        public MovingStillStateCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
