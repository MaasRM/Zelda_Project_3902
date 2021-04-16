//Code by: Nathan Schultz

using System;
namespace Sprint0
{
    public class QuitCommand : ICommand
    {
        private Sprint5 game;
        public QuitCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
