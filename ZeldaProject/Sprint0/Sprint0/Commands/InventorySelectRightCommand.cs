using System;
namespace Sprint0
{
    public class InventorySelectRightCommand : ICommand
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        private Sprint5 game;
        public InventorySelectRightCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().GetLinkInventory().changeCurrentItem(LinkInventory.Direction.Right);
        }
    }
}
