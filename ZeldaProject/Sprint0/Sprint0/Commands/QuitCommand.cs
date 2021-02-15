//Code by: Nathan Schultz

using System;
namespace Sprint0
{
    public class QuitCommand : ICommand
    {
        private Sprint2 game;
        public QuitCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
