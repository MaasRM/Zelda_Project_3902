﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBlueBoomerangCommand : ICommand
    {
        private Sprint3 game;
        public LinkUseBlueBoomerangCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.GetPlayer().getLinkStateMachine().addProjectile(new BlueBoomerangProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine()));
            }
            game.GetPlayer().getLinkStateMachine().setUseItem();
        }
    }
}
