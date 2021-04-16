using System;
namespace Sprint0
{
    public class LinkFaceLeftCommand : ICommand
    {
        private Sprint5 game;
        public LinkFaceLeftCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().Move(Direction.Left);
        }
    }
}
