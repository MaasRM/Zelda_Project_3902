using System;
using System.Diagnostics;

namespace Sprint0
{
    public class PreviousRoomCommand : ICommand
    {
        private Sprint5 game;
        public PreviousRoomCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetRoomManager().PreviousRoom();
            if (game.GetRoomManager().getRoomIndex() == GameConstants.SHOPROOM)
            {
                game.getShop().UpdateItems();
                game.getShop().SetUpShop();
            }
        }
    }
}
