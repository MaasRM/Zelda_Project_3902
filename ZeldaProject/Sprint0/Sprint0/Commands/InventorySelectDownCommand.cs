using System;
namespace Sprint0
{
    public class InventorySelectDownCommand : ICommand
    {
        private Sprint4 game;
        public InventorySelectDownCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {

        }
    }
}
