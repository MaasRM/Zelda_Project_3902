//Code by: Nathan Schultz

using System;
namespace Sprint0
{
    public class QuitCommand : ICommand
    {
        private Sprint4 game;
        public QuitCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
