using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkIdleCommand : ICommand
    {
        private Sprint4 game;
        public LinkIdleCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setIdle();
        }
    }
}
