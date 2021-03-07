﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBombCommand : ICommand
    {
        private Sprint3 game;
        public LinkUseBombCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            if (!game.GetPlayer().getLinkStateMachine().getIsBusy())
            {
                game.GetPlayer().getLinkStateMachine().addProjectile(new BombProjectile(game.GetPlayer().GetSpriteSheet(), game.GetPlayer().getLinkStateMachine()));
            }
            game.GetPlayer().getLinkStateMachine().setUseItem();
        }
    }
}
