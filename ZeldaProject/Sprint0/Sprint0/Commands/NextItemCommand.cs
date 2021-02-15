using System;
namespace Sprint0
{
    public class NextItemCommand :ICommand
    {
        private Sprint2 game;
        public NextItemCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
