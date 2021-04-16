using System;
namespace Sprint0
{
    public class LinkFaceDownCommand : ICommand
    {
        private Sprint5 game;
        public LinkFaceDownCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().Move(Direction.Down);
        }
    }
}
