using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkIdleCommand : ICommand
    {
        private Sprint2 game;
        public LinkIdleCommand(Sprint2 sprint)
        {
            game = sprint;
        }

    public void Execute()
    {
        game.getPlayer().getLinkStateMachine().setIdle();
    }
}
}
