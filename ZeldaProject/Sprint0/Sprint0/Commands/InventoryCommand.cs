using System;
namespace Sprint0
{
    public class InventoryCommand : ICommand
    {
        private Sprint3 game;
        public InventoryCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            
        }
    }
}
