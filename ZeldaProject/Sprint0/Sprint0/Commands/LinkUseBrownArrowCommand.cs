using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBrownArrowCommand : ICommand
    {
        private Sprint2 game;
        public LinkUseBrownArrowCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setUseItem();
            game.GetPlayer().getLinkStateMachine().addProjectile(new BrownArrowProjectile(game.GetPlayer().getLinkStateMachine()));
        }
    }
}
