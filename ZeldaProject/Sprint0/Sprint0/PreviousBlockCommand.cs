using System;
namespace Sprint0
{
    public class PreviousBlockCommand : ICommand
    {
        private Sprint2 game;
        public PreviousBlockCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}