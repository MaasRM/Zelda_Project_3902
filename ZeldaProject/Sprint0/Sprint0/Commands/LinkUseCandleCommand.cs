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
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.GetPlayer().getLinkStateMachine().addProjectile(new CandleFireProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine()));
            }
            game.GetPlayer().getLinkStateMachine().setUseItem();
        }
    }
}
