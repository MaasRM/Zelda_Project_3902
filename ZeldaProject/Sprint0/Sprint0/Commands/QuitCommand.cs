//Code by: Nathan Schultz

using System;
namespace Sprint0
{
    public class QuitCommand : ICommand
    {
        private Sprint3 game;
        public QuitCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
