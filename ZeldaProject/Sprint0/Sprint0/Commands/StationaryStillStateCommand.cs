﻿//Code by: Nathan Schultz

using System;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class StationaryStillStateCommand : ICommand
    {
        private Sprint4 game;
        public StationaryStillStateCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
        }
    }
}
