using System;
namespace Sprint0
{
    public class NextBlockCommand : ICommand
    {
        private Sprint2 game;
        private int blockNum;
        private IBlock newBlock;

        public NextBlockCommand(Sprint2 sprint, int num)
        {
            game = sprint;
            blockNum = num;        
        }

        public void Execute()
        {
            if(blockNum == 0){
                //assign newBlock to a newly created block from Block class 
            }else if(blockNum == 1){
                //assign newBlock to a newly created block from Block class
            }else if(blockNum == 2){
                //assign newBlock to a newly created block from Block class
            }else{
                blockNum = blockNum % 3;
                this.Execute();
            }
            
            game.UpdateGameBlock(newBlock);
        }
    }
}