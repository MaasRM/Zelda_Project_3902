﻿using System;
namespace Sprint0
{
    public class LinkFaceLeftCommand : ICommand
    {
        private Sprint2 game;
        public LinkFaceLeftCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceLeft();
        }
    }
}
