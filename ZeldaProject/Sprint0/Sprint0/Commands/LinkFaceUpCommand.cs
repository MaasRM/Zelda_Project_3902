﻿using System;
namespace Sprint0
{
    public class LinkFaceUpCommand : ICommand
    {
        private Sprint2 game;
        public LinkFaceUpCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceUp();
        }
    }
}
