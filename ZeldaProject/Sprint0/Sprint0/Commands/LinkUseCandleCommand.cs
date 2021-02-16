using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class LinkUseCandleCommand : ICommand
    {
        private Sprint2 game;
        public LinkUseCandleCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setUseItem();
            game.GetPlayer().getLinkStateMachine().addProjectile(new CandleFireProjectile());
        }
    }
}
