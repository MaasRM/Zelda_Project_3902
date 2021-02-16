using System;
namespace Sprint0
{
    public class PreviousBlockCommand : ICommand
    {
        private Sprint2 game;
        private int blockNum;

        public PreviousBlockCommand(Sprint2 sprint, int num)
        {
            game = sprint;
            blockNum = num;
        }

        public void Execute()
        {
        }
    }
}