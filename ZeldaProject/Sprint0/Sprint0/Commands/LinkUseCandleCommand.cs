using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class LinkUseCandleCommand : ICommand
    {
        private Sprint4 game;
        public LinkUseCandleCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            Boolean alreadyExists = false;
            foreach (IProjectile proj in game.GetProjectiles())
            {
                if (proj is CandleFireProjectile) alreadyExists = true;
            }
            if (!alreadyExists)
            {
                game.AddProjectile(new CandleFireProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game.Link_soundEffects));
            }
            game.GetPlayer().getLinkStateMachine().setAnimation(Animation.UsingItem);
        }
    }
}
