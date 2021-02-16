using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBlueArrowCommand : ICommand
    {
        private Sprint2 game;
        public LinkUseBlueArrowCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.GetPlayer().getLinkStateMachine().addProjectile(new BlueArrowProjectile(game.GetPlayer().getLinkStateMachine()));
            }
            game.GetPlayer().getLinkStateMachine().setUseItem();
        }
    }
}
