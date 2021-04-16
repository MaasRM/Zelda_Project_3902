using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseRecorderCommand : ICommand
    {
        private Sprint5 game;
        public LinkUseRecorderCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.Link_soundEffects[5].Play();
            game.GetRoomManager().ChangeRoom(GameConstants.OUTSIDEROOM);
            game.GetPlayer().getLinkStateMachine().setAnimation(Animation.UsingItem);
        }
    }
}
