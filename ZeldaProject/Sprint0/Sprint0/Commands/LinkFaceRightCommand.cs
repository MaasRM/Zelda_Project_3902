﻿using System;
namespace Sprint0
{
    public class LinkFaceRightCommand : ICommand
    {
        private Sprint2 game;
        public LinkFaceRightCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceRight();
        }
    }
}
