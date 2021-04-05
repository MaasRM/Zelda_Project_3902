using System;
using System.Diagnostics;

namespace Sprint0
{
    public class PreviousRoomCommand : ICommand
    {
        private Sprint4 game;
        public PreviousRoomCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetRoomManager().PreviousRoom();
        }
    }
}
