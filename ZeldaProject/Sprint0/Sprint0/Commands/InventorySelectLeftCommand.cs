using System;
namespace Sprint0
{
    public class InventorySelectLeftCommand : ICommand
    {
        private Sprint4 game;
        public InventorySelectLeftCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            
        }
    }
}
