using System;
namespace Sprint0
{
    public class NothingCommand : ICommand
    {
        Sprint4 game;
        public NothingCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {

        }
    }
}
