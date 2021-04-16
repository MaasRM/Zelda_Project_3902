using System;
using System.Diagnostics;

namespace Sprint0
{
    public class NextRoomCommand : ICommand
    {
        private Sprint5 game;
        public NextRoomCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetRoomManager().NextRoom();
        }
    }
}
