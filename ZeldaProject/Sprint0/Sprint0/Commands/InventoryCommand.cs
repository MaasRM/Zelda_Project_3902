using System;
namespace Sprint0
{
    public class InventoryCommand : ICommand
    {
        private Sprint4 game;
        public InventoryCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            Boolean currentState = game.GetPlayer().GetLinkInventory().GetLinkPauseScreen().isGamePaused();
            game.GetPlayer().GetLinkInventory().GetLinkPauseScreen().setGamePaused(!currentState);
        }
    }
}
