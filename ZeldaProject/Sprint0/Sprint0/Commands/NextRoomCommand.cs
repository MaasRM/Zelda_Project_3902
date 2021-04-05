using System;
using System.Diagnostics;

namespace Sprint0
{
    public class NextRoomCommand : ICommand
    {
        private Sprint4 game;
        public NextRoomCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetRoomManager().NextRoom();
        }
    }
}
