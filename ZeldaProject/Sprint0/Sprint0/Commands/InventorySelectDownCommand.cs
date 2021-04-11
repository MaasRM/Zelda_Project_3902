using System;
namespace Sprint0
{
    public class InventorySelectDownCommand : ICommand
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        private Sprint4 game;
        public InventorySelectDownCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().GetLinkInventory().changeCurrentItem(LinkInventory.Direction.Down);
        }
    }
}
