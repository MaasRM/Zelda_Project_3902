using System;
namespace Sprint0
{
    public class InventoryUnPauseCommand : ICommand
    {
        private Sprint5 game;
        public InventoryUnPauseCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().GetLinkInventory().pauseScreen.setGamePaused(false);
        }
    }
}
