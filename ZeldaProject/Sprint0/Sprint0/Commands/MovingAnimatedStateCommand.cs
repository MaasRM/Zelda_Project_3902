//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class MovingAnimatedStateCommand : ICommand
    {
        private Sprint3 game;
        public MovingAnimatedStateCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
