using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkIdleCommand : ICommand
    {
        private Sprint3 game;
        public LinkIdleCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setIdle();
        }
    }
}
