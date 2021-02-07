using System;
namespace Sprint0
{
    public class PreviousEnemyCommand : ICommand
    {
        private Sprint2 game;
        public PreviousEnemyCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}