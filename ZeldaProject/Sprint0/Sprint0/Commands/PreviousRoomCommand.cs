using System;
using System.Diagnostics;

namespace Sprint0
{
    public class PreviousRoomCommand : ICommand
    {
        private Sprint3 game;
        public PreviousRoomCommand(Sprint3 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            Debug.WriteLine("Previous Room Selected");
        }
    }
}
