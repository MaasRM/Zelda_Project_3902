using System;
namespace Sprint0
{
    public class InventoryPauseCommand : ICommand
    {
        private Sprint4 game;
        public InventoryPauseCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().GetLinkInventory().GetLinkPauseScreen().setGamePaused(true);
        }
    }
}
