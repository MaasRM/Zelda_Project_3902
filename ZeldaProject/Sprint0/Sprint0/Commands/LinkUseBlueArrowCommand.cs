using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBlueArrowCommand : ICommand
    {
        private Sprint5 game;
        public LinkUseBlueArrowCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            Boolean alreadyExists = false;
            foreach (IProjectile proj in game.GetProjectiles())
            {
                if (proj is BlueArrowProjectile) alreadyExists = true;
            }
            if (!alreadyExists)
            {
                game.AddProjectile(new BlueArrowProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game.Link_soundEffects));
            }
            game.GetPlayer().getLinkStateMachine().setAnimation(Animation.UsingItem);
        }
    }
}
