﻿using System;
namespace Sprint0
{
    public class PreviousItemCommand : ICommand
    {
        private Sprint2 game;
        public PreviousItemCommand(Sprint2 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}