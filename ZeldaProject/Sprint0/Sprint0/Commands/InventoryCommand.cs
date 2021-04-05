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
            Boolean currentState = game.GetPlayer().GetLinkInventory().GetLinkPauseScreen().isGamePaused();
            game.GetPlayer().GetLinkInventory().GetLinkPauseScreen().setGamePaused(!currentState);
        }
    }
}
