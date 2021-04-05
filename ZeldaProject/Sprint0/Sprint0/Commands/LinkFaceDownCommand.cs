using System;
namespace Sprint0
{
    public class LinkFaceDownCommand : ICommand
    {
        private Sprint4 game;
        public LinkFaceDownCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().Move(Direction.Down);
        }
    }
}
