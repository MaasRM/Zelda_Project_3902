using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBlueArrowCommand : ICommand
    {
        private Sprint3 game;
        public LinkUseBlueArrowCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.AddProjectile(new BlueArrowProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game.Link_soundEffects));
            }
            game.GetPlayer().getLinkStateMachine().setUseItem();
        }
    }
}
