using System;
namespace Sprint0
{
    public class InventorySelectUpCommand : ICommand
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private Sprint5 game;
        public InventorySelectUpCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().GetLinkInventory().changeCurrentItem(LinkInventory.Direction.Up);
        }
    }
}
