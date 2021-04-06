using System;
namespace Sprint0
{
    public class InventoryUnPauseCommand : ICommand
    {
        private Sprint4 game;
        public InventoryUnPauseCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().GetLinkInventory().GetLinkPauseScreen().setGamePaused(false);
        }
    }
}
