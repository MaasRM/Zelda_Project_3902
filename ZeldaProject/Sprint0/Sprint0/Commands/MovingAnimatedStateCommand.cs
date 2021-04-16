//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;
namespace Sprint0
{
    public class MovingAnimatedStateCommand : ICommand
    {
        private Sprint5 game;
        public MovingAnimatedStateCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
