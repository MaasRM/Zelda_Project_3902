using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class LinkUseCandleCommand : ICommand
    {
        private Sprint3 game;
        public LinkUseCandleCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.AddProjectile(new CandleFireProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine()));
            }
            game.GetPlayer().getLinkStateMachine().setUseItem();
        }
    }
}
