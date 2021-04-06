using System;
namespace Sprint0
{
    public class InventorySelectRightCommand : ICommand
    {
        private Sprint4 game;
        public InventorySelectRightCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            
        }
    }
}
