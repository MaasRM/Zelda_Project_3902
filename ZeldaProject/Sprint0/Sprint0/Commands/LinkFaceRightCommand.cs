using System;
namespace Sprint0
{
    public class LinkFaceRightCommand : ICommand
    {
        private Sprint4 game;
        public LinkFaceRightCommand(Sprint4 sprint)
        {
            game = sprint;
        }

        public void Execute()
        {
            game.GetPlayer().getLinkStateMachine().faceRight();
        }
    }
}
