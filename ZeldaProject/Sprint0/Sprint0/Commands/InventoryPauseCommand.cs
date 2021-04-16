using System;
namespace Sprint0
{
    public class InventoryPauseCommand : ICommand
    {
        private Sprint5 game;
        public InventoryPauseCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            Boolean currentState = game.GetPlayer().GetLinkInventory().pauseScreen.isGamePaused();
            game.GetPlayer().GetLinkInventory().pauseScreen.setGamePaused(!currentState);
        }
    }
}
