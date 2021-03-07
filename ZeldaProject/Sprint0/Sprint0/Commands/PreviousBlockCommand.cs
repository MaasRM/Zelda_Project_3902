using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace Sprint0
{
    public class PreviousBlockCommand : ICommand
    {
        private Sprint3 game;

        public PreviousBlockCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.block.decrementIndex();
        }
    }
}