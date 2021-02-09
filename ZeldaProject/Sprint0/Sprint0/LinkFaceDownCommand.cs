﻿using System;
namespace Sprint0
{
    public class LinkFaceDownCommand : ICommand
    {
        private Sprint2 game;
        public LinkFaceDownCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.getPlayer().getLinkStateMachine().faceDown();
            game.getPlayer().changeYLocation(5);
        }
    }
}
