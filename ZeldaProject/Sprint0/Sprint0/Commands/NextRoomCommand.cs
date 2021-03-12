using System;
using System.Diagnostics;

namespace Sprint0
{
    public class NextRoomCommand : ICommand
    {
        private Sprint3 game;
        public NextRoomCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetRoomManager().NextRoom();
        }
    }
}
