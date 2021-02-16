using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBombCommand : ICommand
    {
        private Sprint2 game;
        public LinkUseBombCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.GetPlayer().getLinkStateMachine().addProjectile(new BombProjectile(game.GetPlayer().getLinkStateMachine()));
            }
            game.GetPlayer().getLinkStateMachine().setUseItem();
        }
    }
}
