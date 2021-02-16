﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkUseBrownBoomerangCommand : ICommand
    {
        private Sprint2 game;
        public LinkUseBrownBoomerangCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().setUseItem();
            game.GetPlayer().getLinkStateMachine().addProjectile(new BrownBoomerangProjectile(game.GetPlayer().getLinkStateMachine()));
        }
    }
}
