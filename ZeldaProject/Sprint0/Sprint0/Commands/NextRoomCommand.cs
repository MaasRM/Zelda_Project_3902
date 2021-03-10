using System;
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
            Console.WriteLine("Next Room Selected");
        }
    }
}
