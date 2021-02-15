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
            game.GetPlayer().getLinkStateMachine().setUseItem();
            game.GetPlayer().getLinkStateMachine().addProjectile(new BlueArrowProjectile());
        }
    }
}
