using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBlueBoomerangCommand : ICommand
    {
        private Sprint5 game;
        public LinkUseBlueBoomerangCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            Boolean alreadyExists = false;
            foreach(IProjectile proj in game.GetProjectiles())
            {
                if (proj is BlueBoomerangProjectile) alreadyExists = true;
            }
            if (!alreadyExists)
            {
                game.AddProjectile(new BlueBoomerangProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine(), game.Link_soundEffects));
            }
            game.GetPlayer().getLinkStateMachine().setAnimation(Animation.UsingItem);
        }
    }
}
