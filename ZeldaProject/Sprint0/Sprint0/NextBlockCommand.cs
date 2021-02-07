using System;
namespace Sprint0
{
    public class NextBlockCommand : ICommand
    {
        private Sprint2 game;
        public NextBlockCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}