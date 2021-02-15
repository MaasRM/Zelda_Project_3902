using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBlueBoomerangCommand : ICommand
    {
        private Sprint2 game;
        public LinkUseBlueBoomerangCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setUseItem();
            game.GetPlayer().getLinkStateMachine().addProjectile(new BlueBoomerangProjectile());
        }
    }
}
