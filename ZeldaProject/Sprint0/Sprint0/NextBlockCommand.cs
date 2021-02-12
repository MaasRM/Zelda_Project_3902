using System;
namespace Sprint0
{
    public class NextBlockCommand : ICommand
    {
        private Sprint2 game;
        private int blockNum;

        public NextBlockCommand(Sprint2 sprint, int num)
        {
            game = sprint;
            blockNum = num;        
        }

        public void Execute()
        {
            //check what the index is and change sprite
            //may only need one class if thats how the index is handled
        }
    }
}