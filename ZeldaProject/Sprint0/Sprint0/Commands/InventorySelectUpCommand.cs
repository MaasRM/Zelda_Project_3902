using System;
namespace Sprint0
{
    public class InventorySelectUpCommand : ICommand
    {
        private Sprint4 game;
        public InventorySelectUpCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            
        }
    }
}
