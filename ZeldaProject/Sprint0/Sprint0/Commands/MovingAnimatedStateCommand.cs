//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class MovingAnimatedStateCommand : ICommand
    {
        private Sprint4 game;
        public MovingAnimatedStateCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
