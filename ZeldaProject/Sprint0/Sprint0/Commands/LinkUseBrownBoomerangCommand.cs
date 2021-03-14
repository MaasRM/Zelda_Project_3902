﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBrownBoomerangCommand : ICommand
    {
        private Sprint3 game;
        public LinkUseBrownBoomerangCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.AddProjectile(new BrownBoomerangProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine()));
            }
            game.GetPlayer().getLinkStateMachine().setUseItem();
        }
    }
}
