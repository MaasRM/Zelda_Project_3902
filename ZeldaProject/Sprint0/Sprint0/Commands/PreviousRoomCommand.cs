using System;
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
            Console.WriteLine("Previous Room Selected");
        }
    }
}
