using System;
namespace Sprint0
{
    public class NextEnemyCommand : ICommand
    {
        private Sprint2 game;
        public NextEnemyCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}