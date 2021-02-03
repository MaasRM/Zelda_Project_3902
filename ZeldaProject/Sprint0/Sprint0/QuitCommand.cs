//Code by: Nathan Schultz

using System;
namespace Sprint0
{
    public class QuitCommand : ICommand
    {
        private Sprint0 game;
        public QuitCommand(Sprint0 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
