using System;
namespace Sprint0
{
    public class LinkFaceRightCommand : ICommand
    {
        private Sprint5 game;
        public LinkFaceRightCommand(Sprint5 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().Move(Direction.Right);
        }
    }
}
