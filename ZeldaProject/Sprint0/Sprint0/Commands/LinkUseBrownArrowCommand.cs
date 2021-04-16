using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBrownArrowCommand : ICommand
    {
        private Sprint5 game;
        public LinkUseBrownArrowCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            Boolean alreadyExists = false;
            foreach (IProjectile proj in game.GetProjectiles())
            {
                if (proj is BrownArrowProjectile) alreadyExists = true;
            }
            if (!alreadyExists)
            {
                game.AddProjectile(new BrownArrowProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game.Link_soundEffects));
            }
            game.GetPlayer().getLinkStateMachine().setAnimation(Animation.UsingItem);
        }
    }
}
