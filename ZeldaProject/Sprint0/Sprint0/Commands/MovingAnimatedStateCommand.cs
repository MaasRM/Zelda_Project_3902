//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class MovingAnimatedStateCommand : ICommand
    {
        private Sprint2 game;
        public MovingAnimatedStateCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
