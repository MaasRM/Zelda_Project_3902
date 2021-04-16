using System;
namespace Sprint0
{
    public class NothingCommand : ICommand
    {
        Sprint5 game;
        public NothingCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {

        }
    }
}
