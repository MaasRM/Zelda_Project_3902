using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBombCommand : ICommand
    {
        private Sprint4 game;
        public LinkUseBombCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.AddProjectile(new BombProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game.Link_soundEffects));
            }
            game.GetPlayer().getLinkStateMachine().setAnimation(Animation.UsingItem);
        }
    }
}
